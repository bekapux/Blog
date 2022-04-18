
namespace Blog.DAL.Services
{
  public interface ITokenService
  {
    Task<string> GenerateToken(int? userId, string displayName);
  }
}