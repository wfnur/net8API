using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net8API.DTOs.Comment;
using net8API.Models;

namespace net8API.Interfaces
{
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?> GetCommentByidAsync(int id);
        Task<Comment> CreateAsync(Comment commentModel);
        Task<Comment> UpdateAsync(int id,UpdateCommentDTO commentDTO);
        Task<Comment> DeleteAsync(int id);
        
    }
}