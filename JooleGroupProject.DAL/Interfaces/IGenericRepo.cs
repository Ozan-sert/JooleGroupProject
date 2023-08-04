using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JooleGroupProject.DAL.Interfaces
{
    public interface IGenericRepo<TEntity> where TEntity : class
    {
        TEntity GetByID(int id);

        void Insert(TEntity entity);

        void Delete(TEntity entity);

        void Update(TEntity entity);

        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> where);
    }
}
