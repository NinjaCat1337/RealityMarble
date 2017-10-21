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
        IEnumerable<UserPage> GetAll(Expression<Func<UserPage, bool>> where = null,
           Expression<Func<UserPage, decimal>> sortByDecimal = null,
           Expression<Func<UserPage, int>> sortByInt = null,
           bool ascending = true,
           int? skip = null,
           int? take = null);
    }
}
