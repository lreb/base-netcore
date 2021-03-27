using Base.Domain.Entities;
using Base.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Service.Features.ItemFeatures.Query
{
    public class GetItemByIdQuery : IRequest<Item>
    {
        public int Id { get; set; }
        public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, Item>
        {
            private readonly IApplicationDbContext _context;
            public GetItemByIdQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

			public async Task<Item> Handle(GetItemByIdQuery query, CancellationToken cancellationToken)
			{
                var Item = await _context.Items.Where(a => a.Id == query.Id).FirstOrDefaultAsync();
                if (Item == null) return null;
                return Item;
            }
        }
    }
}
