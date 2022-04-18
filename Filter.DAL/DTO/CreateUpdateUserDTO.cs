using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.DTO
{
  public class CreateUpdateUserDTO
  {
    public int? UserId { get; set; }
    public string? UserName { get; set; }
    public string? UserFirstname { get; set; }
    public string? UserLastname { get; set; }
    public string? UserPassword { get; set; }
    public string? UserPasswordHashed { get; set; }
    public string? UserEmail { get; set; }
    public string? UserPhoneNumber { get; set; }
    public int? UserRoleId { get; set; }
  }
}
