using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PublicService.Models;

namespace PublicService.Controllers
{
	[ApiController]
	[Route("environment")]
	public class EnvironmentController : ControllerBase
	{
		[HttpGet]
		public IEnumerable<EnvironmentVariable> Get()
		{
			return Environment.GetEnvironmentVariables()
				.Cast<DictionaryEntry>()
				.Select(x => new { Name = (string)x.Key, Value = (string)x.Value })
				.Select(x => new EnvironmentVariable
				{
					Name = x.Name,
					Value = x.Value,
				});
		}
	}
}
