using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using api.Interfaces;
using api.Models;
using api.Data;

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
            IVendorDataHandler vendorHanderler = new VendorDataHandler();
            return vendorHanderler.Select();
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
        [HttpPost]
        public void Post([FromBody] Vendors value)
        {
            //value.vendorHandler.Insert(value);
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
            IVendorDataHandler vendorHanderler = new VendorDataHandler();
            return vendorHanderler.findVendor(vendor);

        }


    }
}
