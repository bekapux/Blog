using System;
using System.Collections.Generic;

namespace Blog.DAL
{
    public partial class Permission
    {
        public Permission()
        {
            RolesPermissions = new HashSet<RolesPermission>();
        }

        public int PermissionId { get; set; }
        public int? PermissionParentId { get; set; }
        public string? PermissionName { get; set; }
        public string? PermissionActionName { get; set; }
        public DateTime PermissionDateCreated { get; set; }

        public virtual ICollection<RolesPermission> RolesPermissions { get; set; }
    }
}
