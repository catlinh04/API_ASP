using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dto.Comment;
using api.Dto.Stock;
using api.Interface;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/comment")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository _repo;
        public CommentController(ICommentRepository commentRepository)
        {
            _repo = commentRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComment()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comments = await _repo.GetAllCommentsAsync();
            var commentsDto = comments.Select(c => c.ToCommentDto());
            return Ok(commentsDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetCommentById([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var comment = await _repo.GetCommentByIdAsync(id);
            var commentsDto = comment.ToCommentDto();
            return Ok(commentsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCommentDto comment)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newComment = comment.CreateCommentDto();
            await _repo.CreateAsync(newComment);
            return CreatedAtAction(nameof(GetCommentById), new {id = newComment.Id}, newComment.ToCommentDto());
        }

        [HttpPut]
        [Route("{id:int}")]

        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDto comment)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updateComment = await _repo.UpdateAsync(id, comment);
            return Ok(updateComment.ToCommentDto());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deleteComment = await _repo.DeleteAsync(id);
            return Ok(deleteComment);
        }
    }
}