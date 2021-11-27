using System.Collections.Generic;
using System.Dynamic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class AdminDataHandler : IAdminDataHandler
    {
        private Database db;

        public AdminDataHandler()
        {
            db = new Database();
        }
        public void Delete(Admins admin)
        {
            throw new System.NotImplementedException();
        }

        public Admins findAdmin(Admins admin)
        {
            //throw new System.NotImplementedException();
            db.Open();
            string username = admin.Username;
            string password =  admin.Password;
            Admins temp = new Admins();
            string sql = "select * from admins WHERE username = @username AND password = @password";


            var values = GetValues(admin);
            dynamic result = db.SelectOne(sql,values);

            

            
                temp = new Admins(){
                    AdminNum = result.adminNum,
                    Username = result.username,
                    Password = result.password
                };
                
            
          
            
            db.Close();
            return temp;
        }

        public void Insert(Admins admin)
        {
            db.Open();
            string username = admin.Username;
            string password = admin.Password;
            string sql = "INSERT INTO admins (username, password) ";
            sql+= "VALUES (@username,@password);";

            var values = GetValues(admin);
            db.Insert(sql,values);
            db.Close();
        }

        public Dictionary<string,object> GetValues(Admins admin)
        {
            var values = new Dictionary<string,object>()
            {
                {"@adminNum", admin.AdminNum},
                {"@username",admin.Username},
                {"@password",admin.Password}
            };

            return values;
        }

        public List<Admins> Select()
        {
            //throw new System.NotImplementedException();
            db.Open();
            string sql = "select * from admins";
            List<ExpandoObject> result = db.Select(sql);

            List<Admins> admin = new List<Admins>();
            foreach(dynamic item in result)
            {
                Admins temp = new Admins(){
                    AdminNum = item.adminNum,
                    Username = item.username,
                    Password = item.password
                };
                admin.Add(temp);
            }

            db.Close();
            return admin;
        }

        public void Update(Admins admin)
        {
            throw new System.NotImplementedException();
        }
    }
}