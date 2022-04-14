namespace Filter.DAL
{
    public partial class Permission
    {
        public Permission()
        {
            RolesPermissions = new HashSet<RolesPermission>();
        }
        public int PermissionId { get; set; }
        public string? PermissionName { get; set; }
        public string? PermissionActionName { get; set; }
        public string PermissionDateCreated { get; set; } = null!;

        public virtual ICollection<RolesPermission> RolesPermissions { get; set; }
    }
}
