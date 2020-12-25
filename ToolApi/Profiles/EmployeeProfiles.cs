using System;
using AutoMapper;
using ToolApi.Entities;
using ToolApi.Models;
namespace ToolApi.Profiles
{
    public class EmployeeProfiles: Profile
    {
        public EmployeeProfiles()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<EmployeeAddDto, Employee>();
        }
    }
}
