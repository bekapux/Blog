namespace Blog.DAL.DTO
{
  public class PostCategoryDTO
  {
    public int PostCategoryId { get; set; }
    public int? PostCategoryParentId { get; set; }
    public string? PostCategoryName { get; set; }
  }
}
