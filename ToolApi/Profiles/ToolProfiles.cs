﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ToolApi.Entities;
using ToolApi.Models;

namespace ToolApi.Profiles
{
    public class ToolProfiles: Profile
    {
        public ToolProfiles()
        {
            CreateMap<Tool, ToolDto>();
            CreateMap<ToolAddDto, Tool>();
        }
    }
}
