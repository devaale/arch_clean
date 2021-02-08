using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean_Architecture.Domain.Common;

namespace Clean_Architecture.Domain.Entities
{
    public class Record : AuditableEntity
    {
        public int Id { get; set; }
        public PlcBlock FkPlcBlock { get; set; }
        public int FkPlcBlockId { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int RfidCode { get; set; }
        public double Weight { get; set; }
        public int ReceivedFrom { get; set; }
        public int SentTo { get; set; }
        public int Count { get; set; }

    }
}
