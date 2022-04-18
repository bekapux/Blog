using System;
using System.Collections.Generic;

namespace Blog.API
{
    public partial class PostComment
    {
        public int PostCommentId { get; set; }
        public string? PostComment1 { get; set; }
        public int PostCommentPostId { get; set; }
        public bool PostCommentIsVisible { get; set; }
        public DateTime? PostDateCreated { get; set; }

        public virtual Post PostCommentPost { get; set; } = null!;
    }
}
