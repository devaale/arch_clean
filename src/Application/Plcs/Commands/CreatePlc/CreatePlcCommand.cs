using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Clean_Architecture.Application.Common.Interfaces;
using Clean_Architecture.Application.TodoLists.Commands.CreateTodoList;
using Clean_Architecture.Domain.Entities;
using MediatR;

namespace Clean_Architecture.Application.Plcs.Commands.CreatePlc
{
    public class CreatePlcCommand : IRequest<int>
    {
        public string IpAddress { get; set; }
        public int Rack { get; set; }
        public int Slot { get; set; }
    }

    public class CreatePlcCommandHandler : IRequestHandler<CreatePlcCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreatePlcCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreatePlcCommand request, CancellationToken cancellationToken)
        {
            var entity = new Plc();

            entity.IpAddress = request.IpAddress;
            entity.Rack = request.Rack;
            entity.Slot = request.Slot;

            _context.Plcs.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
