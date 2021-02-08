using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean_Architecture.Application.Common.Mappings;
using Clean_Architecture.Domain.Entities;

namespace Clean_Architecture.Application.PlcBlocks.Queries.GetPlcBlocks
{
    public class PlcBlockDto : IMapFrom<PlcBlock>
    {
        public PlcBlockDto()
        {
            Records = new List<Record>();
            Events = new List<Event>();
        }
        public int Id { get; set; }
        public int FkPlcId { get; set; }
        public bool Value { get; set; }
        public string DataType { get; set; }
        public string CommandType { get; set; }
        public double OffsetBit { get; set; }
        public IList<Record> Records { get; set; }
        public IList<Event> Events { get; set; }
    }
}
