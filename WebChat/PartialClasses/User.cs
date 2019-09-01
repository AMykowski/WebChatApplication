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
        /// <remarks>Artur 01.09.2019</remarks>
        /// <param name="dc">DbConnector</param>
        /// <returns></returns>
        public static List<User> GetUsers(DbConnector dc)
        {
            return dc.UserRepository.Get().ToList();
        }
    }
}