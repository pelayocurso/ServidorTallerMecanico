using ServidorTallerMecanico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorTallerMecanico.Repositories
{
    public interface IToolsRepository {
        Tool Create(Tool tool);
        Tool Read(long id);
        IQueryable<Tool> ReadAll();
        void Update(long id, Tool tool);
        Tool Delete(long id);
    }
}
