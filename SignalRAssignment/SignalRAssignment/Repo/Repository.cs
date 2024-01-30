using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;

namespace SignalRAssignment.Repo
{
    public class Repository <T> where T : class
    {
        ApplicationDBContext _context;
        DbSet<T> _dbset;

        public Repository()
        {
            _context = new ApplicationDBContext();
            _dbset = _context.Set<T>();
        }
        public List<T> GetAll()
        {
            return _dbset.ToList();
        }

        public virtual void Create(T entity)
        {
            _dbset.Add(entity);
            _context.SaveChanges();
        }

        public bool Delete(T entity)
        {
            _dbset.Remove(entity);
            _context.SaveChanges();
            return true;
        }
        public void Update(T entity)
        {
            var tracker = _context.Attach(entity);
            tracker.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
