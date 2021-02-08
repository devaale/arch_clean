using Clean_Architecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Domain.Entities
{
    public class Plc : AuditableEntity
    {
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public int Rack { get; set; }
        public int Slot { get; set; }
        public IList<PlcBlock> PlcBlocks { get; private set; } = new List<PlcBlock>();
    }
}
