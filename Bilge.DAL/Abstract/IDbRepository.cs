using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bilge.DAL.Abstract
{
    public interface IDbRepository<TEntity> where TEntity : class, new()
    {
        public void Insert(TEntity entity);
        public void Update(TEntity entity);

        public void Delete(TEntity entity);
        public void Delete(int id);


        public TEntity GetById(int id);

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

        public IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null,
            params Expression<Func<TEntity, object>>[] include);
    }
}
