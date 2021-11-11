using System.Collections.Generic;
using System.Dynamic;
using api.Models;

namespace api.Data
{
    public class VendorDataHandler
    {
        private Database db;

        public VendorDataHandler()
        {
            db = new Database();
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
                    VenNum = item.id,
                    RegisterSpot = item.RegisterSpot,
                    Username = item.username,
                    Password = item.password,
                    MerchType = item.merchType,
                    Image = item.images
                };
                vendor.Add(temp);
            }

            //people.Add(new Person(){FirstName = "Jeff"});
            db.Close();
            return vendor;
        }


    }
}