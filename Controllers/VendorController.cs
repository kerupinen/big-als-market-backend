using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using api.Interfaces;
using api.Models;
using api.Data;
using System;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        // GET: api/vendor
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Vendors> Get()
        {
            IVendorDataHandler vendorHandler = new VendorDataHandler();
            return vendorHandler.Select();
        }


        // GET: api/vendor/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetVendor")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/vendor
        [EnableCors("OpenPolicy")]
        [HttpPost("vendorPost")]
        public void Post([FromBody] Vendors vendor)
        {
            IVendorDataHandler vendorHandler = new VendorDataHandler();
            vendorHandler.Insert(vendor);
        }

        // PUT: api/vendor/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vendors value)
        {
            value.VenNum = id;
            value.vendorHandler.Update(value);
        }

        // DELETE: api/vendor/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //Get
        //Call find vendor 
        [EnableCors("OpenPolicy")]
        [HttpPost("vendorInfo")]
        public Vendors Gets([FromBody]Vendors vendor)
        {
            IVendorDataHandler vendorHandler = new VendorDataHandler();
            return vendorHandler.findVendor(vendor);

        }

        [EnableCors("OpenPolicy")]
        [HttpGet("report")]
        public int Report()
        {
            IVendorDataHandler vendorHandler = new VendorDataHandler();
            return vendorHandler.CountVendors();
        }

        [EnableCors("OpenPolicy")]
        [HttpPost("vendorRegister")]
        public Vendors Get([FromBody]Vendors vendor)
        {
            IVendorDataHandler vendorHandler = new VendorDataHandler();
            return vendorHandler.findVendorById(vendor);
        }
    }
}
