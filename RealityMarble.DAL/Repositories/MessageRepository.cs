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
    public class MessageRepository :IRepository<Message>
    {
        private EntityDbContext _context { get; set; }

        public MessageRepository(EntityDbContext context)
        {
            _context = context;
        }

        public void Create(Message item)
        {
            _context.Messages.Add(item);
        }

        public void Delete(int id)
        {
            Message item = _context.Messages.Find(id);
            if (item != null)
            {
                _context.Messages.Remove(item);
            }
        }

        public Message Get(int id)
        {
            return _context.Messages.Find(id);
        }

        public void Update(Message item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Messages;
        }
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
        public IEnumerable<Message> GetAll(
            Expression<Func<Message, bool>> where = null,
            Expression<Func<Message, decimal>> sortByDecimal = null,
            Expression<Func<Message, int>> sortByInt = null,
            bool ascending = true,
            int? skip = null,
            int? take = null)
        {
            IQueryable<Message> query = _context.Set<Message>().AsQueryable();

            if (where != null)
            {
                query = query.Where(where);
            }

            if (sortByDecimal != null)
            {
                query = ascending ? query.OrderBy(sortByDecimal) : query.OrderByDescending(sortByDecimal);
            }

            if (sortByInt != null)
            {
                query = ascending ? query.OrderBy(sortByInt) : query.OrderByDescending(sortByInt);
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
