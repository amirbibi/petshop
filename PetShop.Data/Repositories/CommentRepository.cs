using Microsoft.EntityFrameworkCore;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Data.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly PetShopDbContext _context;

        public CommentRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Comment>> GetCommentsForAnimalAsync(int animalId)
        {
            var comments = from comment in _context.Comments
                           join animal in _context.Animals on comment.AnimalId equals animal.AnimalId
                           where animal.AnimalId == animalId
                           select comment;

            return await comments.ToListAsync();
        }
     
        public async Task AddCommentAsync(Comment comment)
        {
            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCommentAsync(Comment comment)
        {
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _context.Comments.SingleAsync(c => c.Id == commentId);
        }

        public async Task EditCommentAsync(Comment updatedComment)
        {
            var commentInDb = await GetCommentByIdAsync(updatedComment.Id);
            commentInDb.Content = updatedComment.Content;

            await _context.SaveChangesAsync();
        }
    }
}
