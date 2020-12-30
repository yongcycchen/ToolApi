using System;
using AutoMapper;
using ToolApi.Entities;
using ToolApi.Data;
using ToolApi.Models;

namespace ToolApi.Profiles
{
    public class NotificationProfiles:Profile
    {
        public NotificationProfiles()
        {
            CreateMap<ToolNotification, NotificationDto>();
            CreateMap<NotificationDto, ToolNotification>();

        }
    }
}
