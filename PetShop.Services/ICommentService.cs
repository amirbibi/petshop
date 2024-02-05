using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShop.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> GetCommentsForAnimalAsync(int animalId);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task AddCommentAsync(Comment comment);
        Task DeleteCommentAsync(Comment comment);
        Task EditCommentAsync(Comment updatedComment);
    }
}
