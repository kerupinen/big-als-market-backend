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
        //Adds new attendee into database, given the attendee's info
        public void Insert(Attendees attendee)
        {
            db.Open();
            int registrationNum = attendee.RegistrationNum;
            string username = attendee.Username;
            string password = attendee.Password;
            string firstName = attendee.FirstName;
            string lastName = attendee.LastName;
            string sql = "INSERT INTO attendees (registrationNum, username, password, firstName, lastName) ";
            sql+= "VALUES (@registrationNum,@username,@password,@firstName,@lastName);";

            var values = GetValues(attendee);
            db.Insert(sql,values);
            db.Close();
        }
        //returns list of attendees from database
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
                    Password = item.password,
                    FirstName = item.firstName,
                    LastName = item.lastName
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
                {"@password",attendee.Password},
                {"@firstName",attendee.FirstName},
                {"@lastName",attendee.LastName}
            };

            return values;
        }
        //Updates the registration number to one that has not been assigned yet
        public void Update(Attendees attendee)
        {
            int RegistrationNum = attendee.RegistrationNum;
            int attendeeNum = attendee.AttendeeNum;
            string sql = "UPDATE attendees SET RegistrationNum=@RegistrationNum WHERE attendeeNum=@attendeeNum;";
            var values = GetValues(attendee);
            db.Open();
            db.Insert(sql,values);
            db.Close();
        }
        //returns the number of attendees 
        public int CountAttendees()
        {
            db.Open();
            string sql = "select count(*) from attendees";
            int count = db.Count(sql);
            db.Close();
            return count;
        }

        //finding the one attendee that matches given username and password
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
                    AttendeeNum = result.attendeeNum,
                    RegistrationNum = result.registrationNum,
                    Username = result.username,
                    Password = result.password,
                    FirstName = result.firstName,
                    LastName = result.lastName
                };

            db.Close();
            return temp;
        }
        //Finds attendee by ID, then calls to update the registration spot if not already given one
        public Attendees findAttendeeById(Attendees attendee)
        {
            int attendeeNum = attendee.AttendeeNum;
            string sql = "select * from attendees WHERE attendeeNum = @attendeeNum";

            var values = GetValues(attendee);
            db.Open();
            dynamic result = db.SelectOne(sql,values);
            db.Close();

            Attendees temp = new Attendees(){
                    AttendeeNum = result.attendeeNum,
                    RegistrationNum = result.registrationNum,
                    Username = result.username,
                    Password = result.password,
                    FirstName = result.firstName,
                    LastName = result.lastName
                };

            if(temp.RegistrationNum == 0)
            {
                sql = "SELECT MAX(RegistrationNum) as RegistrationNum FROM attendees";
                db.Open();
                dynamic result2 = db.SelectOne(sql,values);
                db.Close();

                int counter = result2.RegistrationNum;
                if (counter < 100) {
                    temp.RegistrationNum = counter+1;
                    this.Update(temp);
                }
            }
            return temp;
        }
    }
}