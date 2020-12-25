using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToolApi.Services;
using AutoMapper;
using ToolApi.Entities;
using ToolApi.Models;

namespace ToolApi.Controllers
{
    [ApiController]
    [Route("api/tools")]
    public class ToolsController : ControllerBase
    {
        private readonly IToolRepository _toolRepository;
        private readonly IMapper _mapper;

        public ToolsController(IToolRepository toolRepository, IMapper mapper)
        {
            _toolRepository = toolRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToolDto>>> GetTools()
        {
            var tools = await _toolRepository.GetToolsAsync();
            var toolDtos = _mapper.Map<IEnumerable<ToolDto>>(tools);

            return Ok(toolDtos);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTool(ToolAddDto tool)
        {
            var entity = _mapper.Map<Tool>(tool);
            _toolRepository.AddTool(entity);
            await _toolRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{toolID}")]
        public async Task<IActionResult> DeleteTool(Guid toolID)
        {
            if (!await _toolRepository.ToolExistAsync(toolID))
                return NotFound();
            var tool = await _toolRepository.GetToolAsync(toolID);
            _toolRepository.DeleteTool(tool);
            await _toolRepository.SaveAsync();
            return Ok();
        }
    }
}
