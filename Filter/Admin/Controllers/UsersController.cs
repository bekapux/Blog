using Blog.DAL.DTO;
using Blog.DAL.Repository.Users;
using Filter.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    #region Constructors
    private readonly IUsersService usersService;
    public UsersController(IUsersService usersService)
    {
      this.usersService = usersService;
    }
    #endregion

    [HttpPost]
    public async Task<ServiceResponse<int>> UserCreateUpdate(CreateUpdateUserDTO userDTO)
    {
      var Result = await usersService.Users_CreateUpdate(userDTO);
      return Result;
    }
    [HttpGet]
    public async Task<ServiceResponse<IEnumerable<UsersGetDTO>>> GetUsers()
    {
      var Result = await usersService.Users_GetAll();
      return Result;
    }
  }
}
