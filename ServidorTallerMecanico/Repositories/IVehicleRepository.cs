using ServidorTallerMecanico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorTallerMecanico.Repositories
{
    public interface IVehiclesRepository {
        Vehicle Create(Vehicle vehicle);
        Vehicle Read(long id);
        IQueryable<Vehicle> ReadAll();
        void Update(long id, Vehicle vehicle);
        Vehicle Delete(long id);
    }
}
