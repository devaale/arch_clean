using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.PlcBlocks.Queries.GetPlcBlocks
{
    public class PlcBlockVm
    {
        public IList<PlcBlockDto> PlcBlockList { get; set; }
    }
}
