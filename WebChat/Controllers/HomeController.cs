using System.Collections.Generic;
using System.Web.Mvc;
using WebChat.Models;
using WebChat.Services;
using WebChat.ViewModels;

namespace WebChat.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Opens Index page
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Opens the MessageLogs page and displays all messages in table
        /// </summary>
        /// <returns></returns>
        public ActionResult MessageLogs()
        {

            List<ChatMessage> messages = HomeService.GetMessages();

            return View("MessageLogs", messages);
        }

        /// <summary>
        /// Opens Contact page
        /// </summary>
        /// <returns></returns>
        public ActionResult Contact()
        {

            return View();
        }

        /// <summary>
        /// Opens Lobby page, saves the currentUsername in session, calls the addUser method and displays Active users
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EnterLobby(string username)
        {
            if (username.Length == 0)
            return View("Index");

            Session["currentUser"] = username;
            bool userAdded = HomeService.AddUser(username);

            var activeUsers = HomeService.GetActiveUsers();


            return View("Lobby", activeUsers);
        }

        /// <summary>
        /// Opens the Chat page, sets up ConversationViewModel which stores both users in active chat keeping their roles (sender, receiver) and their previous conversation
        /// </summary>
        /// <param name="receiverUsername"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult StartChat(string receiverUsername)
        {

            string currentUser = Session["currentUser"] as string;

            List<ChatMessage> oldMessages = new List<ChatMessage>();

            oldMessages = HomeService.GetOldConversations(currentUser, receiverUsername);

            ConversationViewModel conversationVM = new ConversationViewModel();

            conversationVM.CurrentUser = currentUser;
            conversationVM.ReceiverUser = receiverUsername;
            conversationVM.OldMessages = oldMessages;

            return View("Chat", conversationVM);
        }


    }
}