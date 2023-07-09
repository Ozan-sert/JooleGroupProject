﻿using JooleGroupProject.ServiceLayer.Models;
using JooleGroupProject.ServiceLayer.Services;
using JooleGroupProject.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper; 

namespace JooleGroupProject.UI.Controllers
{
    public class UserController : Controller
    {
        UserService myservice = new UserService();

        private readonly IMapper _mapper;

        public UserController() {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RegisterViewModel, UserDTO>()
                    .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password)); // Mapping Password
            });
            _mapper = config.CreateMapper(); 
        }

        // GET: User
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(LoginViewModel loginUser)
        {
            if (ModelState.IsValid)
            {
                UserDTO user = myservice.Login(loginUser.UsernameOrEmail, loginUser.Password);

                if (user == null)
                {
                    // If login is not successful, redirect to a different action or view
                    // For example, you can redirect to a "LoginFailed" action or view
                    return View();
                }

                // If login is successful, you can redirect to another action or view
                return RedirectToAction("Index", "Search"); // Redirect to Search/Index
            }

            return View();
        }

        public ActionResult Signup() 
        {
            return View();
        }

        // Post: User
        [HttpPost]
        public ActionResult Submit(RegisterViewModel registerUser)
        {
            if (ModelState.IsValid)
            {
                UserDTO userDTO = _mapper.Map<UserDTO>(registerUser); 
                // The submitted data is valid, you can process it here
                // For example, save it to the database, send an email, etc.
                myservice.RegisterUser(userDTO);
                // After successful processing, you might want to redirect to a success page
                return RedirectToAction("Login", "User");
            }
            else
            {
                // The submitted data is not valid, so return the user back to the form with errors
                return View("Signup"); // Replace "YourFormViewName" with the actual name of your form view
            }
            //return View();
        }

    }
}