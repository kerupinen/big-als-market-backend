using System.Collections.Generic;
using api.Models;
namespace api.Interfaces
{
    public interface IVendorDataHandler
    {
         public List<Vendors> Select();
         public void Delete(Vendors vendor);
         public void Update(Vendors vendor);
         public void Insert(Vendors vendor);
        // public Vendors findVendor(Vendors vendor);
    }
}