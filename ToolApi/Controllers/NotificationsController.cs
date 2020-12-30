using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ToolApi.Entities;
using ToolApi.Models;
using ToolApi.Services;

namespace ToolApi.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationsController:ControllerBase
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;

        public NotificationsController(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<NotificationDto>>> GetNotifications()
        {
            var notifications = await _notificationRepository.GetToolNotificationsAsync();
            var notificationDtos = _mapper.Map<NotificationDto>(notifications);
            return Ok(notificationDtos);
        }

        //[HttpPost("/{FSID}")]
        public async Task<ActionResult<NotificationDto>> GetNotification(string FSID, Guid ToolID)
        {
            var notification = await _notificationRepository.GetNotificationAsync(FSID, ToolID);
            var notificationDto = _mapper.Map<NotificationDto>(notification);
            return Ok(notificationDto);
        }

        
    }
}
