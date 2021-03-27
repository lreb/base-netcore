using Base.Persistence;
using Base.Service.Features.ItemFeatures.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
// HttpContext.RequestServices.GetService<IMediator>();
using Microsoft.Extensions.DependencyInjection;
using Base.Service.Features.ItemFeatures.Command;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Base.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ItemsController : ControllerBase
	{
		private IMediator _mediator;
		protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

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
		public async Task<IActionResult> Get()
		{
			return Ok(await Mediator.Send(new GetAllItemsQuery()));
			//return Ok(_db.Items.ToList());
		}

		// GET api/<ItemsController>/5
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			return Ok(await Mediator.Send(new GetItemByIdQuery { Id = id }));
		}

		// POST api/<ItemsController>
		[HttpPost]
		public async Task<IActionResult> Create(CreateItemCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

		// PUT api/<ItemsController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateItemCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}
			return Ok(await Mediator.Send(command));
		}

		// DELETE api/<ItemsController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await Mediator.Send(new DeleteItemByIdCommand { Id = id }));
		}
	}
}
