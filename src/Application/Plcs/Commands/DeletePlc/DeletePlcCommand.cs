using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Clean_Architecture.Application.Common.Exceptions;
using Clean_Architecture.Application.Common.Interfaces;
using Clean_Architecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Application.Plcs.Commands.DeletePlc
{
    public class DeletePlcCommand : IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePlcCommandHandler : IRequestHandler<DeletePlcCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeletePlcCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeletePlcCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Plcs
                .Where(p => p.Id == request.Id)
                .SingleOrDefaultAsync(cancellationToken);
            
            if (entity == null)
            {
                throw new NotFoundException(nameof(Plc), request.Id);
            }

            _context.Plcs.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
