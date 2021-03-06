﻿using RealityMarble.DAL.Entities;
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
    public class RatingRepository : IRepository<Rating>
    {
        private EntityDbContext _context { get; set; }

        public RatingRepository (EntityDbContext context)
        {
            _context = context;
        }

        public void Create(Rating item)
        {
            _context.Ratings.Add(item);
        }

        public void Delete(int id)
        {
            Rating item = _context.Ratings.Find(id);
            if (item != null)
            {
                _context.Ratings.Remove(item);
            }
        }

        public Rating Get(int id)
        {
            return _context.Ratings.Find(id);
        }

        public IEnumerable<Rating> GetAll()
        {
            return _context.Ratings;
        }

        public void Update(Rating item)
        {
            _context.Entry(item).State = EntityState.Modified;
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
        public IEnumerable<Rating> GetAll(
            Expression<Func<Rating, bool>> where = null,
            Expression<Func<Rating, decimal>> sortByDecimal = null,
            Expression<Func<Rating, int>> sortByInt = null,
            bool ascending = true,
            int? skip = null,
            int? take = null)
        {
            IQueryable<Rating> query = _context.Set<Rating>().AsQueryable();

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
