using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Data
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Text { get; set; }

        [Required]
        public Guid AuthorId { get; set; }

        public virtual List<Reply> Replys { get; set; } = new List<Reply>();

        [ForeignKey(nameof(Post))]
        [Required]
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
