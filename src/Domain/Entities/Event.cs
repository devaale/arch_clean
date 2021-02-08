using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Domain.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public PlcBlock FkPlcBlock { get; set; }
        public int FkPlcBlockId { get; set; }
        public DateTime EventDateTime { get; set; }
        public string Text { get; set; }
    }
}
