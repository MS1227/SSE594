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
        private static Server.User currUser;
        private static Server.ChatRoom currRoom;
       
        public IActionResult Index()
        {
            if(chatServer == null)
            {
                chatServer = new Server.Server();
            }
            return View(chatServer);
        }
        [HttpPost]
        public ActionResult createUser(string name)
        {
            
            if (chatServer.addUser(name))
            {
                currUser = chatServer.getUser(name);
                ViewData["Users"] = chatServer.listCurrUsers();
                ViewData["Rooms"] = chatServer.listCurrRooms();
                ViewData["currUser"] = currUser;
                ViewData["Rooms"] = chatServer.listCurrRooms();
                return View("Lobby", chatServer);
            }
            else
            {
                TempData["msg"] = "<script>alert('Username Taken, please choose another');</script>";
                return View("Index");
            }
            
        }
        
        public ActionResult joinRoom(string name )
        {
            currRoom = chatServer.getChatRoom(name);
            currRoom.addUser(currUser);
            ViewData["RoomData"] = currRoom;
            ViewData["Message"] = currRoom.getMessageList();
            return View("chatRoom",chatServer);       
        }
        [HttpPost]
        public ActionResult sendMessage(string message)
        {
            currRoom.addMessage(currUser, message);
            ViewData["Message"] = currRoom.getMessageList();
            return View("chatRoom", chatServer);
        }
        [HttpPost]

        [HttpPost]
        public ActionResult exitRoom()
        {
            ViewData["Users"] = chatServer.listCurrUsers();
            ViewData["Rooms"] = chatServer.listCurrRooms();
            ViewData["currUser"] = currUser;
            ViewData["Rooms"] = chatServer.listCurrRooms();
            return View("Lobby", chatServer);
        }
        public ActionResult createChatRoom(string name)
        {
            
            if (chatServer.createChatRoom(name))
            {
               
                ViewData["Users"] = chatServer.listCurrUsers();
                ViewData["Rooms"] = chatServer.listCurrRooms();
                ViewData["currUser"] = currUser;
                ViewData["Rooms"] = chatServer.listCurrRooms();
                return View("Lobby", chatServer);
            }
            else
            {
                ViewData["Users"] = chatServer.listCurrUsers();
                ViewData["Rooms"] = chatServer.listCurrRooms();
                ViewData["currUser"] = currUser;
                ViewData["Rooms"] = chatServer.listCurrRooms();
                TempData["msg"] = "<script>alert('Chatroom name Taken, please choose another');</script>";
                return View("Lobby",chatServer);
            }
        }
        public IActionResult Lobby()
        {
            ViewData["Users"] = chatServer.listCurrUsers();
            ViewData["Rooms"] = chatServer.listCurrRooms();
            ViewData["currUser"] = currUser;

            return View(chatServer);
        }

        public IActionResult ChatRoom()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
