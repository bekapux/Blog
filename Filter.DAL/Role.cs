﻿using System;
using System.Collections.Generic;

namespace Blog.DAL
{
    public partial class Role
    {
        public Role()
        {
            RolesPermissions = new HashSet<RolesPermission>();
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public DateTime RoleDateCreated { get; set; }

        public virtual ICollection<RolesPermission> RolesPermissions { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
