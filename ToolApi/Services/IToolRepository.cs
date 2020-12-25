using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolApi.Entities;
namespace ToolApi.Services
{
    public interface IToolRepository
    {
        void AddTool(Tool tool);

        void UpdateTool(Tool tool);

        void DeleteTool(Tool tool);

        Task<bool> ToolExistAsync(Guid ToolId);

        Task<IEnumerable<Tool>> GetToolsAsync();
        Task<Tool> GetToolAsync(Guid ToolID);

        Task<bool> SaveAsync();
    }
}
