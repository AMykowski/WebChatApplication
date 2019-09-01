using WebChat.Models;
using System.Data.Entity;

namespace WebChat.Repositories
{
    public class DbConnector
    {
        SimpleChatDbEntities context = null;

        /// <summary>
        /// Sets up the context
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
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
        ///  <remarks>Artur 01.09.2019</remarks>
        public Database Database
        {
            get { return context.Database; }
        }


        /// <summary>
        /// Constructor: sets context configuration
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
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
        ///  <remarks>Artur 01.09.2019</remarks>
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
        ///  <remarks>Artur 01.09.2019</remarks>
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

        /// <summary>
        /// Saves changes made to the database
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        public void Save()
        {
            context.SaveChanges();
        }

        
    }
}