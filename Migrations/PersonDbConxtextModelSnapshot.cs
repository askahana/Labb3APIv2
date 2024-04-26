﻿// <auto-generated />
using System;
using Labb3APIv2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Labb3APIv2.Migrations
{
    [DbContext(typeof(PersonDbConxtext))]
    partial class PersonDbConxtextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PersoModels.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestId");

                    b.HasIndex("PersonId");

                    b.ToTable("Interests");

                    b.HasData(
                        new
                        {
                            InterestId = 1,
                            Description = "Playing guitar",
                            Title = "Music"
                        },
                        new
                        {
                            InterestId = 2,
                            Description = "Painting",
                            Title = "Art"
                        },
                        new
                        {
                            InterestId = 3,
                            Description = "Waltz",
                            Title = "Dance"
                        });
                });

            modelBuilder.Entity("PersoModels.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LinkId"));

                    b.Property<int?>("InterestId")
                        .HasColumnType("int");

                    b.Property<string>("LinkAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LinkId");

                    b.HasIndex("InterestId");

                    b.ToTable("Links");

                    b.HasData(
                        new
                        {
                            LinkId = 1,
                            LinkAddress = "https://www.bobdylan.com/"
                        },
                        new
                        {
                            LinkId = 2,
                            LinkAddress = "https://www.carllarsson.se/"
                        },
                        new
                        {
                            LinkId = 3,
                            LinkAddress = "https://www.karinforeningen.se/"
                        });
                });

            modelBuilder.Entity("PersoModels.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            FirstName = "Bob",
                            LastName = "Dylan",
                            Tel = "1234567"
                        },
                        new
                        {
                            PersonId = 2,
                            FirstName = "Carl",
                            LastName = "Larsson",
                            Tel = "1234567"
                        },
                        new
                        {
                            PersonId = 3,
                            FirstName = "Karin",
                            LastName = "Larsson",
                            Tel = "1234567"
                        });
                });

            modelBuilder.Entity("PersoModels.Interest", b =>
                {
                    b.HasOne("PersoModels.Person", null)
                        .WithMany("Interest")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("PersoModels.Link", b =>
                {
                    b.HasOne("PersoModels.Interest", null)
                        .WithMany("Link")
                        .HasForeignKey("InterestId");
                });

            modelBuilder.Entity("PersoModels.Interest", b =>
                {
                    b.Navigation("Link");
                });

            modelBuilder.Entity("PersoModels.Person", b =>
                {
                    b.Navigation("Interest");
                });
#pragma warning restore 612, 618
        }
    }
}
