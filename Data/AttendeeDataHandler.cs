using System.Collections.Generic;
using System.Dynamic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class AttendeeDataHandler : IAttendeeDataHandler
    {
        private Database db;

        public AttendeeDataHandler()
        {
            db = new Database();
        }
        public void Delete(Attendees attendee)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Attendees attendee)
        {
            throw new System.NotImplementedException();
        }

        public List<Attendees> Select()
        {
            db.Open();
            string sql = "select * from attendees";
            List<ExpandoObject> result = db.Select(sql);

            List<Attendees> attendee = new List<Attendees>();
            foreach(dynamic item in result)
            {
                Attendees temp = new Attendees(){
                    AttendeeNum = item.attendeeNum,
                    RegistrationNum = item.registrationNum,
                    Username = item.username,
                    Password = item.password
                };
                attendee.Add(temp);
            }

            db.Close();
            return attendee;
        }

        public Dictionary<string,object> GetValues(Attendees attendee)
        {
            var values = new Dictionary<string,object>()
            {
                {"@attendeeNum", attendee.AttendeeNum},
                {"@registrationNum",attendee.RegistrationNum},
                {"@username",attendee.Username},
                {"@password",attendee.Password}
            };

            return values;
        }

        public void Update(Attendees attendee)
        {
            throw new System.NotImplementedException();
        }


        public Attendees findAttendee(Attendees attendee)
        {
            db.Open();
            Attendees temp = new Attendees();
            string username = attendee.Username;
            string password =  attendee.Password;
            string sql = "select * from attendees WHERE username = @username AND password = @password";


            var values = GetValues(attendee);
            dynamic result = db.SelectOne(sql,values);

            

            
                temp = new Attendees(){
                    AttendeeNum = result.venNum,
                    RegistrationNum = result.registrationNum,
                    Username = result.username,
                    Password = result.password
                };
                
            
          
            
            db.Close();
            return temp;
            

        }
    }
}