using CodeCampInitiative.Data.Data;
using CodeCampInitiative.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

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

        public IEnumerable<T> GetAll()
        {
            return _table.ToList();
        }

        public T GetById(object id)
        {
            return _table.Find(id);
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

        public void Delete(object id)
        {
            var existing = _table.Find(id);
            _table.Remove(existing ?? throw new InvalidOperationException());
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
