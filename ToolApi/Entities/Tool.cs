using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolApi.Entities
{
    public class Tool
    {
        public Guid ToolID { get; set; }
        public string name { get; set; }
        public Status status { get; set; }

        public DateTime statusChangedDate { get; set; }
        public DateTime manualChangedDate { get; set; }
    }
}
