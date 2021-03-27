using Base.Domain.Entities;
using Base.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Service.Features.ItemFeatures.Query
{
	public class GetAllItemsQuery : IRequest<IEnumerable<Item>>
	{
        public class GetAllItemsQueryHandler : IRequestHandler<GetAllItemsQuery, IEnumerable<Item>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllItemsQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Item>> Handle(GetAllItemsQuery query, CancellationToken cancellationToken)
            {
                var itemList = await _context.Items.ToListAsync();
                if (itemList == null)
                {
                    return null;
                }
                return itemList.AsReadOnly();
            }
        }
    }
}
