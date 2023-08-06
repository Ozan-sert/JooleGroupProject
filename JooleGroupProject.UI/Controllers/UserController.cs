using JooleGroupProject.ServiceLayer.Models;
using JooleGroupProject.ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JooleGroupProject.UI.Controllers
{
    public class UserController : Controller
    {
        UserService myservice = new UserService();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Signup() 
        {
            return View();
        }

        // Post: User
        [HttpPost]
        public ActionResult Submit(UserDTO user)
        {

            if (ModelState.IsValid)
            {

                // The submitted data is valid, you can process it here
                // For example, save it to the database, send an email, etc.
                myservice.RegisterUser(user);
                // After successful processing, you might want to redirect to a success page
                return RedirectToAction("Login");
            }
            else
            {
                // The submitted data is not valid, so return the user back to the form with errors
                return View("Signup"); // Replace "YourFormViewName" with the actual name of your form view
            }
            //return View();
        }
        
        public ActionResult Login()
        {
            UserDTO newUser = new UserDTO();
           
            return View(newUser);
        }


        [HttpPost]
        public ActionResult Login(UserDTO user)
        {
            UserDTO newuser = myservice.Login(user);

            if ( newuser == null)
            {
                // If login is not successful, redirect to a different action or view
                // For example, you can redirect to a "LoginFailed" action or view
                return RedirectToAction("Index");
            }

            // If login is successful, you can redirect to another action or view
            return RedirectToAction("Index", "Home"); // Redirect to Home/Index
        }
    }
}