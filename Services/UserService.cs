using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using UnblockMe.Data;
using UnblockMe.Models;

namespace UnblockMe.Services
{
    public class UserService : IUserService
    {
        private readonly UnblockMeContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(UnblockMeContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public void Delete(string id)
        {
            //var userCar = _context.Car.Where(c => c.OwnerId == id);
            var userToDelete = _context.AspNetUsers.Find(id);
            _context.AspNetUsers.Remove(userToDelete);
            _context.SaveChanges();
        }

        public IEnumerable<AspNetUsers> GetAll()
        {
            var users = _context.AspNetUsers.Include(u => u.ratings).AsEnumerable();
            return users;
        }

        public AspNetUsers GetDetails(string id)
        {
            var user = _context.AspNetUsers.Include(user => user.Car).Where(u => u.Id == id).FirstOrDefault();
            return user;
        }

        public void Update(AspNetUsers user)
        {
            var userToUpdate = _context.AspNetUsers.Find(user.Id);
            if (userToUpdate != null)
            {
                userToUpdate.FirstName = user.FirstName;
                userToUpdate.LastName = user.LastName;
                userToUpdate.Email = user.Email;
                userToUpdate.PhoneNumber = user.PhoneNumber;
                userToUpdate.Car = user.Car;
                _context.SaveChanges();
            }

        }

        public void PostRating(int rating, string mid)
        {
            StarRating starRating = new StarRating();
            starRating.Rate = rating;
            starRating.AspNetUserId = mid;

            _context.StarRating.Add(starRating);

            _context.SaveChanges();

        }
    }
}
