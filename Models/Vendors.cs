using System;
using api.Interfaces;

namespace api.Models
{
    public class Vendors
    {
        public int VenNum {get; set;}

        public string VendorName {get; set;}
        public int RegisterSpot {get;set;}

        public string Username{get; set;}
        public string Password {get; set;}
        public string MerchType {get;set;}

        public string Image {get;set;}

        public string Description {get; set;}

        public IVendorDataHandler vendorHandler {get; set;}

    }
}