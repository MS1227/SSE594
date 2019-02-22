using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatRoom.Models;

namespace ChatRoom.Controllers
{
    public class HomeController : Controller
    {
        static Server.Server chatServer;
        public IActionResult Index()
        {
            if(chatServer == null)
            {
                chatServer = new Server.Server();
            }
            return View(chatServer);
        }
        public void createUser(string name)
        {
            Server.User user = new Server.User(name);
        }
        public IActionResult Lobby()
        {
            ViewData["Message"] = "Your application description page.";

            return View(chatServer);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
