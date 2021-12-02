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
        //Returns list of admins from database
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Admins> Get()
        {
            IAdminDataHandler adminHandler = new AdminDataHandler();
            return adminHandler.Select();
        }

        // POST: api/admin
        //Inserts new made admin into database given admin info
        [EnableCors("OpenPolicy")]
        [HttpPost("adminPost")]
        public void Post([FromBody] Admins admin)
        {
            IAdminDataHandler adminHandler = new AdminDataHandler();
            adminHandler.Insert(admin);
        }


        //Get
        //Finds the admin that matches given username and password
        [EnableCors("OpenPolicy")]
        [HttpPost("adminInfo")]
        public Admins Gets([FromBody]Admins admin)
        {
            IAdminDataHandler adminHanderler = new AdminDataHandler();
            return adminHanderler.findAdmin(admin);

        }
    }
}
