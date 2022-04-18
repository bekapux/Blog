namespace Blog.DAL.DTO
{
  public class PostsGetDTO
  {
    public int PostId { get; set; }
    public string PostTitle { get; set; } = null!;
    public string? PostShortVersion { get; set; }
    public string? PostFullVersion { get; set; }
    public int? PostCategoryId { get; set; }
    public int PostAuthorUserId { get; set; }
    public bool PostIsVisible { get; set; }
    public DateTime? PostDateCreated { get; set; }

    public virtual PostAuthorDTO? PostAuthorUser { get; set; }
    public virtual PostCategoryDTO? PostCategory { get; set; }
  }
}
