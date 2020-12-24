using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToolApi.Entities
{
    public class ToolOwner
    {
        public Guid ToolID { get; set; }
        public string ToolName { get; set; }
        public string FSID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Level { get; set; }
    }
}
