using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolApi.Entities;
using ToolApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ToolApi.Services
{
    public class NotificationRepository:INotificationRepository
    {
        private readonly RoutineDbContext _context;

        public NotificationRepository(RoutineDbContext context)
        {
            _context = context;
        }

        public void AddNotification(ToolNotification notification)
        {
            if (notification == null)
                throw new ArgumentException(nameof(notification));
            _context.ToolNotifications.Add(notification);
        }

        public void UpdateNotification(ToolNotification notification)
        {

        }

        public void DeleteNotification(ToolNotification notification)
        {
            if (notification == null)
                throw new ArgumentException(nameof(notification));
            _context.ToolNotifications.Remove(notification);
        }

        public async Task<ToolNotification> GetNotificationAsync(string FSID, Guid ToolID)
        {
            return await _context.ToolNotifications.Where(x => x.ToolID == ToolID).Where(x => x.FSID == FSID).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ToolNotification>> GetToolNotificationsAsync()
        {
            return await _context.ToolNotifications.ToListAsync();
        }

        public async Task<bool> NotificationExsitAsync(string FSID,Guid ToolID)
        {
            return await _context.ToolNotifications.AnyAsync(x => x.ToolID == ToolID && x.FSID == FSID);
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }

    }
}
