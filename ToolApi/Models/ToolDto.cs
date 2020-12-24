using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolApi.Entities;

namespace ToolApi.Models
{
    public class ToolDto
    {
        public Guid ToolID { get; set; }
        public string name { get; set; }
        public Status status { get; set; }

        public DateTime statusChangedDate { get; set; }
        public DateTime manualChangedDate { get; set; }
    }
}
