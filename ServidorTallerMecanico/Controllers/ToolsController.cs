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
    public class ToolsController : ApiController
    {
        public IToolsService toolsService;
        public ToolsController(IToolsService toolsService)
        {
            this.toolsService = toolsService;
        }

        // POST: api/Tools
        [ResponseType(typeof(Tool))]
        public IHttpActionResult PostTool(Tool tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            tool = toolsService.Create(tool);
            return CreatedAtRoute("DefaultApi", new { id = tool.Id }, tool);
        }

        // GET: api/Tools/5
        [ResponseType(typeof(Tool))]
        public IHttpActionResult GetTool(long id)
        {
            Tool tool = toolsService.Read(id);
            if (tool == null)
            {
                return NotFound();
            }

            return Ok(tool);
        }

        // GET: api/Tools
        public IQueryable<Tool> GetTools()
        {
            return toolsService.ReadAll();
        }

        // PUT: api/Tools/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTool(long id, Tool tool)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tool.Id)
            {
                return BadRequest();
            }

            try
            {
                toolsService.Update(id, tool);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE: api/Tools/5
        [ResponseType(typeof(Tool))]
        public IHttpActionResult DeleteTool(long id)
        {
            Tool tool;

            try
            {
                tool = toolsService.Delete(id);
            }
            catch (Exception)
            {
                return NotFound();
            }
            return Ok(tool);
        }
    }
}
