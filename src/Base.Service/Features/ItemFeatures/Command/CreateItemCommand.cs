using Base.Domain.Entities;
using Base.Persistence;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Service.Features.ItemFeatures.Command
{
	public class CreateItemCommand : IRequest<int>
	{
        public string Name { get; set; }
        public int Quantity { get; set; }
        public class CreateitemCommandHandler : IRequestHandler<CreateItemCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public CreateitemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateItemCommand command, CancellationToken cancellationToken)
            {
                // TODO: automepper
                var item = new Item();
                item.Name = command.Name;
                item.Quantity = command.Quantity;

                item.Active = true;
                item.CreatedOn = DateTime.Now;
                item.CreatedBy = 1; // User id

                _context.Items.Add(item);

                await _context.SaveChangesAsync();
                return item.Id;
            }
        }
    }
}
