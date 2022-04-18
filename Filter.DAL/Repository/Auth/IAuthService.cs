using Blog.DAL.DTO;
using Filter.DAL;

namespace Blog.DAL.Repository.Auth
{
  public interface IAuthService
  {
    Task<ServiceResponse<string>> Login(CredentialsDTO credentials);
  }
}