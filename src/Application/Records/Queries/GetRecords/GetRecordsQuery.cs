using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clean_Architecture.Application.Common.Interfaces;
using Clean_Architecture.Application.PlcBlocks.Queries.GetPlcBlocks;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Application.Records.Queries.GetRecords
{
    public class GetRecordsQuery : IRequest<List<RecordDto>>
    {
        public int FkPlcBlockId { get; set; }
    }

    public class GetRecordsQueryHandler : IRequestHandler<GetRecordsQuery, List<RecordDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRecordsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RecordDto>> Handle(GetRecordsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Records
                .Where(x => x.FkPlcBlockId == request.FkPlcBlockId)
                .OrderBy(x => x.Id)
                .ProjectTo<RecordDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        }
    }
}
