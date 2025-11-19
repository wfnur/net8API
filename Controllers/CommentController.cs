using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net8API.Data;
using net8API.Interfaces;
using net8API.Mapper;
using net8API.Models;

namespace net8API.Controllers
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _commentRepo;
        public CommentController(ICommentRepository commentRepo)
        {
            _commentRepo = commentRepo;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var comments = await _commentRepo.GetAllAsync();
            var commentDto = comments.Select(c => c.ToCommentDTO());
            return Ok(commentDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var comment = await _commentRepo.GetCommentByidAsync(id);
            if(comment == null)
            {
                return NotFound();
            }
            return Ok(comment.ToCommentDTO());
            
        }
    }
}