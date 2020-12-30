using System;
namespace ToolApi.Models
{
    public class NotificationAddDto
    {
        public Guid ToolID { get; set; }
        public string ToolName { get; set; }
        public string FSID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
    }
}
