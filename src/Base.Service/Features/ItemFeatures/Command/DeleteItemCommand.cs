using Base.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Service.Features.ItemFeatures.Command
{
    public class DeleteItemByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteItemByIdCommandHandler : IRequestHandler<DeleteItemByIdCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public DeleteItemByIdCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteItemByIdCommand command, CancellationToken cancellationToken)
            {
                var Item = await _context.Items.Where(a => a.Id == command.Id).FirstOrDefaultAsync();
                if (Item == null) return default;
                _context.Items.Remove(Item);
                await _context.SaveChangesAsync();
                return Item.Id;
            }
        }
    }
}
