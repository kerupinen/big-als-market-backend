using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.Models;
using api.Interfaces;
using api.Data;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // GET: api/admin
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/admin/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetAdmin")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/admin
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Admins admin)
        {
            IAdminDataHandler adminHandler = new AdminDataHandler();
            adminHandler.Insert(admin);
        }

        // PUT: api/admin/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/admin/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //Get
        //Call find vendor 
        [EnableCors("OpenPolicy")]
        [HttpPost("adminInfo")]
        public Admins Gets([FromBody]Admins admin)
        {
            IAdminDataHandler adminHanderler = new AdminDataHandler();
            return adminHanderler.findAdmin(admin);

        }
    }
}
