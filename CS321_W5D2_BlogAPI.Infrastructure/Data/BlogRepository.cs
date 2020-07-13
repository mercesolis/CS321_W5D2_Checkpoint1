using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _dbContext;

        public BlogRepository(AppDbContext dbContext) 
        {
            // TODO: inject AppDbContext
            _dbContext = dbContext;
        }

        public IEnumerable<Blog> GetAll()
        {
            // TODO: Retrieve all blgs. Include Blog.User.
            return _dbContext.Blogs
                .Include(b => b.User)
                .ToList();
        }

        public Blog Get(int id)
        {
            // TODO: Retrieve the blog by id. Include Blog.User.
            return _dbContext.Blogs
                .Include(b => b.User)
                .SingleOrDefault(b => b.Id == id);
        }

        public Blog Add(Blog blog)
        {
            // TODO: Add new blog
            _dbContext.Blogs.Add(blog);
            _dbContext.SaveChanges();
            return blog;
        }

        public Blog Update(Blog updatedItem)
        {
            // TODO: update blog
            

            var existingItem = _dbContext.Blogs.Find(updatedItem.Id);
            if (existingItem == null) return null;
            _dbContext.Entry(existingItem)
               .CurrentValues
               .SetValues(updatedItem);
            _dbContext.Blogs.Update(existingItem);
            _dbContext.SaveChanges();
            return existingItem;

            
        }

        public void Remove(int id)
        {
            // TODO: remove blog
            // retrieve the post that they're attempting to remove
            //var post = this.Get(id);
            //// make sure that the blog belongs to them before allowing the post to be removed
            //// NOTE: Blog has to be Include()-ed when getting the Post for this to work!
            //if (post.Blogs?.UserId != _userService.CurrentUserId)
            //{
            //    throw new ApplicationException("You can only modify blogs that belong to you.");
            //}
            //_dbContext.Remove(id);
        }
    }
}
