using Microsoft.AspNetCore.Mvc;

using System.IO;
using System.Linq;

namespace WebServiceApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WebServiceController : ControllerBase
	{
		[HttpGet]
		[Route("getAll")]
		public IActionResult Get()
		{
			var filesNames = new DirectoryInfo("Files/")
				.GetFiles()
				.Select(f => f.Name);
			return new ObjectResult(filesNames);
		}

		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var file = new DirectoryInfo("Files/").GetFiles()[id];
			string contentType = "application/txt";
			return PhysicalFile(file.FullName, contentType, file.Name);
		}
	}
}
