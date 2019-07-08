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
        private readonly CodeCampDbContext _context = null;
        private readonly DbSet<T> _table = null;

        public EntityRepository()
        {
            this._context = new CodeCampDbContext();
            _table = _context.Set<T>();
        }

        public EntityRepository(CodeCampDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public void Insert(T obj)
        {
            _table.Add(obj);
        }

        public void Update(T obj)
        {
            _table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var existing = _table.Find(id);
            _table.Remove(existing ?? throw new InvalidOperationException());
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
