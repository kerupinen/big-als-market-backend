using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IAttendeeDataHandler
    {
         public List<Attendees> Select();
         public void Delete(Attendees attendee);
         public void Update(Attendees attendee);
         public void Insert(Attendees attendee);
         public Attendees findAttendee(Attendees attendee);
         public int CountAttendees();
         public Attendees findAttendeeById(Attendees attendee);
    }
}