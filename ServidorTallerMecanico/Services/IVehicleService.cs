using ServidorTallerMecanico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorTallerMecanico.Services
{
    public interface IVehiclesService {
        Vehicle Create(Vehicle vehicle);
        Vehicle Read(long id);
        IQueryable<Vehicle> ReadAll();
        void Update(long id, Vehicle vehicle);
        Vehicle Delete(long id);
    }
}
