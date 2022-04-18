using AutoMapper;
using Blog.DAL.DTO;
using Filter.DAL;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Blog.DAL.Repository.Users
{
  public class UsersService : RepositoryBase, IUsersService
  {
    #region Constructors
    public UsersService(BlogContext context, IMapper mapper) : base(context, mapper) { }
    #endregion

    #region Methods
    public async Task<ServiceResponse<int>> Users_CreateUpdate(CreateUpdateUserDTO User)
    {
      var SR = new ServiceResponse<int>();
      if (User.UserId == null || User.UserId == 0)
      {
        var user = new User()
        {
          UserEmail = User.UserEmail!,
          UserName = User.UserName!,
          UserFirstname = User.UserFirstname,
          UserLastname = User.UserLastname,
          UserRoleId = User.UserRoleId,
          UserPhoneNumber = User.UserPhoneNumber,
          UserDeleted = false,
          UserHasConfirmedEmail = true,
          UserPasswordHashed = HashPass(User.UserPasswordHashed!)
        };
        _context.Users.Add(_mapper.Map<User>(user));
        SR.Data = await _context.SaveChangesAsync();
        return SR;
      }
      else
      {
        var DBUser = await _context.Users.FirstOrDefaultAsync(u => u.UserId == User.UserId);
        //some logic...
        return SR;
      }
    }

    public async Task<ServiceResponse<IEnumerable<UsersGetDTO>>> Users_GetAll()
    {
      var SR = new ServiceResponse<IEnumerable<UsersGetDTO>>();
      SR.Data = await _context.Users
        .Where(user => user.UserDeleted == false)
        .Include(user=> user.UserRole)
        .Select(user=> _mapper.Map<UsersGetDTO>(user))
        .ToListAsync();
      return SR;
    }
    #endregion

    #region HelperMethods
    private string HashPass(string password)
    {
      var bytes = new UTF8Encoding().GetBytes(password);
      byte[] hashBytes;
      using (var algorithm = new System.Security.Cryptography.HMACSHA512())
      {
        hashBytes = algorithm.ComputeHash(bytes);
      }
      var Result = Convert.ToBase64String(hashBytes);
      return Result;
    }
    #endregion
  }
}
