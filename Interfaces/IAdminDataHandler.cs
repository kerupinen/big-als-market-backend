using System.Collections.Generic;
using api.Models;

namespace api.Interfaces
{
    public interface IAdminDataHandler
    {
         public List<Admins> Select();
         public void Insert(Admins admin);
         public Admins findAdmin(Admins admin);
    }
}