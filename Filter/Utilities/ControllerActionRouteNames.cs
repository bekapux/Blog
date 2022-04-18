namespace Blog.API.Utilities
{
    public class ControllerActionRouteNames
    {
        public static class Posts
        {
            #region Properties
            public const string GetAll  = "GetAllPosts";
            public const string GetByID = "GetByPostID";
            public const string Add     = "AddPost";
            public const string Update  = "UpdatePost";
            public const string Delete  = "DeletePost";
            #endregion
        }
    public static class Users
    {
      #region Properties
      public const string GetAll = "GetAllUsers";
      public const string GetByID = "GetByUserID";
      public const string AddUpdate = "AddUpdatePost";
      public const string Delete = "DeletePost";
      #endregion
    }
  }
}
