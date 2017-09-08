using ServidorTallerMecanico.Models;
using ServidorTallerMecanico.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorTallerMecanico.Services
{
    public class VehiclesService : IVehiclesService
    {
        private IVehiclesRepository vehiclesRepository;
        public VehiclesService(IVehiclesRepository vehiclesRepository)
        {
            this.vehiclesRepository = vehiclesRepository;
        }

        public Vehicle Create(Vehicle vehicle)
        {
            return vehiclesRepository.Create(vehicle);
        }

        public Vehicle Read(long id)
        {
            return vehiclesRepository.Read(id);
        }

        public IQueryable<Vehicle> ReadAll()
        {
            IQueryable<Vehicle> vehicles;
            vehicles = vehiclesRepository.ReadAll();
            return vehicles;
        }

        public void Update(long id, Vehicle vehicle)
        {
            vehiclesRepository.Update(id, vehicle);
        }

        public Vehicle Delete(long id)
        {
            return vehiclesRepository.Delete(id);
        }
    }
}
