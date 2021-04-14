using SocialMediaAPI.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialMediaAPI.Model
{
    public class ReplyCreate
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(8000)]
        public string Text { get; set; }
        public Guid Author { get; set; }
    }
}
