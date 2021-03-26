using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Base.Persistence
{
	public interface IApplicationDbContext
	{
		DbSet<Item> Items { get; set; }

		Task<int> SaveChangesAsync();
	}
}
