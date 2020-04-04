﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sandbox.Data;

namespace sandbox.Migrations
{
    [DbContext(typeof(AnimalShelterDbContext))]
    partial class AnimalShelterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("sandbox.Models.Animals", b =>
                {
                    b.Property<int>("DogsID")
                        .HasColumnType("int");

                    b.Property<int>("CatsID")
                        .HasColumnType("int");

                    b.HasKey("DogsID", "CatsID");

                    b.HasIndex("CatsID");

                    b.ToTable("Animals");
                });

            modelBuilder.Entity("sandbox.Models.Cats", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cats");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Age = 100,
                            Gender = "Male",
                            Name = "Garfield",
                            Type = "Fat cat"
                        },
                        new
                        {
                            ID = 2,
                            Age = 20,
                            Gender = "Female",
                            Name = "Josie",
                            Type = "Fat Cat"
                        },
                        new
                        {
                            ID = 3,
                            Age = 1,
                            Gender = "Male",
                            Name = "Rochi",
                            Type = "MochiPochi"
                        });
                });

            modelBuilder.Entity("sandbox.Models.Dogs", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Dogs");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Age = 1,
                            Gender = "Male",
                            Name = "Mochi",
                            Type = "GoldenPoodle"
                        },
                        new
                        {
                            ID = 2,
                            Age = 16,
                            Gender = "Male",
                            Name = "Kudo",
                            Type = "Morkie"
                        },
                        new
                        {
                            ID = 3,
                            Age = 1,
                            Gender = "Male",
                            Name = "Gochi",
                            Type = "MochiPochi"
                        });
                });

            modelBuilder.Entity("sandbox.Models.Animals", b =>
                {
                    b.HasOne("sandbox.Models.Cats", "Cat")
                        .WithMany("Animal")
                        .HasForeignKey("CatsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("sandbox.Models.Dogs", "Dog")
                        .WithMany("Animal")
                        .HasForeignKey("DogsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
