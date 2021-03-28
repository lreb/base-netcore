using Base.Persistence;
using Base.Service.Features.ItemFeatures.Command;
using Base.Service.Features.ItemFeatures.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
// import RequestServices.GetService<IMediator>();
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

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
		}

		/// <summary>
		/// Get item by id
		/// </summary>
		/// <param name="id">item identifier</param>
		/// <returns></returns>
		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			return Ok(await Mediator.Send(new GetItemByIdQuery { Id = id }));
		}

		/// <summary>
		/// Create item
		/// </summary>
		/// <param name="command">item data</param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> Create(CreateItemCommand command)
		{
			return Ok(await Mediator.Send(command));
		}

		/// <summary>
		/// Update item
		/// </summary>
		/// <param name="id">item id</param>
		/// <param name="command">item id</param>
		/// <returns></returns>
		[HttpPut("{id}")]
		public async Task<IActionResult> Update(int id, UpdateItemCommand command)
		{
			if (id != command.Id)
			{
				return BadRequest();
			}
			return Ok(await Mediator.Send(command));
		}

		/// <summary>
		/// Delete item
		/// </summary>
		/// <param name="id">item id</param>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			return Ok(await Mediator.Send(new DeleteItemByIdCommand { Id = id }));
		}
	}
}
