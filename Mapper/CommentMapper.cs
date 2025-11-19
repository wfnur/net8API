using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using net8API.DTOs.Comment;
using net8API.Models;

namespace net8API.Mapper
{
    public static class CommentMapper
    {
        public static CommentDTO ToCommentDTO(this Comment commentModel)
        {
            return new CommentDTO
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedDate = commentModel.CreatedDate,
                CreatedBy = commentModel.CreatedBy,
                StockId = commentModel.StockId
            };
        }
    }
}