using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Comment;
using api.Models;

namespace api.Mapper
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                StockId = commentModel.StockId
            };
        }

        public static Comment CreateCommentDto(this CreateCommentDto commentModel)
        {
            return new Comment
            {
                Title = commentModel.Title,
                Content = commentModel.Content
            };
        }

        public static Comment UpdateCommentDto(this UpdateCommentDto commentModel)
        {
            return new Comment
            {
                Title = commentModel.Title,
                Content = commentModel.Content
            };
        }
    }
}