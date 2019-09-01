using WebChat.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebChat.Repositories
{
    public class DbConnector
    {
        SimpleChatDbEntities context = null;

        /// <summary>
        /// Sets up the context
        /// </summary>
        public SimpleChatDbEntities DbContext
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Retrieves the Database
        /// </summary>
        public Database Database
        {
            get { return context.Database; }
        }


        /// <summary>
        /// Constructor: sets context configuration
        /// </summary>
        public DbConnector()
        {
            context = new SimpleChatDbEntities();
            context.Configuration.ProxyCreationEnabled = true;
            context.Configuration.LazyLoadingEnabled = false;
        }

        #region Repositories & declarations

        //Declare repositories
        GenericRepository<User> userRepository;
        GenericRepository<ChatMessage> chatMessageRepository;

        /// <summary>
        /// Sets up User repository
        /// </summary>
        public GenericRepository<User> UserRepository
        {
            get
            {
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }

        /// <summary>
        /// Sets up ChatMessage repository
        /// </summary>
        public GenericRepository<ChatMessage> ChatMessageRepository
        {
            get
            {
                if (this.chatMessageRepository == null)
                {
                    this.chatMessageRepository = new GenericRepository<ChatMessage>(context);
                }
                return chatMessageRepository;
            }
        }


        #endregion

        #region Save /*& Dispose*/

        /// <summary>
        /// Saves changes made to the database
        /// </summary>
        public void Save()
        {
            context.SaveChanges();
        }

        //private bool disposed = false;

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            context.Dispose();
        //        }
        //    }
        //    this.disposed = true;
        //}

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}


        #endregion
    }
}