using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
namespace Blog.DAL.Services
{
  public class TokenService : ITokenService
  {
    private readonly SymmetricSecurityKey _key;
    private readonly string _issuer;
    private readonly BlogContext _context;

    public TokenService(BlogContext context, IConfiguration config)
    {
      _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
      _issuer = config["Jwt:Issuer"];
      _context = context;
    }

    public async Task<string> GenerateToken(int? userId, string displayName)
    {
      var claims = new List<Claim>();
      var UserRoleID = (await _context.Users.FirstOrDefaultAsync(x => x.UserId == userId))?.UserRoleId;
      var permissions = await _context.RolesPermissions.Where(x => UserRoleID == x.PermissionId).ToListAsync();

      foreach (var item in permissions)
      {
        claims.Add(new Claim(type: ClaimTypes.Role, value: item.PermissionId.ToString()));
      }
      var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
      var token = new JwtSecurityToken(
        _issuer,
        _issuer,
        claims,
        expires: DateTime.Now.AddDays(7),
        signingCredentials: creds
      );
      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}
