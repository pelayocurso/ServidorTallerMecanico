using ServidorTallerMecanico.Models;
using ServidorTallerMecanico.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorTallerMecanico.Services
{
    public class ToolsService : IToolsService
    {
        private IToolsRepository toolsRepository;
        public ToolsService(IToolsRepository toolsRepository)
        {
            this.toolsRepository = toolsRepository;
        }

        public Tool Create(Tool tool)
        {
            return toolsRepository.Create(tool);
        }

        public Tool Read(long id)
        {
            return toolsRepository.Read(id);
        }

        public IQueryable<Tool> ReadAll()
        {
            IQueryable<Tool> tools;
            tools = toolsRepository.ReadAll();
            return tools;
        }

        public void Update(long id, Tool tool)
        {
            toolsRepository.Update(id, tool);
        }

        public Tool Delete(long id)
        {
            return toolsRepository.Delete(id);
        }
    }
}
