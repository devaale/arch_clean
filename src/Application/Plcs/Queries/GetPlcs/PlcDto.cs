using Clean_Architecture.Application.Common.Mappings;
using Clean_Architecture.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean_Architecture.Application.PlcBlocks.Queries.GetPlcBlocks;

namespace Clean_Architecture.Application.Plcs.Queries.GetPlcs
{
    public class PlcDto : IMapFrom<Plc>
    {
        public PlcDto()
        {
            PlcBlocks = new List<PlcBlockDto>();
        }
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public int Rack { get; set; }
        public int Slot { get; set; }
        public IList<PlcBlockDto> PlcBlocks { get; set; }
    }
}
