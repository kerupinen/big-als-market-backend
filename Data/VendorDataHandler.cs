using System.Collections.Generic;
using System.Dynamic;
using api.Interfaces;
using api.Models;

namespace api.Data
{
    public class VendorDataHandler : IVendorDataHandler
    {
        private Database db;

        public VendorDataHandler()
        {
            db = new Database();
        }

        public void Delete(Vendors vendor)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(Vendors vendor)
        {
            throw new System.NotImplementedException();
        }

        public List<Vendors> Select()
        {
            db.Open();
            string sql = "select * from vendors";
            List<ExpandoObject> result = db.Select(sql);

            List<Vendors> vendor = new List<Vendors>();
            foreach(dynamic item in result)
            {
                Vendors temp = new Vendors(){
                    VenNum = item.venNum,
                    RegisterSpot = item.RegisterSpot,
                    Username = item.username,
                    Password = item.password,
                    MerchType = item.merchType,
                    Image = item.images,
                    Description = item.description,
                    VendorName = item.venName
                };
                vendor.Add(temp);
            }

            //people.Add(new Person(){FirstName = "Jeff"});
            db.Close();
            return vendor;
        }

        public void Update(Vendors vendor)
        {
            throw new System.NotImplementedException();
        }

        //find vendor
        //return vendor
        public Vendors findVendor(Vendors vendor)
        {
            db.Open();
            string username = vendor.Username;
            string password =  vendor.Password;
            string sql = "select * from vendors WHERE username = @username AND password = @password";

            List<ExpandoObject> result = db.Select(sql);

            foreach(dynamic item in result)
            {
                Vendors temp = new Vendors(){
                    VenNum = item.venNum,
                    RegisterSpot = item.RegisterSpot,
                    Username = item.username,
                    Password = item.password,
                    MerchType = item.merchType,
                    Image = item.images,
                    Description = item.description,
                    VendorName = item.venName
                };
                return temp;
            }
            
          
              
            Vendors temps = new Vendors();
            db.Close();
            return temps;
            

        }
    }
}