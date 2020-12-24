using System;
using System.Collections.Generic;

namespace ToolApi.Entities
{
    public class Employee
    {
        public string FSID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public ICollection<ToolOwner> ToolOwners { get; set; } = new List<ToolOwner>();
        public ICollection<ToolNotification> ToolNotificationList { get; set; } = new List<ToolNotification>();
    }
}