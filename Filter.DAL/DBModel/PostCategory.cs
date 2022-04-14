using System;
using System.Collections.Generic;

namespace Filter.DAL
{
    public partial class PostCategory
    {
        public PostCategory()
        {
            InversePostCategoryParent = new HashSet<PostCategory>();
            Posts = new HashSet<Post>();
        }

        public int PostCategoryId { get; set; }
        public int? PostCategoryParentId { get; set; }
        public string? PostCategoryName { get; set; }
        public DateTime PostCategoryDateCreated { get; set; }

        public virtual PostCategory? PostCategoryParent { get; set; }
        public virtual ICollection<PostCategory> InversePostCategoryParent { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
