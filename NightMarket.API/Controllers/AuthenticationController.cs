using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using NightMarket.Application.Authentication.Login;
using NightMarket.Application.Authentication.SignUp;
using NightMarket.Application.Responses;
using NightMarket.Infrastructure.MailKit.Models;
using NightMarket.Infrastructure.MailKit.Services;
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

		private readonly UserManager<IdentityUser> _userManager;
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _configuration;
		private readonly IEmailService _emailService;
		private readonly SignInManager<IdentityUser> _signInManager;

		public AuthenticationController(IMediator mediator, IMapper mapper,UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration,SignInManager<IdentityUser> signInManager,IEmailService emailService) : base(mediator, mapper)
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
			IdentityUser user = new()
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

				//if (user.TwoFactorEnabled)
				//{
				//    await _signInManager.SignOutAsync();
				//    await _signInManager.PasswordSignInAsync(user, loginModel.Password, false, true);
				//    var token = await _userManager.GenerateTwoFactorTokenAsync(user, "Email");
				//    var message = new Message(new string[] { user.Email! }, "OTP confirmation !", token);
				//    _emailService.SendEmail(message);
				//    return StatusCode(StatusCodes.Status200OK,
				//       new Response { Status = "Success", Message = $"We have sent an OTP to your Email {user.Email}!" });
				//}

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
	}
}
