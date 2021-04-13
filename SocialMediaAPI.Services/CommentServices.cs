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
        public CommentServices(Guid _authorId)
        {
            _authorId = authorId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    Id = model.Id
                    AuthorId = _authorId,
                    Text = model.Text,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
