using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnblockMe.Models;

namespace UnblockMe.Services
{
    public interface IUserService
    {
        AspNetUsers GetDetails(string id);
        IEnumerable<AspNetUsers> GetAll();
        void Update(AspNetUsers user);
        void Delete(string id);
        void PostRating(int rating, string mid);
    }
}
