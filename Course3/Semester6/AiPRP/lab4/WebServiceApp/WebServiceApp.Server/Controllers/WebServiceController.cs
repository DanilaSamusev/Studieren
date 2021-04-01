using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebServiceApp.Server.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class WebServiceController : ControllerBase
	{
		private readonly IWebHostEnvironment _appEnvironment;

		public WebServiceController(IWebHostEnvironment appEnvironment)
		{
			_appEnvironment = appEnvironment;
		}

		[HttpGet]
		[Route("getAll")]
		public IActionResult Get()
		{
			var filesNames = new DirectoryInfo("Files/")
				.GetFiles()
				.Select(f => f.Name);
			return new ObjectResult(filesNames);
		}

		// GET api/<WebServiceController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var file = new DirectoryInfo("Files/").GetFiles()[id];
			string contentType = "application/txt";
			return PhysicalFile(file.FullName, contentType, file.Name);
		}

		// POST api/<WebServiceController>
		[HttpPost]
		public IActionResult Post([FromBody] string value)
		{
			return BadRequest();
		}

		// PUT api/<WebServiceController>/5
		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] string value)
		{
			return BadRequest();
		}

		// DELETE api/<WebServiceController>/5
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			return BadRequest();
		}
	}
}
