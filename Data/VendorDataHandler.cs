using System.Security.Principal;
using System.Linq;
using System;
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


        public void Insert(Vendors vendor)
        {
            db.Open();
            int registerSpot = vendor.RegisterSpot;
            string username = vendor.Username;
            string password = vendor.Password;
            string merchType = vendor.MerchType;
            string images = vendor.Image;
            string venName = vendor.VendorName;
            string description = vendor.Description;
            string sql = "INSERT INTO vendors (registerSpot, username, password, merchType, images, description, venName) ";
            sql+= "VALUES (@RegisterSpot,@username,@password,@merchType,@images,@description,@venName);";

            var values = GetValues(vendor);
            db.Insert(sql,values);
            db.Close();
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
                    Image = item.images.Equals(System.DBNull.Value) ? "" : item.images,
                    Description = item.description,
                    VendorName = item.venName
                };
                vendor.Add(temp);
            }

            //people.Add(new Person(){FirstName = "Jeff"});
            db.Close();
            return vendor;
        }

        public int CountVendors()
        {
            db.Open();
            string sql = "select count(*) from vendors";
            int count = db.Count(sql);
            db.Close();
            return count;
        }

        public void Update(Vendors vendor)
        {
            //int RegisterSpot = vendor.RegisterSpot;
            string merchType = vendor.MerchType;
            string images = vendor.Image;
            string description = vendor.Description;
            string venName = vendor.VendorName;
            string sql = "UPDATE vendors SET merchType=@merchType,images=@images,description=@description,venName = @venName WHERE venNum=@venNum;";

            var values = GetValues(vendor);
            db.Open();
            db.Insert(sql,values);
            db.Close();
        }

        public void UpdateRegister(Vendors vendor)
        {
            int RegisterSpot = vendor.RegisterSpot;
            int venNum = vendor.VenNum;
            string sql = "UPDATE vendors SET RegisterSpot=@RegisterSpot WHERE venNum=@venNum;";
            var values = GetValues(vendor);
            db.Open();
            db.Insert(sql,values);
            db.Close();

        }

        public Dictionary<string,object> GetValues(Vendors vendor)
        {
            var values = new Dictionary<string,object>()
            {
                {"@venNum", vendor.VenNum},
                {"@registerSpot",vendor.RegisterSpot},
                {"@username",vendor.Username},
                {"@password",vendor.Password},
                {"@merchType", vendor.MerchType},
                {"@images", vendor.Image},
                {"@description",vendor.Description},
                {"@venName", vendor.VendorName}
            };

            return values;
        }

        //find vendor
        //return vendor
        public Vendors findVendor(Vendors vendor)
        {
            db.Open();
            Vendors temp = new Vendors();
            string username = vendor.Username;
            string password =  vendor.Password;
            string sql = "select * from vendors WHERE username = @username AND password = @password";

            var values = GetValues(vendor);
            dynamic result = db.SelectOne(sql,values);

            temp = new Vendors(){
                VenNum = result.venNum,
                RegisterSpot = result.RegisterSpot,
                Username = result.username,
                Password = result.password,
                MerchType = result.merchType,
                Image = result.images.Equals(System.DBNull.Value) ? "" : result.images,
                Description = result.description,
                VendorName = result.venName
            };

            db.Close();
            return temp;
        }

        public Vendors findVendorById(Vendors vendor)
        {
            int venNum = vendor.VenNum;
            string sql = "select * from vendors WHERE venNum = @venNum";

            db.Open();
            var values = GetValues(vendor);
            dynamic result = db.SelectOne(sql,values);
            db.Close();

            Vendors temp = new Vendors(){
                VenNum = result.venNum,
                RegisterSpot = result.RegisterSpot,
                Username = result.username,
                Password = result.password,
                MerchType = result.merchType,
                Image = result.images.Equals(System.DBNull.Value) ? "" : result.images,
                Description = result.description,
                VendorName = result.venName
            };

            if(temp.RegisterSpot == 0)
            {
                db.Open();
                sql = "SELECT MAX(RegisterSpot) as RegisterSpot FROM vendors";
                //values = GetValues(vendor);
                dynamic result2 = db.SelectOne(sql,values);
                db.Close();
                int counter = result2.RegisterSpot;
                if (counter < 30) {
                    temp.RegisterSpot = counter+1;
                    this.UpdateRegister(temp);
                }
            }

            return temp;
        }
    }
}