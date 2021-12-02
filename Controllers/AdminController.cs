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
        public List<Admins> Get()
        {
            IAdminDataHandler adminHandler = new AdminDataHandler();
            return adminHandler.Select();
        }

        // POST: api/admin
        [EnableCors("OpenPolicy")]
        [HttpPost("adminPost")]
        public void Post([FromBody] Admins admin)
        {
            IAdminDataHandler adminHandler = new AdminDataHandler();
            adminHandler.Insert(admin);
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
