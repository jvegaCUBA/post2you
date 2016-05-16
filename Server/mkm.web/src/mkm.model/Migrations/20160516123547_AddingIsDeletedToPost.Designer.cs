using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using mkm.model;

namespace mkm.model.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20160516123547_AddingIsDeletedToPost")]
    partial class AddingIsDeletedToPost
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
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
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

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

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("IdentityUserId");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("IdentityUserId");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.Property<string>("IdentityUserId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

            modelBuilder.Entity("mkm.model.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long?>("CategoryId");

                    b.Property<DateTime>("Created");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.CategoryPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("CategoryId");

                    b.Property<DateTime>("Created");

                    b.Property<long>("PostId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.Comment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("Emoticons");

                    b.Property<long?>("ParentCommentId");

                    b.Property<long>("PostId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.Cupon", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<bool>("InUse");

                    b.Property<long>("OfertId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.Favorite", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<long>("PostId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.Like", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("LikeType");

                    b.Property<long>("PostId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.Notification", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsViewed");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Text");

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.Post", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Categories");

                    b.Property<int>("CommentsCount");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("FavoritesCount");

                    b.Property<bool?>("IsConfirmedDenounce");

                    b.Property<bool?>("IsDeleted");

                    b.Property<bool?>("IsDenounced");

                    b.Property<int>("LikesCount");

                    b.Property<int>("LinksCount");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<int>("SharesCount");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserId");

                    b.Property<int>("ViewsCount");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:DiscriminatorProperty", "Discriminator");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Post");
                });

            modelBuilder.Entity("mkm.model.PostDenounce", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<DateTime>("Created");

                    b.Property<long>("PostId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.Relation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("UserFollowId");

                    b.Property<string>("UserFollowedId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.Reservation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CancelationDate");

                    b.Property<string>("ClientId");

                    b.Property<string>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<long>("CuponId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsCanceled");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Status");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.Resource", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<bool>("IsPrincipal");

                    b.Property<string>("Location");

                    b.Property<bool>("Order");

                    b.Property<long>("PostId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Type");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.SharedPost", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<long>("PostId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("SocialNetwork");

                    b.Property<string>("UserId");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("mkm.model.User", b =>
                {
                    b.HasBaseType("Microsoft.AspNet.Identity.EntityFramework.IdentityUser");

                    b.Property<DateTime>("Created");

                    b.Property<int>("FollowersCount");

                    b.Property<int>("FollowsCount");

                    b.Property<string>("LastName");

                    b.Property<string>("Name");

                    b.HasAnnotation("Relational:DiscriminatorValue", "User");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("mkm.model.Ofert", b =>
                {
                    b.HasBaseType("mkm.model.Post");

                    b.Property<string>("BusinessId");

                    b.Property<int>("Capacity");

                    b.Property<int?>("DiscountPercent");

                    b.Property<decimal?>("DiscountPrice");

                    b.Property<DateTime>("DueDate");

                    b.Property<DateTime>("FinishDate");

                    b.Property<bool>("IsActive");

                    b.Property<int>("RealCupons");

                    b.Property<int?>("RealPrice");

                    b.Property<int>("ReservedCupons");

                    b.Property<DateTime>("StartDate");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Ofert");
                });

            modelBuilder.Entity("mkm.model.Business", b =>
                {
                    b.HasBaseType("mkm.model.User");

                    b.Property<int>("ActiveOfertCount");

                    b.Property<string>("ActivityDescription");

                    b.Property<int>("OfertCount");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Business");
                });

            modelBuilder.Entity("mkm.model.Client", b =>
                {
                    b.HasBaseType("mkm.model.User");

                    b.Property<int>("ActiveReservations");

                    b.Property<int>("ReservationsCount");

                    b.HasAnnotation("Relational:DiscriminatorValue", "Client");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("mkm.model.Category", b =>
                {
                    b.HasOne("mkm.model.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("mkm.model.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("mkm.model.CategoryPost", b =>
                {
                    b.HasOne("mkm.model.Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("mkm.model.Post")
                        .WithMany()
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("mkm.model.Comment", b =>
                {
                    b.HasOne("mkm.model.Comment")
                        .WithMany()
                        .HasForeignKey("ParentCommentId");

                    b.HasOne("mkm.model.Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("mkm.model.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("mkm.model.Cupon", b =>
                {
                    b.HasOne("mkm.model.Ofert")
                        .WithMany()
                        .HasForeignKey("OfertId");
                });

            modelBuilder.Entity("mkm.model.Favorite", b =>
                {
                    b.HasOne("mkm.model.Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("mkm.model.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("mkm.model.Like", b =>
                {
                    b.HasOne("mkm.model.Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("mkm.model.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("mkm.model.Notification", b =>
                {
                    b.HasOne("mkm.model.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("mkm.model.Post", b =>
                {
                    b.HasOne("mkm.model.Client")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("mkm.model.PostDenounce", b =>
                {
                    b.HasOne("mkm.model.Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("mkm.model.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("mkm.model.Relation", b =>
                {
                    b.HasOne("mkm.model.User")
                        .WithMany()
                        .HasForeignKey("UserFollowId");

                    b.HasOne("mkm.model.User")
                        .WithMany()
                        .HasForeignKey("UserFollowedId");
                });

            modelBuilder.Entity("mkm.model.Reservation", b =>
                {
                    b.HasOne("mkm.model.Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("mkm.model.Cupon")
                        .WithOne()
                        .HasForeignKey("mkm.model.Reservation", "CuponId");
                });

            modelBuilder.Entity("mkm.model.Resource", b =>
                {
                    b.HasOne("mkm.model.Post")
                        .WithMany()
                        .HasForeignKey("PostId");
                });

            modelBuilder.Entity("mkm.model.SharedPost", b =>
                {
                    b.HasOne("mkm.model.Post")
                        .WithMany()
                        .HasForeignKey("PostId");

                    b.HasOne("mkm.model.User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("mkm.model.Ofert", b =>
                {
                    b.HasOne("mkm.model.Business")
                        .WithMany()
                        .HasForeignKey("BusinessId");
                });
        }
    }
}
