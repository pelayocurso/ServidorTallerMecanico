using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ServidorTallerMecanico.Models;
using System.Web.Http.Cors;
using ServidorTallerMecanico.Services;

namespace ServidorTallerMecanico.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class VehiclesController : ApiController
    {
        public IVehiclesService vehiclesService;
        public VehiclesController(IVehiclesService vehiclesService)
        {
            this.vehiclesService = vehiclesService;
        }

        // POST: api/Vehicles
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult PostVehicle(Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            vehicle = vehiclesService.Create(vehicle);
            return CreatedAtRoute("DefaultApi", new { id = vehicle.Id }, vehicle);
        }

        // GET: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult GetVehicle(long id)
        {
            Vehicle vehicle = vehiclesService.Read(id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return Ok(vehicle);
        }

        // GET: api/Vehicles
        public IQueryable<Vehicle> GetVehicles()
        {
            return vehiclesService.ReadAll();
        }

        // PUT: api/Vehicles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicle(long id, Vehicle vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            try
            {
                vehiclesService.Update(id, vehicle);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Vehicles/5
        [ResponseType(typeof(Vehicle))]
        public IHttpActionResult DeleteVehicle(long id)
        {
            Vehicle vehicle;

            try
            {
                vehicle = vehiclesService.Delete(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok(vehicle);
        }
    }
}
