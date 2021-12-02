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
            IVendorDataHandler vendorHanderler = new VendorDataHandler();
            return vendorHanderler.Select();
        }


        // PUT: api/vendor/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vendors value)
        {
            value.vendorHandler = new VendorDataHandler();
            value.VenNum = id;
            value.vendorHandler.Update(value);
        }

        //Get
        //Call find vendor 
        [EnableCors("OpenPolicy")]
        [HttpPost("vendorInfo")]
        public Vendors Gets([FromBody]Vendors vendor)
        {
            IVendorDataHandler vendorHandeler = new VendorDataHandler();
            return vendorHandeler.findVendor(vendor);

        }

        [EnableCors("OpenPolicy")]
        [HttpGet("report")]
        public int Report()
        {
            IVendorDataHandler vendorHanderler = new VendorDataHandler();
            return vendorHanderler.CountVendors();
        }

        [EnableCors("OpenPolicy")]
        [HttpPost("vendorRegister")]
        public Vendors Get([FromBody]Vendors vendor)
        {
            IVendorDataHandler vendorHandeler = new VendorDataHandler();
            return vendorHandeler.findVendorById(vendor);
        }
    }
}
