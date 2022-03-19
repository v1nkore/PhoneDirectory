﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PhoneDirectory.Infrastructure.Database;

namespace PhoneDirectory.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PhoneDirectory.Domain.Entities.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DivisionId")
                        .HasColumnType("int");

                    b.Property<bool>("IsChief")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DivisionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Entities.Division", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentDivisionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentDivisionId");

                    b.ToTable("Divisions");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Entities.PhoneNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("UserPhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Entities.ApplicationUser", b =>
                {
                    b.HasOne("PhoneDirectory.Domain.Entities.Division", "Division")
                        .WithMany("Users")
                        .HasForeignKey("DivisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Division");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Entities.Division", b =>
                {
                    b.HasOne("PhoneDirectory.Domain.Entities.Division", "ParentDivision")
                        .WithMany("ChildDivisions")
                        .HasForeignKey("ParentDivisionId");

                    b.Navigation("ParentDivision");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Entities.PhoneNumber", b =>
                {
                    b.HasOne("PhoneDirectory.Domain.Entities.ApplicationUser", "User")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Entities.ApplicationUser", b =>
                {
                    b.Navigation("PhoneNumbers");
                });

            modelBuilder.Entity("PhoneDirectory.Domain.Entities.Division", b =>
                {
                    b.Navigation("ChildDivisions");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
