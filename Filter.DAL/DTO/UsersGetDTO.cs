using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.DTO
{
  public class UsersGetDTO
  {
    public int UserId { get; set; }
    public string UserName { get; set; } = null!;
    public string? UserFirstname { get; set; }
    public string? UserLastname { get; set; }
    public string UserEmail { get; set; } = null!;
    public string? UserPhoneNumber { get; set; }
    public int? UserRoleId { get; set; }
    public bool UserHasConfirmedEmail { get; set; }

    public UserRoleGetDTO? UserRole { get; set; }
  }
}
