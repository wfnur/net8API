using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using net8API.Data;
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
        public async Task<List<Comment>> GetAllAsync()
        {
           return await _context.Comments.ToListAsync();
        }

        public async Task<Comment?> GetCommentByidAsync(int id)
        {
            return await _context.Comments.FindAsync(id);
        }
    }
}