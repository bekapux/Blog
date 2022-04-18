using AutoMapper;
using Blog.DAL;
using Blog.DAL.Repository.Auth;
using Blog.DAL.Repository.Users;
using Blog.DAL.Services;
using Filter.DAL.Repository.Posts;
using Microsoft.EntityFrameworkCore;

try
{
  var builder = WebApplication.CreateBuilder(args);

  // Add services to the container.
  var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("Default");

  builder.Services.AddControllers().AddNewtonsoftJson(options =>
  {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
  //options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
});

  builder.Services.AddSingleton(new MapperConfiguration(mc => mc.AddProfile(new AutoMapperProfile())).CreateMapper());
  builder.Services.AddScoped<IAuthService, AuthService>();
  builder.Services.AddScoped<ITokenService, TokenService>();
  builder.Services.AddScoped<IPostsService, PostsService>();
  builder.Services.AddScoped<IUsersService, UsersService>();
  builder.Services.AddEndpointsApiExplorer();
  builder.Services.AddSwaggerGen();
  builder.Services.AddDbContext<BlogContext>(options => options.UseSqlServer(ConnectionString));

  var app = builder.Build();

  // Configure the HTTP request pipeline.
  if (app.Environment.IsDevelopment())
  {
    app.UseSwagger();
    app.UseSwaggerUI();
  }

  app.UseHttpsRedirection();

  app.UseAuthorization();

  app.MapControllers();

  app.Run();
}

catch (Exception ex)
{

  throw;
}