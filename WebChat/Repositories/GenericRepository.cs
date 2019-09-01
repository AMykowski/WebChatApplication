using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace WebChat.Repositories
{
    public class GenericRepository<TEntity> where TEntity : class
    {

        //context and dbSet declared as internal to keep to O of SOLID principles if in future the Assembly should have added Projects
        internal DbContext context;
        internal DbSet<TEntity> dbSet;

        /// <summary>
        /// Constructor: set up the context
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <param name="context">The context</param>
        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        /// <summary>
        /// Generic Get to db method
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = dbSet;

            return query.ToList();

        }

        /// <summary>
        /// Generic Insert to db method
        /// </summary>
        ///  <remarks>Artur 01.09.2019</remarks>
        /// <param name="entity">Passed entity</param>
        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        
    }
}