using Filter.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.DTO
{
    public class CreateUpdatePostDTO
    {
        #region Properties
        public string PostTitle { get; set; } = null!;
        public string? PostShortVersion { get; set; }
        public string? PostFullVersion { get; set; }
        public int? PostCategoryId { get; set; }
        public int? PostAuthorUserId { get; set; }
        public bool? PostIsVisible { get; set; }
        #endregion
    }
}
