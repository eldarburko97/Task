using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;
using WebAPI.Requests;

namespace WebAPI.Services
{
   public interface IConstituencyService
    {
        Constituency GetByName(string name);
        Constituency Insert(ConstituencyInsertRequest request);
        List<Constituency> GetAll();
    }
}
