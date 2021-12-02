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
        //returns list of all Vendors from database
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Vendors> Get()
        {
            IVendorDataHandler vendorHanderler = new VendorDataHandler();
            return vendorHanderler.Select();
        }


        // PUT: api/vendor/5
        //Edits the vendors post
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Vendors value)
        {
            value.vendorHandler = new VendorDataHandler();
            value.VenNum = id;
            value.vendorHandler.Update(value);
        }
        //Inserts new vendor into database, given vendor info
        [EnableCors("OpenPolicy")]
        [HttpPost("vendorPost")]
        public void Post([FromBody] Vendors vendor)
        {
            IVendorDataHandler vendorHandler = new VendorDataHandler();
            vendorHandler.Insert(vendor);
        }

        //Get
        //Call find vendor 
        //returns vendor that matches username and password
        [EnableCors("OpenPolicy")]
        [HttpPost("vendorInfo")]
        public Vendors Gets([FromBody]Vendors vendor)
        {
            IVendorDataHandler vendorHandeler = new VendorDataHandler();
            return vendorHandeler.findVendor(vendor);

        }
        //Gives Count of Vendors
        [EnableCors("OpenPolicy")]
        [HttpGet("report")]
        public int Report()
        {
            IVendorDataHandler vendorHanderler = new VendorDataHandler();
            return vendorHanderler.CountVendors();
        }
        //Finds vendor, then assigns new registration number to it if not assigned already
        [EnableCors("OpenPolicy")]
        [HttpPost("vendorRegister")]
        public Vendors Get([FromBody]Vendors vendor)
        {
            IVendorDataHandler vendorHandeler = new VendorDataHandler();
            return vendorHandeler.findVendorById(vendor);
        }
    }
}
