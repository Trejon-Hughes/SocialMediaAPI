using SocialMediaAPI.Data;
using SocialMediaAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateReply(ReplyCreate model)
        {
            var entity = new Reply()
            {
                Text = model.Text,
                AuthorId = _userId
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Entry(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<Reply> GetReply()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                   ctx.Replies.Select(
                       e =>
                            new Reply
                            {
                                Id = e.Id,
                                Text = e.Text,
                                AuthorId = e.AuthorId
                            });
                return query.ToList();
            }
        }
    }
}