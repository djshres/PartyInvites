using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        private readonly PartyInvitesContext _context;

        public HomeController(PartyInvitesContext context)
        {
            _context = context;
        }
        public ViewResult Index()
        {
            //int hour = DateTime.Now.Hour;
            //ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }

        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if(ModelState.IsValid)
            {
                //Repository.AddResponse(guestResponse);
                _context.Add(guestResponse);
                _context.SaveChanges();
                return View("Thanks", guestResponse);
            }
            else
            {
                //there is a validation error
                return View();
            }
          
        }

        [HttpGet]
        public ViewResult ListResponses()
        {
            //return View(Repository.Responses.Where(r => r.WillAttend == true));
            return View(_context.GuestResponses.Where(w => w.WillAttend == true));
         
        }
    }
}
