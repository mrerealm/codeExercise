using CodingExercise.Models;
using CodingExercise.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodingExercise.Controllers
{
    public class HomeController : Controller
    {
        public HomeController() { }

        public ActionResult Index()
        {
            var model = new HomeViewModel { Message = "Loading Json data ..." };
            try
            {
                var meetingService = new MeetingService();
                var meetings = meetingService.Get();
                model.Message = $"Found {meetings.Count()} meetings.";

                var meetingStored = meetingService.AddOrUpdate(meetings);
                // not comitted to db

                model.Message += $"Stored {meetingStored.Count()} meetings.";

            }
            catch (Exception ex)
            {
                model.Message = ex.Message;
            }

            return View(model);
        }

    }
}