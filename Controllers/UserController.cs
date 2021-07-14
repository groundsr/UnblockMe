using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using UnblockMe.Services;
using UnblockMe.Models;
using Microsoft.AspNetCore.Identity;

namespace UnblockMe.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<AspNetUsers> _userManager;


        public UserController(IUserService userService,UserManager<AspNetUsers> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        

        public IActionResult Index()
        {
            var users = _userService.GetAll();
            return View(users);
        }

        public IActionResult GetDetails(string id)
        {
            var user = _userService.GetDetails(id);
            return View(user);
        }

        [HttpPost]
        public JsonResult PostRating(int rating, string mid)
        {
            _userService.PostRating(rating, mid);
            return Json("You rated this user " + rating.ToString() + "star(s)");


        }

        [HttpPost]
        public IActionResult Update(AspNetUsers user)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            

            if(userId == user.Id)
            {
                _userService.Update(user);
            }
            else
            {
                throw new Exception("You cannot edit other users");
            }
           
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(string id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
