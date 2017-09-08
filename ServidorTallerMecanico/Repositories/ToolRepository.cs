using ServidorTallerMecanico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorTallerMecanico.Repositories
{
    public class ToolsRepository:IToolsRepository
    {
        public Tool Create(Tool tool)
        {
            return ApplicationDbContext.applicationDbContext.Tools.Add(tool);
        }

        public Tool Read(long id)
        {
            return ApplicationDbContext.applicationDbContext.Tools.Find(id);
        }

        public IQueryable<Tool> ReadAll()
        {
            IList<Tool> tools = new List<Tool>(ApplicationDbContext.applicationDbContext.Tools);
            return tools.AsQueryable();
        }

        public void Update(long id, Tool tool)
        {
            if (ApplicationDbContext.applicationDbContext.Tools.Count(e => e.Id == tool.Id) == 0)
            {
                throw new Exception("No se ha encontrado la entidad.");
            }
            ApplicationDbContext.applicationDbContext.Entry(tool).State = System.Data.Entity.EntityState.Modified;
        }

        public Tool Delete(long id)
        {
            Tool tool = ApplicationDbContext.applicationDbContext.Tools.Find(id);
            if (tool == null)
            {
                throw new Exception("No se ha encontrado la entidad.");
            }
            ApplicationDbContext.applicationDbContext.Tools.Remove(tool);
            return tool;
        }
    }
}
