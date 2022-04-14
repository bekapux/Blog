using System;
using System.Collections.Generic;

namespace Filter.DAL
{
    public partial class Post
    {
        public Post()
        {
            PostComments = new HashSet<PostComment>();
        }

        public int PostId { get; set; }
        public string PostTitle { get; set; } = null!;
        public string? PostShortVersion { get; set; }
        public string? PostFullVersion { get; set; }
        public int? PostCategoryId { get; set; }
        public int PostAuthorUserId { get; set; }
        public bool PostIsVisible { get; set; }
        public DateTime? PostDateCreated { get; set; }

        public virtual User PostAuthorUser { get; set; } = null!;
        public virtual PostCategory? PostCategory { get; set; }
        public virtual ICollection<PostComment> PostComments { get; set; }
    }
}
