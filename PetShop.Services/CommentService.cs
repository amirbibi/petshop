using PetShop.Data.Repositories;
using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        
        public async Task AddCommentAsync(Comment comment)
        {
            await _commentRepository.AddCommentAsync(comment);
        }

        public async Task DeleteCommentAsync(Comment comment)
        {
            await _commentRepository.DeleteCommentAsync(comment);
        }

        public async Task EditCommentAsync(Comment updatedComment)
        {
            await _commentRepository.EditCommentAsync(updatedComment);
        }

        public async Task<Comment> GetCommentByIdAsync(int commentId)
        {
            return await _commentRepository.GetCommentByIdAsync(commentId);
        }

        public async Task<IEnumerable<Comment>> GetCommentsForAnimalAsync(int animalId)
        {
            return await _commentRepository.GetCommentsForAnimalAsync(animalId);
        }
    }
}
