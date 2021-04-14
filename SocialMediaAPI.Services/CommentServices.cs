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
        public bool CreateComment(Post model)
        {
            var entity =
                new Comment()
                {
                    AuthorId = _authorId,
                    Text = model.Text,
                    PostId = model.PostId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetCommentsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.PostId == id)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    Id = e.PostId,
                                    Text = e.Text
                                }
                        );

                return query.ToArray();
            }
        }
    }
}
