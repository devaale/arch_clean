using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Clean_Architecture.Application.Common.Interfaces;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Application.Plcs.Commands.CreatePlc
{
    public class CreatePlcCommandValidator : AbstractValidator<CreatePlcCommand>
    {
        private readonly IApplicationDbContext _context;

        public CreatePlcCommandValidator(IApplicationDbContext context)
        {
            _context = context;

            RuleFor(v => v.IpAddress)
                .NotEmpty().WithMessage("IP is required.")
                .MaximumLength(15).WithMessage("IP must not exceed 15 characters.")
                .MustAsync(BeUniqueIp).WithMessage("The specified title already exists.");
        }

        public async Task<bool> BeUniqueIp(string ip, CancellationToken cancellationToken)
        {
            return await _context.Plcs
                .AllAsync(l => l.IpAddress != ip);
        }
    }
}
