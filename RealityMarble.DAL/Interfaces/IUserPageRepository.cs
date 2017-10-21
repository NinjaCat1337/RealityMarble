using RealityMarble.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.DAL.Interfaces
{
    
    public interface IUserPageRepository
    {
        UserPage Get(int id);
        UserPage GetByUserId(int id);
        void Create(UserPage item);
        void Update(UserPage item);
        void Delete(int id);
        IEnumerable<UserPage> GetAll();
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <param name="sortByDecimal">The sort by decimal.</param>
        /// <param name="sortByInt">The sort by int.</param>
        /// <param name="ascending">if set to <c>true</c> [ascending].</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns>IEnumerable&lt;UserPage&gt;.</returns>
        IEnumerable<UserPage> GetAll(Expression<Func<UserPage, bool>> where = null,
           Expression<Func<UserPage, decimal>> sortByDecimal = null,
           Expression<Func<UserPage, int>> sortByInt = null,
           bool ascending = true,
           int? skip = null,
           int? take = null);
    }
}
