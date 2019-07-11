namespace CodeCampInitiative.Data.Repositories
{
    using Data;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Threading.Tasks;

    /// <summary>
    /// Generic repository for access database context
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="CodeCampInitiative.Data.Interfaces.IEntityRepository{T}" />
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntityBase
    {
        /// <summary>
        /// The context
        /// </summary>
        protected readonly CodeCampDbContext Context = null;

        /// <summary>
        /// The table represent a table in database
        /// </summary>
        protected readonly DbSet<T> Table = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRepository{T}"/> class.
        /// </summary>
        public EntityRepository()
        {
            Context = new CodeCampDbContext();
            Table = Context.Set<T>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EntityRepository{T}"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        public EntityRepository(CodeCampDbContext context)
        {
            Context = context;
            Table = context.Set<T>();
        }

        /// <summary>
        /// Gets all asynchronous.
        /// </summary>
        /// <returns>list of T where T is given entity</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        /// <summary>
        /// Gets the by identifier asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>object of type T where T is given entity</returns>
        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        /// <summary>
        /// Inserts the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void Insert(T obj)
        {
            Table.Add(obj);
        }

        /// <summary>
        /// Updates the specified object.
        /// </summary>
        /// <param name="obj">The object.</param>
        public void Update(T obj)
        {
            Table.Attach(obj);
            Context.Entry(obj).State = EntityState.Modified;
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="InvalidOperationException"></exception>
        public void Delete(int id)
        {
            var existing = Table.Find(id);
            Table.Remove(existing ?? throw new InvalidOperationException());
        }

        /// <summary>
        /// Saves the asynchronous.
        /// </summary>
        /// <returns>void</returns>
        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
