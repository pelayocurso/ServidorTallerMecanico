using ServidorTallerMecanico.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorTallerMecanico.Repositories
{
    public class VehiclesRepository:IVehiclesRepository
    {
        public Vehicle Create(Vehicle vehicle)
        {
            return ApplicationDbContext.applicationDbContext.Vehicles.Add(vehicle);
        }

        public Vehicle Read(long id)
        {
            return ApplicationDbContext.applicationDbContext.Vehicles.Find(id);
        }

        public IQueryable<Vehicle> ReadAll()
        {
            IList<Vehicle> vehicles = new List<Vehicle>(ApplicationDbContext.applicationDbContext.Vehicles);
            return vehicles.AsQueryable();
        }

        public void Update(long id, Vehicle vehicle)
        {
            if (ApplicationDbContext.applicationDbContext.Vehicles.Count(e => e.Id == vehicle.Id) == 0)
            {
                throw new Exception("No se ha encontrado la entidad.");
            }
            ApplicationDbContext.applicationDbContext.Entry(vehicle).State = System.Data.Entity.EntityState.Modified;
        }

        public Vehicle Delete(long id)
        {
            Vehicle vehicle = ApplicationDbContext.applicationDbContext.Vehicles.Find(id);
            if (vehicle == null)
            {
                throw new Exception("No se ha encontrado la entidad.");
            }
            ApplicationDbContext.applicationDbContext.Vehicles.Remove(vehicle);
            return vehicle;
        }
    }
}
