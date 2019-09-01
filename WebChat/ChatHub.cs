using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.AspNet.SignalR;
using WebChat.Helpers;
using WebChat.Models;
using WebChat.ViewModels;

namespace WebChat
{
    public class ChatHub : Hub
    {
        //Creates an instance of Logger
        private Logger logger = new Logger();

        /// <summary>
        /// Gets the message and usernames of chat participants and adds message to page using SignalR
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <param name="currentUser">The Sender</param>
        /// <param name="receiverUser"> The Receiver</param>
        /// <param name="message">The message</param>
        public void Send(string currentUser, string receiverUser, string message)
        {

            if (!String.IsNullOrEmpty(message))
            {
                Clients.All.addNewMessageToPage(currentUser, message);
                logger.Message(message, currentUser, receiverUser);
            }
            
        }

       
    }
}