using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace NLog.Library.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HomeController : ControllerBase
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
			_logger.LogDebug(1,"Nlog injected into HomeController");
		}

		[HttpGet("action")]
		public IActionResult Action()
		{
			_logger.LogInformation("Action method called");
			return Ok("Action method called");
		}
		
	}
}
