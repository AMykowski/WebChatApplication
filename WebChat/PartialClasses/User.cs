using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebChat.Repositories;

namespace WebChat.Models
{
    public partial class User
    {
        /// <summary>
        /// Gets all the users direclty from db
        /// </summary>
        /// <param name="dc"></param>
        /// <returns></returns>
        public static List<User> GetUsers(DbConnector dc)
        {
            return dc.UserRepository.Get().ToList();
        }
    }
}