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
        //returns list of attendees from databse
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Attendees> Get()
        {
            IAttendeeDataHandler attendeeHandler = new AttendeeDataHandler();
            return attendeeHandler.Select();
        }

        // POST: api/attendee
        //Inserts new attendee into database, given attendee info
        [EnableCors("OpenPolicy")]
        [HttpPost("attendeePost")]
        public void Post([FromBody] Attendees attendee)
        {
            IAttendeeDataHandler attendeeHandler = new AttendeeDataHandler();
            attendeeHandler.Insert(attendee);
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
