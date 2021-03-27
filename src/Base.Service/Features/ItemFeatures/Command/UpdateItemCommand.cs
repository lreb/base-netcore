using Base.Persistence;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Service.Features.ItemFeatures.Command
{
	public class UpdateItemCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public bool Active { get; set; }
        public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, int>
        {
            private readonly IApplicationDbContext _context;
            public UpdateItemCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateItemCommand command, CancellationToken cancellationToken)
            {
                var item = _context.Items.Where(a => a.Id == command.Id).FirstOrDefault();

                if (item == null)
                {
                    return default;
                }
                else
                {
                    item.Name = command.Name;
                    item.Quantity = command.Quantity;
                    item.Active = command.Active;

                    item.UpdatedOn = DateTime.Now;
                    item.UpdatedBy = 2; // user id

                    /* If the entry is being tracked, then invoking update API is not needed. 
                      The API only needs to be invoked if the entry was not tracked. 
                      https://www.learnentityframeworkcore.com/dbcontext/modifying-data */
                    _context.Items.Update(item);

                    await _context.SaveChangesAsync();

                    return item.Id;
                }
            }
        }
    }
}
