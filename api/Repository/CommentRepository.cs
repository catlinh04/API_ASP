using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dto.Comment;
using api.Interface;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDBContext _db;
        public CommentRepository(ApplicationDBContext db)
        {
            _db = db;
        }
        public async Task<Comment> CreateAsync(Comment comment)
        {
           await _db.Comments.AddAsync(comment);
           await _db.SaveChangesAsync();
           return comment;
        }

        public async Task<Comment> DeleteAsync(int id)
        {
            var deleteComment = await _db.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (deleteComment == null)
            {
                return null;
            }
            _db.Comments.Remove(deleteComment);
            await _db.SaveChangesAsync();
            return deleteComment;
        }

        public Task<List<Comment>> GetAllCommentsAsync()
        {
            return _db.Comments.ToListAsync();
        }

        public async Task<Comment?> GetCommentByIdAsync(int id)
        {
            var comment = await _db.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if (comment == null)
            {
                return null;
            }
            return comment;
        }

        public async Task<Comment> UpdateAsync(int id, UpdateCommentDto comment)
        {
            var updateComment = await _db.Comments.FirstOrDefaultAsync(c => c.Id == id);
            if(updateComment == null)
            {
                return null;
            }
            updateComment.Title = comment.Title;
            updateComment.Content = comment.Content;
            updateComment.CreatedOn = DateTime.Now;
            await _db.SaveChangesAsync();
            return updateComment;
        }
    }
}