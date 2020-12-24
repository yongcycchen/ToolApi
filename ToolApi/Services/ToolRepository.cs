using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToolApi.Entities;
using ToolApi.Data;
using Microsoft.EntityFrameworkCore;

namespace ToolApi.Services
{
    public class ToolRepository : IToolRepository
    {
        private readonly RoutineDbContext _context;
        public ToolRepository(RoutineDbContext context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
        }
        public void AddTool(Tool tool)
        {
            if (tool == null)
            {
                throw new ArgumentException(nameof(tool));
            }
            tool.ToolID = Guid.NewGuid();
            tool.statusChangedDate = System.DateTime.Now;
            tool.manualChangedDate = System.DateTime.Now;
            _context.Tools.Add(tool);
        }

        public void DeleteTool(Tool tool)
        {
            if (tool == null)
            {
                throw new ArgumentException(nameof(tool));
            }
            _context.Tools.Remove(tool);
        }

        public void UpdateTool(Tool tool)
        {
        }

        public async Task<bool> ToolExistAsync(Guid ToolId)
        {
            if (ToolId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(ToolId));
            }

            return await _context.Tools.AnyAsync(x=>x.ToolID == ToolId);
        }
        public async Task<IEnumerable<Tool>> GetToolsAsync()
        {
            return await _context.Tools.ToListAsync();
        }
        public async Task<Tool> GetToolAsync(Guid ToolID)
        {
            return await _context.Tools
                .Where(x => x.ToolID == ToolID)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() >= 0;
        }
    }
}
