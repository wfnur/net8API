using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using net8API.Data;
using net8API.DTOs.Comment;
using net8API.Interfaces;
using net8API.Models;

namespace net8API.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public ApplicationDbContext _context;
        public CommentRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public async Task<Comment> CreateAsync(Comment commentModel)
        {
            await _context.Comments.AddAsync(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<Comment> DeleteAsync(int id)
        {
            var commentModel = await _context.Comments.FirstOrDefaultAsync(x=>x.Id ==id);
            if(commentModel == null)
            {
                return null;
            }
            _context.Comments.Remove(commentModel);
            await _context.SaveChangesAsync();
            return commentModel;
        }

        public async Task<List<Comment>> GetAllAsync()
        {
           return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetCommentByidAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
    
        public async Task<Comment> UpdateAsync(int id, UpdateCommentDTO updateDTO)
        {
            var existComment = await _context.Comments.FirstOrDefaultAsync(x => x.Id == id);
            if(existComment == null)
            {
                return null;
            }

            existComment.Title = updateDTO.Title;
            existComment.Content = updateDTO.Content;
            await _context.SaveChangesAsync();
            
            return existComment ;
        }
    }
}