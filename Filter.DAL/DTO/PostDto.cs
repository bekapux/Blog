using Filter.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.DTO
{
    public class PostDto
    {
        public int PostId { get; set; }
        public string PostTitle { get; set; } = null!;
        public string? PostShortVersion { get; set; }
        public string? PostFullVersion { get; set; }
        public int? PostCategoryId { get; set; }
        public int PostAuthorUserId { get; set; }
        public bool PostIsVisible { get; set; }
        public DateTime? PostDateCreated { get; set; }
        public User PostAuthorUser { get; set; } = null!;
        public virtual PostCategory? PostCategory { get; set; }

    }
}
