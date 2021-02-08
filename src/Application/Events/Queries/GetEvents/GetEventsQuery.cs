using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Clean_Architecture.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Clean_Architecture.Application.Events.Queries.GetEvents
{
    public class GetEventsQuery : IRequest<List<EventDto>>
    {
        public int FkPlcBlockId { get; set; }
    }

    public class GetEventsQueryHandler : IRequestHandler<GetEventsQuery, List<EventDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEventsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<EventDto>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Events
                .Where(x => x.FkPlcBlockId == request.FkPlcBlockId)
                .OrderBy(x => x.Id)
                .ProjectTo<EventDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }
    }
}
