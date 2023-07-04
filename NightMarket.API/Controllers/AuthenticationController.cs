using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NightMarket.Application.Authentication.Login;
using NightMarket.Application.Authentication.SignUp;
using NightMarket.Application.Responses;
using NightMarket.Domain.Entities.IdentityBundles;
using NightMarket.Infrastructure.MailKit.Models;
using NightMarket.Infrastructure.MailKit.Services;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;

namespace NightMarket.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : BaseApiController
	{

		private readonly UserManager<ApplicationUsers> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _configuration;
		private readonly IEmailService _emailService;
		private readonly SignInManager<ApplicationUsers> _signInManager;

		public AuthenticationController(IMediator mediator,UserManager<ApplicationUsers> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration,SignInManager<ApplicationUsers> signInManager,IEmailService emailService) : base(mediator)
		{
			_configuration = configuration;
			_userManager = userManager;
			_roleManager = roleManager;
			_signInManager = signInManager;
			_emailService = emailService;
		}
		
		[HttpPost("Register")]
		public async Task<ApiResponse> Register(RegisterUser registerUser, string role)
		{
			//Check User Exist
			var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
			if (userExist != null)
			{
				return ApiResponse.Error(500, "User already exist!");
			}

			//Add the User into Database
			ApplicationUsers user = new()
			{
				Email = registerUser.Email,
				SecurityStamp = Guid.NewGuid().ToString(),
				UserName = registerUser.Username,
				//Bat xac thuc 2 yeu to
				//TwoFactorEnabled = true,
			};

			if (await _roleManager.RoleExistsAsync(role))
			{
				var result = await _userManager.CreateAsync(user, registerUser.Password);
				if (!result.Succeeded)
				{
					return  ApiResponse.Error(500, "User Failed to Create!");
				}
				//Add role to the user
				await _userManager.AddToRoleAsync(user, role);

				//Add token to verify the email...
				var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
				//Encode để có thể đính kèm nó trên địa chỉ url

				var confirmationLink = Url.Action(nameof(ConfirmEmail), "Authentication", new { token, email = user.Email }, Request.Scheme);
				//Gui email
				var message = new Message(new string[] { user.Email! }, "Confirmation email link!", confirmationLink);
				_emailService.SendEmail(message);

				return ApiResponse.Success(200, $"User Created & Email sent to {user.Email} Succesfully!");
			}
			else
			{
				return ApiResponse.Error(404, "This role does not exist!");
			}

		}

		[HttpGet("ConfirmEmail")]
		public async Task<ApiResponse> ConfirmEmail(string token, string email)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if (user != null)
			{
				var result = await _userManager.ConfirmEmailAsync(user, token);
				if (result.Succeeded)
				{
					return ApiResponse.Success(200, "Email Verify Succesfully!");
				}
			}
			return ApiResponse.Error(404, "This user does not exist!");

		}

		[HttpPost]
		[Route("Login")]
		public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
		{

			//Checking the user
			var user = await _userManager.FindByNameAsync(loginModel.Username);

			//Checking the password
			if (user != null && await _userManager.CheckPasswordAsync(user, loginModel.Password))
			{
				//Claimlist creation
				var authClaims = new List<Claim>
					{	
						new Claim(ClaimTypes.Name,user.UserName),
						new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
					};
				//Add roles to the list
				var userRoles = await _userManager.GetRolesAsync(user);
				foreach (var role in userRoles)
				{
					authClaims.Add(new Claim(ClaimTypes.Role, role.ToString()));
				}

				//Generate the token with the claims
				var jwtToken = GetToken(authClaims);
				//Returning the token
				return Ok(new
				{
					Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
					expiration = jwtToken.ValidTo
				});
			}
			return Unauthorized();
		}

		[HttpPost]
		[Route("login-2FA")]
		public async Task<IActionResult> LoginWithOTP(string code, string username)
		{
			var user = await _userManager.FindByNameAsync(username);
			var signIn = await _signInManager.TwoFactorSignInAsync("Email", code, false, false);
			if (signIn.Succeeded)
			{
				if (user != null)
				{
					var authClaims = new List<Claim>
				{
					new Claim(ClaimTypes.Name, user.UserName),
					new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				};
					var userRoles = await _userManager.GetRolesAsync(user);
					foreach (var role in userRoles)
					{
						authClaims.Add(new Claim(ClaimTypes.Role, role));
					}

					var jwtToken = GetToken(authClaims);

					return Ok(new
					{
						token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
						expiration = jwtToken.ValidTo
					});
					//returning the token...

				}
			}
			return BadRequest(new
			{	
				Status = 400,
				IsSuccess = "Error",
				Message = $"Invalid Code"
			});
		}

		//Generate token
		private JwtSecurityToken GetToken(List<Claim> authClaims)
		{
			var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
			var token = new JwtSecurityToken(
				audience: _configuration["JWT:ValidAudience"],
				issuer: _configuration["JWT:ValidIssue"],
				expires: DateTime.Now.AddHours(1),
				claims: authClaims,
				signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
				);
			return token;
		}

		[HttpPost]
		[Route("Forgot-Password")]
		[AllowAnonymous]
		public async Task<IActionResult> ForgotPassword([Required] string email)
		{
			var user = await _userManager.FindByEmailAsync(email);
			if (user != null)
			{
				var token = await _userManager.GeneratePasswordResetTokenAsync(user);
				var forgotPasswordlink = Url.Action(nameof(ResetPassword), "Authentication", new { token, email = user.Email }, Request.Scheme);
				var message = new Message(new string[] { user.Email! }, "Forgot password link!", forgotPasswordlink!);
				_emailService.SendEmail(message);
				return StatusCode(StatusCodes.Status200OK,
					   new { Status = "Success", Message = $"Password changed request is sent to {user.Email} Succesfully! .Please open your email and click the link" });
			}
			return StatusCode(StatusCodes.Status400BadRequest,
					   new  { Status = "Error", Message = $"Could not sent link to email,please try again!" });
		}



		[HttpGet("Reset-Password")]
		public async Task<IActionResult> ResetPassword(string token, string email)
		{
			var model = new ResetPassword { Token = token, Email = email };
			return Ok(new
			{
				model
			});
		}

		[HttpPost]
		[Route("Reset-Password")]
		[AllowAnonymous]
		public async Task<IActionResult> ResetPassword(ResetPassword resetPassword)
		{
			var user = await _userManager.FindByNameAsync(resetPassword.Email);
			if (user != null)
			{
				var resetPasswordResult = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
				if (!resetPasswordResult.Succeeded)
				{
					foreach (var error in resetPasswordResult.Errors)
					{
						ModelState.AddModelError(error.Code, error.Description);
					}
					return Ok(ModelState);
				}
				return StatusCode(StatusCodes.Status200OK, new  { Status = "Success", Message = $"Password has been changed " });
			}
			return StatusCode(StatusCodes.Status400BadRequest,
					   new  { Status = "Error", Message = $"Could not sent link to email,please try again!" });
		}

		[HttpPost("Logout")]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return StatusCode(StatusCodes.Status400BadRequest,
					  new  { Status = "Success", Message = $"Logout successfully!" });
		}
	}
}
