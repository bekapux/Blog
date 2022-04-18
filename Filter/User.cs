using System;
using System.Collections.Generic;

namespace Blog.API
{
    public partial class User
    {
        public User()
        {
            Posts = new HashSet<Post>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string? UserFirstname { get; set; }
        public string? UserLastname { get; set; }
        public string UserEmail { get; set; } = null!;
        public string? UserPhoneNumber { get; set; }
        public string UserPasswordHashed { get; set; } = null!;
        public DateTime UserDateCreated { get; set; }
        public bool UserDeleted { get; set; }
        public int? UserRoleId { get; set; }
        public bool UserHasConfirmedEmail { get; set; }

        public virtual Role? UserRole { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
