using System;
using ToolApi.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace ToolApi.Services
{
    public interface INotificationRepository
    {
        void AddNotification(ToolNotification notification);
        void UpdateNotification(ToolNotification notification);
        void DeleteNotification(ToolNotification notification);
        Task<bool> NotificationExsitAsync(string FSID, Guid ToolID);
        Task<ToolNotification> GetNotificationAsync(string FSID, Guid ToolID);
        Task<IEnumerable<ToolNotification>> GetToolNotificationsAsync();
        Task<bool> SaveAsync();
    }
}
