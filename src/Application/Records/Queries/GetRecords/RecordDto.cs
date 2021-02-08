using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clean_Architecture.Application.Common.Mappings;
using Clean_Architecture.Domain.Entities;

namespace Clean_Architecture.Application.Records.Queries.GetRecords
{
    public class RecordDto : IMapFrom<Record>
    {
        public int Id { get; set; }
        public int FkPlcBlockId { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public int RfidCode { get; set; }
        public double Weight { get; set; }
        public int ReceivedFrom { get; set; }
        public int SentTo { get; set; }
        public int Count { get; set; }
    }
}
