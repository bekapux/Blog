using Blog.DAL.DTO;
using Blog.DAL.Services;
using Blog.DAL.Utilities;
using Filter.DAL;
using Microsoft.EntityFrameworkCore;

namespace Blog.DAL.Repository.Auth
{
  public class AuthService : IAuthService
  {
    private readonly ITokenService tokenService;
    private readonly BlogContext _context;

    public AuthService(ITokenService tokenService, BlogContext context)
    {
      this.tokenService = tokenService;
      this._context = context;
    }
    public async Task<ServiceResponse<string>> Login(CredentialsDTO credentials)
    {
      var SR = new ServiceResponse<string>();
      var hashedPassword = PasswordUtils.HashPass(credentials.Password!);

      var userId = (await _context.Users
        .FirstOrDefaultAsync(x => x.UserName == credentials.Username && hashedPassword == x.UserPasswordHashed))?.UserId;
      if (userId == null)
      {
        SR.IsSuccess = false;
        SR.ErrorMessage = "Incorrect Credentials";
      }
      else if (userId != null)
      {
        SR.Data = await tokenService.GenerateToken(userId, "Test");
      }
      return SR;
    }
  }
}
