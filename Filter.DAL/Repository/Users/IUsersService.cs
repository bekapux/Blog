using Blog.DAL.DTO;
using Filter.DAL;

namespace Blog.DAL.Repository.Users
{
  public interface IUsersService
  {
    Task<ServiceResponse<int>> Users_CreateUpdate(CreateUpdateUserDTO User);
    Task<ServiceResponse<IEnumerable<UsersGetDTO>>> Users_GetAll();
  }
}