using Blog.DAL.DTO;
using Blog.DAL.Repository.Auth;
using Filter.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Blog.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    private readonly IAuthService authService;

    public AuthController(IAuthService authService)
    {
      this.authService = authService;
    }

    [HttpPost]
    public async Task<ServiceResponse<string>> Authenticate(CredentialsDTO creds)
    {
      var Result = await authService.Login(creds);
      return Result;
    }
  }
}
