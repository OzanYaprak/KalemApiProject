using DataAccessLayer.Contexts;
using System.Linq.Expressions;

namespace BusinessLayer.Repositories
{
    public class SQLRepository<T> : IRepository<T> where T : class
    {
        private readonly ApiProjectDB _apiProjectDB;

        public SQLRepository(ApiProjectDB apiProjectDB)
        {
            _apiProjectDB = apiProjectDB;
        }


        public void Add(T entity)
        {
            _apiProjectDB.Add(entity);
            _apiProjectDB.SaveChanges();
        }

        public void Delete(T entity)
        {
            _apiProjectDB.Remove(entity);
            _apiProjectDB.SaveChanges();
        }

        public void DeleteAll(IQueryable<T> entity)
        {
            _apiProjectDB.RemoveRange(entity);
            _apiProjectDB.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return _apiProjectDB.Set<T>();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _apiProjectDB.Set<T>().Where(expression);
        }

        public T GetBy(Expression<Func<T, bool>> expression)
        {
            return _apiProjectDB.Set<T>().FirstOrDefault(expression);
        }

        public T GetByID(int id)
        {
            return _apiProjectDB.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _apiProjectDB.Update(entity);
            _apiProjectDB.SaveChanges();
        }

    }
}