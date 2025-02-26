using Microsoft.EntityFrameworkCore;
using Serilog;
using DecisionDeck.Models;
using DecisionDeck.Contracts;

namespace DecisionDeck.Repositories
{
    public class DecisionRepository<T>: IDecisionRepository<T> where T : class
    {
        public DecisionDeckContext _decisionDeckContext;
        protected DbSet<T> _dbSet;

        public DecisionRepository(DecisionDeckContext decisionDbContext)
        {
            _decisionDeckContext = decisionDbContext;
            _dbSet = decisionDbContext.Set<T>();
        }

        public T Add(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _decisionDeckContext.SaveChanges();

                return entity;

                Log.Information("Added " + typeof(T).Name);
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
                return null;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var entity = _dbSet.Find(id);

                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    _decisionDeckContext.SaveChanges();
                }

                Log.Information("Deleted " + typeof(T).Name);
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                Log.Information("All records for " + typeof(T).Name);
                return _dbSet.ToList();
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
                return Enumerable.Empty<T>();
            }
        }

        public T GetById(int id)
        {
            try
            {
                Log.Information("Found " + typeof(T).Name + "with id: " + id);
                return _dbSet.Find(id);
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
                return null;
            }
        }

        public void Update(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _decisionDeckContext.Entry(entity).State = EntityState.Modified;
                _decisionDeckContext.SaveChanges();

                Log.Information("Updated " + typeof(T).Name);
            }
            catch (Exception ex)
            {
                Log.Error("[{Level}] {Message}\n{Exception}", ex.GetHashCode, ex.Message, ex.StackTrace);
            }
        }
    }
}
