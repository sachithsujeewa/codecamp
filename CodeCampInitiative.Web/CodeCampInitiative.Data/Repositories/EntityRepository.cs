using CodeCampInitiative.Data.Data;
using CodeCampInitiative.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CodeCampInitiative.Data.Repositories
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntityBase
    {
        protected readonly CodeCampDbContext Context = null;
        protected readonly DbSet<T> Table = null;

        public EntityRepository()
        {
            this.Context = new CodeCampDbContext();
            Table = Context.Set<T>();
        }

        public EntityRepository(CodeCampDbContext context)
        {
            Context = context;
            Table = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public void Insert(T obj)
        {
            Table.Add(obj);
        }

        public void Update(T obj)
        {
            Table.Attach(obj);
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var existing = Table.Find(id);
            Table.Remove(existing ?? throw new InvalidOperationException());
        }

        public async Task SaveAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
