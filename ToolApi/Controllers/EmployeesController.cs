using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolApi.Data;
using ToolApi.Profiles;
using AutoMapper;

namespace ToolApi.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController: ControllerBase
    {
        private readonly RoutineDbContext _context;
        private readonly IMapper _mapper;

        public EmployeesController(RoutineDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

    }
}
