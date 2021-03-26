using Base.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Base.Persistence.Seeds
{
	public static class ItemSeed
	{
		public static List<Item> ItemList() 
		{
			return new List<Item>()
			{
				new Item { Id = 1, Name= "A", Quantity = 1, Active = true,CreatedOn = DateTime.Now },
				new Item { Id = 2, Name = "B", Quantity = 2, Active = true,CreatedOn = DateTime.Now  },
				new Item { Id = 3, Name = "C", Quantity = 3, Active = true,CreatedOn = DateTime.Now  }
			};
		}
	}
}
