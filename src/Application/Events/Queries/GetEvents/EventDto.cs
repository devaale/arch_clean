using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean_Architecture.Application.Common.Mappings;
using Clean_Architecture.Domain.Entities;

namespace Clean_Architecture.Application.Events.Queries.GetEvents
{
    public class EventDto : IMapFrom<Event>
    {
        public int Id { get; set; }
        public int FkPlcBlockId { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Text { get; set; }
    }
}
