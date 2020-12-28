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
    [Route("api/employees")]
    public class EmployeesController: ControllerBase
    {
        private readonly IEmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper ?? throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var employees = await _repository.GetEmployeesAsync();
            var employeeDtos = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(employeeDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeAddDto employee)
        {
            var entity = _mapper.Map<Employee>(employee);
            _repository.AddEmployee(entity);
            await _repository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{FSID}")]
        public async Task<IActionResult> DeleteEmployee(string FSID)
        {
            if (!await _repository.EmployeeExistAsync(FSID))
                return NotFound();
            var employee=await _repository.GetEmployeeAsync(FSID);
            _repository.DeleteEmployee(employee);
            await _repository.SaveAsync();
            return Ok();
        }
    }
}
