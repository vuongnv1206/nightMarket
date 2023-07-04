using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightMarket.API.Controllers.Shopping
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserReviewController : ControllerBase
	{
		// GET: api/<UserReviewController>
		[HttpGet]
		public IEnumerable<string> Get()
		{
			return new string[] { "value1", "value2" };
		}

		// GET api/<UserReviewController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<UserReviewController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<UserReviewController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<UserReviewController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
