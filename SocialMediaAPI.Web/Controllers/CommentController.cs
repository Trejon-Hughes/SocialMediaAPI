using Microsoft.AspNet.Identity;
using SocialMediaAPI.Model;
using SocialMediaAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace SocialMediaAPI.Web.Controllers
{
    public class CommentController : ApiController
    {
        private CommentServices CreateCommentService()
        {
            var authorId = Guid.Parse(User.Identity.GetUserId());
            var CommentService = new CommentServices(authorId);
            return CommentService;
        }
        public IHttpActionResult Comment(CommentCreate comment)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
                return InternalServerError();

            return Ok();
        }
        public IHttpActionResult Get(int postId)
        {
            CommentServices commentService = CreateCommentService();
            var comment = commentService.GetCommentByPostId(postId);
            return Ok(comment);
        }
    }
}