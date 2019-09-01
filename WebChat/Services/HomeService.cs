using System;
using System.Collections.Generic;
using System.Linq;
using WebChat.Models;
using WebChat.Repositories;

namespace WebChat.Services
{
    public class HomeService
    {
        /// <summary>
        /// Gets all the active users to display in the lobby
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <returns>List of Active Users</returns>
        public static List<User> GetActiveUsers()
        {
            List<User> users = new List<User>();

            try
            {
                DbConnector dc = new DbConnector();
                //Filter users that have Active status
                users = User.GetUsers(dc).Where(k => k.IsActive == true).ToList();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            return users;
        }

        /// <summary>
        /// Adds a new user to the user table if the given username isn't already taken
        /// </summary>
        /// <remarks>Artur 01.09.2019</remarks>
        /// <param name="username">The currenet user</param>
        /// <returns>If operation succeeded or no</returns>
        public static bool AddUser(string username)
        {
            try
            {
                //get db instance
                DbConnector dc = new DbConnector();

                // gets all users in db
                List<User> users = User.GetUsers(dc);

                
                //check if the username is already in db
                if (users.FirstOrDefault(k => k.Username == username) == null)
                {
                    //add the user to db
                    User addedUser = new User();

                    addedUser.UserId = users.Count;
                    addedUser.Username = username;
                    addedUser.IsActive = true;

                    dc.UserRepository.Insert(addedUser);
                    dc.Save();
                }

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        /// <summary>
        /// Gets the messages to display in the MessageLog
        /// </summary>
        /// <remarks>Artur 01.09.2019</remarks>
        /// <returns>List of messages</returns>
        public static List<ChatMessage> GetMessages()
        {

            try
            {
                DbConnector dc = new DbConnector();
                List<ChatMessage> messages = ChatMessage.GetMessages(dc);

                return messages;
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        /// <summary>
        /// Gets all the previous messages for two conversation participants
        /// </summary>
        /// <param name="currentUser">The Sender</param>
        /// <param name="receiverUser">The Receiver</param>
        /// <returns>List of precious chat messages for conversation</returns>
        public static List<ChatMessage> GetOldConversations(string currentUser, string receiverUser)
        {
            List<ChatMessage> oldMessages = new List<ChatMessage>();
            try
            {
                DbConnector dc = new DbConnector();
                oldMessages = ChatMessage.GetMessages(dc).Where(k => ((k.SenderUsername == currentUser && k.ReceiverUsername == receiverUser) || (k.SenderUsername == receiverUser && k.ReceiverUsername == currentUser))).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return oldMessages;
        }
    }
}