using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clean_Architecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.Plcs.Queries.GetPlcs
{
    public class GetPlcsQuery : IRequest<PlcVm>
    {
    }

    public class GetPlcsQueryHandler : IRequestHandler<GetPlcsQuery, PlcVm>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPlcsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PlcVm> Handle(GetPlcsQuery request, CancellationToken cancellationToken)
        {
            return new PlcVm
            {
                PlcLists = await _context.Plcs
                    .AsNoTracking()
                    .ProjectTo<PlcDto>(_mapper.ConfigurationProvider)
                    .OrderBy(p => p.Id)
                    .ToListAsync(cancellationToken)
            };
        }
    }
}
