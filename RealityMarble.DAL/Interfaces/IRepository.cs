using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealityMarble.DAL.Entities;
using System.Linq.Expressions;

namespace RealityMarble.DAL.Interfaces
{
    public interface IRepository<T> where T: class
    {
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> exp, Expression<Func<T, object>> obj, bool ascending, int? skip, int?take);
    }
}
