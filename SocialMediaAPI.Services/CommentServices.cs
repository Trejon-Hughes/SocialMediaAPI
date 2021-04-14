using SocialMediaAPI.Data;
using SocialMediaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Services
{
    public class CommentServices
    {
        private readonly Guid _authorId;
        public CommentServices(Guid authorId)
        {
            _authorId = authorId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    AuthorId = _authorId,
                    Text = model.Text,
                    Id = model.Id
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public Comment GetCommentByPostId(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.PostId == postId && e.AuthorId == _authorId);
                return
                    new Comment
                    {
                        PostId = entity.PostId,
                        Text = entity.Text
                    };
            }
        }
    }
}
