using Base.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Base.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemsController : ControllerBase
	{
		private readonly ApplicationDbContext _db;

		public ItemsController(ApplicationDbContext db)
		{
			_db = db;
		}
		/// <summary>
		/// Get all items
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_db.Items.ToList());
		}

		// GET api/<ItemsController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<ItemsController>
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/<ItemsController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ItemsController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
