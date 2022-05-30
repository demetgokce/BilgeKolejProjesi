using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Okul.BLManager.Abstract
{
    public interface IManager<TEntity>  where TEntity :class ,new()
    {
        void Add(TEntity model);
        void Update(TEntity model);
        void Delete(TEntity model);
        void Delete(int id);
        TEntity Find(int id);
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter);
        IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null,
                                   params Expression<Func<TEntity, object>>[] include);

    }
}
