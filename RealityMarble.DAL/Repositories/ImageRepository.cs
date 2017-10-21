using RealityMarble.DAL.Entities;
using RealityMarble.DAL.Essence;
using RealityMarble.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace RealityMarble.DAL.Repositories
{
    public class ImageRepository : IRepository<Image>
    {
        private EntityDbContext _context { get; set; }

        public ImageRepository(EntityDbContext context)
        {
            _context = context;
        }

        public void Create(Image item)
        {
            _context.Images.Add(item);
        }

        public void Delete(int id)
        {
            Image item = _context.Images.Find(id);
            if (item != null)
            {
                _context.Images.Remove(item);
            }
        }

        public Image Get(int id)
        {
            return _context.Images.Find(id);
        }

        public void Update(Image item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<Image> GetAll()
        {
            return _context.Images;
        }
        public IEnumerable<Image> GetAll(
            Expression<Func<Image, bool>> where = null,
            Expression<Func<Image, decimal>> sortByDecimal = null,
            Expression<Func<Image, int>> sortByInt = null,
            bool ascending = true,
            int? skip = null,
            int? take = null)
        {
            IQueryable<Image> query = _context.Set<Image>().AsQueryable();

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
