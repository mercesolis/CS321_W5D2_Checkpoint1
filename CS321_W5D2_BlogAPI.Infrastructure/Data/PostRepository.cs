using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _dbContext;

        public PostRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Post Get(int id)
        {
            // TODO: Implement Get(id). Include related Blog and Blog.User
            return _dbContext.Posts
                .Include(p => p.BlogId)
                .Include(p => p.Blog.User)
                .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            // TODO: Implement GetBlogPosts, return all posts for given blog id

            // TODO: Include related Blog and AppUser
            
        }

        public Post Add(Post Post)
        {
            // TODO: add Post
            throw new NotImplementedException();
        }

        public Post Update(Post Post)
        {
            // TODO: update Post
            var 
        }

        public IEnumerable<Post> GetAll()
        {
            // TODO: get all posts
            return _dbContext.Posts
                .Include(p => p.Blog.Posts)
                .Include(p => p.Blog.User)
                .ToList();
        }

        public void Remove(int id)
        {
            // TODO: remove Post
            throw new NotImplementedException();
        }

    }
}
