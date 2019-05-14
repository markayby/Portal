﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Portal.Entities;

namespace Portal.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181012122501_dev4")]
    partial class dev4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Portal.Entities.Head", b =>
                {
                    b.Property<string>("Email")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(40);

                    b.Property<long>("Id");

                    b.Property<string>("Name")
                        .HasMaxLength(120);

                    b.Property<string>("Surname")
                        .HasMaxLength(120);

                    b.HasKey("Email");

                    b.ToTable("Heads");
                });

            modelBuilder.Entity("Portal.Entities.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new { Id = 2L, Name = "Basic" },
                        new { Id = 1L, Name = "Admin" }
                    );
                });

            modelBuilder.Entity("Portal.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Login")
                        .HasMaxLength(120);

                    b.Property<string>("Password");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new { Id = 1L, Login = "admin", Password = "AQAAAAEAACcQAAAAEDYQl21USY/Omwdcklx4kZCjvnCJia8scxew+ZQUeRzgf8Fef2sg/qOGqaEpraOpXg==", RoleId = 1L },
                        new { Id = 2L, Login = "user", Password = "AQAAAAEAACcQAAAAEKEqmNQprAJMagc4KjA6pTQwdLvNnMT7btSa2wJoPBICCRTVnhs+0MD0jzHLZI2QKA==", RoleId = 2L }
                    );
                });

            modelBuilder.Entity("Portal.Entities.User", b =>
                {
                    b.HasOne("Portal.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
