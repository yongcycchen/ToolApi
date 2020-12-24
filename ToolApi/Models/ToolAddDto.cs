using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolApi.Entities;

namespace ToolApi.Models
{
    public class ToolAddDto
    {
        public string name { get; set; }
        public Status status { get; set; }
    }
}
