using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Blog.DAL
{
    public partial class BlogContext : DbContext
    {
        public BlogContext()
        {
        }

        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Permission> Permissions { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostCategory> PostCategories { get; set; } = null!;
        public virtual DbSet<PostComment> PostComments { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RolesPermission> RolesPermissions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Blog;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Permission>(entity =>
            {
                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.PermissionActionName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PermissionActionRoute)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PermissionDateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PermissionName).HasMaxLength(200);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasIndex(e => e.PostAuthorUserId, "IX_Posts_PostAuthorUserID");

                entity.HasIndex(e => e.PostCategoryId, "IX_Posts_PostCategoryID");

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.PostAuthorUserId).HasColumnName("PostAuthorUserID");

                entity.Property(e => e.PostCategoryId).HasColumnName("PostCategoryID");

                entity.Property(e => e.PostDateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostShortVersion).HasMaxLength(400);

                entity.Property(e => e.PostTitle).HasMaxLength(200);

                entity.HasOne(d => d.PostAuthorUser)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostAuthorUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Posts_Users");

                entity.HasOne(d => d.PostCategory)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.PostCategoryId)
                    .HasConstraintName("FK_Posts_PostCategories");
            });

            modelBuilder.Entity<PostCategory>(entity =>
            {
                entity.HasIndex(e => e.PostCategoryParentId, "IX_PostCategories_PostCategoryParentID");

                entity.Property(e => e.PostCategoryId).HasColumnName("PostCategoryID");

                entity.Property(e => e.PostCategoryDateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PostCategoryName).HasMaxLength(70);

                entity.Property(e => e.PostCategoryParentId).HasColumnName("PostCategoryParentID");

                entity.HasOne(d => d.PostCategoryParent)
                    .WithMany(p => p.InversePostCategoryParent)
                    .HasForeignKey(d => d.PostCategoryParentId)
                    .HasConstraintName("FK_PostCategories_PostCategories");
            });

            modelBuilder.Entity<PostComment>(entity =>
            {
                entity.HasIndex(e => e.PostCommentPostId, "IX_PostComments_PostCommentPostID");

                entity.Property(e => e.PostCommentId).HasColumnName("PostCommentID");

                entity.Property(e => e.PostComment1)
                    .HasMaxLength(300)
                    .HasColumnName("PostComment");

                entity.Property(e => e.PostCommentPostId).HasColumnName("PostCommentPostID");

                entity.Property(e => e.PostDateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.PostCommentPost)
                    .WithMany(p => p.PostComments)
                    .HasForeignKey(d => d.PostCommentPostId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PostComments_Posts");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleDateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<RolesPermission>(entity =>
            {
                entity.HasKey(e => e.RolePermissionId);

                entity.HasIndex(e => e.PermissionId, "IX_RolesPermissions_PermissionID");

                entity.HasIndex(e => e.RoleId, "IX_RolesPermissions_RoleID");

                entity.Property(e => e.RolePermissionId).HasColumnName("RolePermissionID");

                entity.Property(e => e.PermissionId).HasColumnName("PermissionID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.RolesPermissions)
                    .HasForeignKey(d => d.PermissionId)
                    .HasConstraintName("FK_RolesPermissions_Permissions");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RolesPermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_RolesPermissions_Roles");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.UserRoleId, "IX_Users_UserRoleID");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.UserDateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserEmail).HasMaxLength(100);

                entity.Property(e => e.UserFirstname).HasMaxLength(50);

                entity.Property(e => e.UserLastname).HasMaxLength(50);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserPasswordHashed).HasMaxLength(500);

                entity.Property(e => e.UserPhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("FK_Users_Roles");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
