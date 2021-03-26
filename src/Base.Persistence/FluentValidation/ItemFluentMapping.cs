using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base.Persistence.FluentValidation
{
	public static class ItemFluentMapping
	{
        public static void ItemMapping(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity => {
                entity.HasIndex(x => new { x.Name, x.Quantity });
            });
        }
    }
}
