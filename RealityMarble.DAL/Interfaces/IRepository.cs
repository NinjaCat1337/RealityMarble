using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RealityMarble.DAL.Entities;
using System.Linq.Expressions;

namespace RealityMarble.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        IEnumerable<T> GetAll();
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByDecimal">The sort by decimal.</param>
        /// <param name="sortByInt">The sort by int.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns>IEnumerable&lt;T&gt;.</returns>
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where = null,
            Expression<Func<T, decimal>> sortByDecimal = null,
            Expression<Func<T, int>> sortByInt = null,
            bool ascending = true,
            int? skip = null,
            int? take = null);
    }
}
