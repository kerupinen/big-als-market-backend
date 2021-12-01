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
    public class AttendeeController : ControllerBase
    {
        // GET: api/attendee
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Attendees> Get()
        {
            IAttendeeDataHandler attendeeHandler = new AttendeeDataHandler();
            return attendeeHandler.Select();
        }

        // GET: api/attendee/5
        [EnableCors("OpenPolicy")]
        [HttpGet("{id}", Name = "GetAttendee")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/attendee
        [EnableCors("OpenPolicy")]
        [HttpPost("attendeePost")]
        public void Post([FromBody] Attendees attendee)
        {
            IAttendeeDataHandler attendeeHandler = new AttendeeDataHandler();
            attendeeHandler.Insert(attendee);
        }

        // PUT: api/attendee/5
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/attendee/5
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //Get
        //Call find vendor 
        [EnableCors("OpenPolicy")]
        [HttpPost("aInfo")]
        public Attendees Gets([FromBody]Attendees attendee)
        {
            IAttendeeDataHandler attendeeHandler = new AttendeeDataHandler();
            return attendeeHandler.findAttendee(attendee);

        }

        [EnableCors("OpenPolicy")]
        [HttpGet("report")]
        public int Report()
        {
            IAttendeeDataHandler attendeeHandler = new AttendeeDataHandler();
            return attendeeHandler.CountAttendees();
        }

        [EnableCors("OpenPolicy")]
        [HttpPost("attendeeRegister")]
        public Attendees Get([FromBody]Attendees attendee)
        {
            IAttendeeDataHandler attendeeHandler = new AttendeeDataHandler();
            return attendeeHandler.findAttendeeById(attendee);
        }

        

    }
}
