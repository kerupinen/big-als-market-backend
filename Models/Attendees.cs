using api.Interfaces;

namespace api.Models
{
    public class Attendees
    {
        public int AttendeeNum {get; set;}
        public int RegistrationNum {get; set;}
        public string Username {get;set;}
        public string Password {get;set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}

        public IAttendeeDataHandler attendeeHandler;
        
        
    }
}