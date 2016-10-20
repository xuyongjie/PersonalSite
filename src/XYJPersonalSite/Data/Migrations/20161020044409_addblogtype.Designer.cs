using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using XYJPersonalSite.Data;

namespace XYJPersonalSite.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161020044409_addblogtype")]
    partial class addblogtype
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BlogType", b =>
                {
                    b.Property<string>("TypeName");

                    b.Property<int>("ThisTypeBlogCount");

                    b.Property<string>("TypeDesc");

                    b.HasKey("TypeName");

                    b.ToTable("BlogTypes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("XYJPersonalSite.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("XYJPersonalSite.Models.BusinessModels.Blog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BlogTypeName");

                    b.Property<string>("BlogTypeTypeName");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateTime");

                    b.Property<int>("LikeCount");

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("PostUserId");

                    b.Property<int>("ReadCount");

                    b.Property<string>("Summary")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BlogTypeTypeName");

                    b.HasIndex("PostUserId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("XYJPersonalSite.Models.BusinessModels.BlogTag", b =>
                {
                    b.Property<int>("BlogId");

                    b.Property<string>("TagName");

                    b.HasKey("BlogId", "TagName");

                    b.HasIndex("BlogId");

                    b.HasIndex("TagName");

                    b.ToTable("BlogTags");
                });

            modelBuilder.Entity("XYJPersonalSite.Models.BusinessModels.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BlogId");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("Nickname")
                        .IsRequired();

                    b.Property<int>("ToCommentId");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("XYJPersonalSite.Models.BusinessModels.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("MediaTypeName")
                        .IsRequired();

                    b.Property<DateTime>("ModifyTime");

                    b.Property<string>("Url")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("MediaTypeName");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("XYJPersonalSite.Models.BusinessModels.MediaType", b =>
                {
                    b.Property<string>("Name");

                    b.HasKey("Name");

                    b.ToTable("MediaTypes");
                });

            modelBuilder.Entity("XYJPersonalSite.Models.BusinessModels.Tag", b =>
                {
                    b.Property<string>("TagName");

                    b.HasKey("TagName");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("XYJPersonalSite.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("XYJPersonalSite.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("XYJPersonalSite.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("XYJPersonalSite.Models.BusinessModels.Blog", b =>
                {
                    b.HasOne("BlogType", "BlogType")
                        .WithMany("Blogs")
                        .HasForeignKey("BlogTypeTypeName");

                    b.HasOne("XYJPersonalSite.Models.ApplicationUser", "PostUser")
                        .WithMany()
                        .HasForeignKey("PostUserId");
                });

            modelBuilder.Entity("XYJPersonalSite.Models.BusinessModels.BlogTag", b =>
                {
                    b.HasOne("XYJPersonalSite.Models.BusinessModels.Blog", "Blog")
                        .WithMany()
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("XYJPersonalSite.Models.BusinessModels.Tag", "Tag")
                        .WithMany()
                        .HasForeignKey("TagName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("XYJPersonalSite.Models.BusinessModels.Comment", b =>
                {
                    b.HasOne("XYJPersonalSite.Models.BusinessModels.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("XYJPersonalSite.Models.BusinessModels.Media", b =>
                {
                    b.HasOne("XYJPersonalSite.Models.BusinessModels.MediaType", "MediaType")
                        .WithMany()
                        .HasForeignKey("MediaTypeName")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
