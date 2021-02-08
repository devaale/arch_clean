using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clean_Architecture.Application.Common.Interfaces;
using Clean_Architecture.Application.Plcs.Queries.GetPlcs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Application.PlcBlocks.Queries.GetPlcBlocks
{
    public class GetPlcBlocksQuery : IRequest<List<PlcBlockDto>>
    {
        public int FkPlcId { get; set; }
    }

    public class GetPlcBlocksQueryHandler : IRequestHandler<GetPlcBlocksQuery, List<PlcBlockDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetPlcBlocksQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PlcBlockDto>> Handle(GetPlcBlocksQuery request, CancellationToken cancellationToken)
        {
            return await _context.PlcBlocks
                .Where(x => x.FkPlcId == request.FkPlcId)
                .OrderBy(x => x.Id)
                .ProjectTo<PlcBlockDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
