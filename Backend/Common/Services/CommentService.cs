using System.Collections.Generic;
using System.Threading.Tasks;
using Common.Models.ShopModels;
using Microsoft.EntityFrameworkCore;

namespace Common.Services
{
    public class CommentService
    {
        private readonly AppDbContext _context;
        public CommentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Comment> GetById(int id)
        {
            var result = await _context.Comments
                .AsQueryable()
                .SingleAsync(c => c.Id == id);

            return result;
        }

        public async Task<Comment> Delete(int id)
        {
            var commentDb = await GetById(id);
            await _context.SaveChangesAsync();

            return commentDb;
        }

        public async Task<Comment> Add(Comment comment)
        {
            comment.Content = comment.Content.Trim();   // czy tutaj tylko to?
            await _context.Comments.AddAsync(comment);
            await _context.SaveChangesAsync();
            return comment;
        }

        public async Task<List<Comment>> GetAll()
        {
            return await _context.Comments
                .AsQueryable()
                .ToListAsync();
        }

        public async Task<Comment> Update(Comment updatedComment)
        {
            var oldComment = await GetById(updatedComment.Id);
            oldComment.Content = updatedComment.Content.Trim();
            
            await _context.SaveChangesAsync();
            return oldComment;
        }
    }
}
