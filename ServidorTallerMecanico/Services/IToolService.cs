using ServidorTallerMecanico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorTallerMecanico.Services
{
    public interface IToolsService {
        Tool Create(Tool tool);
        Tool Read(long id);
        IQueryable<Tool> ReadAll();
        void Update(long id, Tool tool);
        Tool Delete(long id);
    }
}
