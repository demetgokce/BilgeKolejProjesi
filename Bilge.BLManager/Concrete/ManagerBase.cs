using Okul.BLManager.Abstract;
using Okul.DAL.Abstract;
using Okul.DAL.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Okul.BLManager.Concrete
{
    public class ManagerBase<TEntity> :IManager<TEntity> where TEntity :class,new()
    {

        protected IOkulDbRepository<TEntity> db;
        public ManagerBase()
        {
            db = new OkulDbRepository<TEntity>();
        }

        public void Add(TEntity model)
        {
            db.Insert(model);

        }

        public void Delete(TEntity model)
        {
            db.Delete(model);
        }

        public void Delete(int id)
        {
            db.Delete(id);
        }

        public TEntity Find(int id)
        {
            return db.GetById(id);
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter)
        {
            return db.GetAll(filter);
        }

        public void Update(TEntity model)
        {
             db.Update(model);
        }

        public IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include)
        {
            return db.GetAllInclude(filter, include);
        }

    }
}
