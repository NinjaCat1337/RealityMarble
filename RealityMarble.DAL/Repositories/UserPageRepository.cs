using RealityMarble.DAL.Entities;
using RealityMarble.DAL.Essence;
using RealityMarble.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RealityMarble.DAL.Repositories
{
    public class UserPageRepository : IRepository<UserPage>
    {
        private EntityDbContext _context;

        public UserPageRepository (EntityDbContext context)
        {
            _context = context;
        }
        public void Create(UserPage item)
        {
            _context.UserPages.Add(item);
        }

        public void Delete(int id)
        {
            UserPage item = _context.UserPages.Find(id);
            if (item != null)
            {
                _context.UserPages.Remove(item);
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public UserPage Get(int id)
        {
            return _context.UserPages.Find(id);
        }

        public IEnumerable<UserPage> GetAll()
        {
            return _context.UserPages;
        }

        public void Update(UserPage item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<UserPage> GetAll(
            Expression<Func<UserPage, bool>> where = null,
            Expression<Func<UserPage, object>> sortBy = null,
            bool ascending = true,
            int? skip = null,
            int? take = null)
        {
            IQueryable<UserPage> query = _context.Set<UserPage>().AsQueryable();

            if (where != null)
            {
                query = query.Where(where);
            }

            if (sortBy != null)
            {
                query = ascending ? query.OrderBy(sortBy) : query.OrderByDescending(sortBy);
            }

            if (skip != null)
            {
                query = query.Skip(skip.Value);
            }

            if (take != null)
            {
                query = query.Take(take.Value);
            }

            return query.ToList();
        }
    }
}
