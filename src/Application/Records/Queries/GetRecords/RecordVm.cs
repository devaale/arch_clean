using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean_Architecture.Application.Records.Queries.GetRecords
{
    public class RecordVm
    {
        public IList<RecordDto> RecordList { get; set; }
    }
}
