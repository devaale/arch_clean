using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean_Architecture.Domain.Common;

namespace Clean_Architecture.Domain.Entities
{
    public class PlcBlock : AuditableEntity
    {
        public int Id { get; set; }
        public Plc FkPlc { get; set; }
        public int FkPlcId { get; set; }
        public bool Value { get; set; }
        public string DataType { get; set; }
        public string CommandType { get; set; }
        public double OffsetBit { get; set; }
        public IList<Record> Records { get; private set; } = new List<Record>();
        public IList<Event> Events { get; private set; } = new List<Event>();
    }
}
