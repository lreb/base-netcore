using Base.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Base.Persistence.Seeds
{
    public static class SeedInitializer
	{
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasData(ItemSeed.ItemList());
        }
    }
}
