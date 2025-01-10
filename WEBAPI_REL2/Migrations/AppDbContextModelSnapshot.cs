﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WEBAPI_REL2.Data;

#nullable disable

namespace WEBAPI_REL2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WEBAPI_REL2.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countrys");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Owner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("countryId")
                        .HasColumnType("int");

                    b.Property<string>("gym")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("countryId");

                    b.ToTable("Owners");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("bod")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.PokemonCatagory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("c_id")
                        .HasColumnType("int");

                    b.Property<int>("p_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("c_id");

                    b.HasIndex("p_id");

                    b.ToTable("PokemonCatagories");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Pokemonowner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("o_id")
                        .HasColumnType("int");

                    b.Property<int>("p_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("o_id");

                    b.HasIndex("p_id");

                    b.ToTable("Pokemonowners");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PokemonsId")
                        .HasColumnType("int");

                    b.Property<int>("ReviewersId")
                        .HasColumnType("int");

                    b.Property<int>("rating")
                        .HasColumnType("int");

                    b.Property<string>("text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PokemonsId");

                    b.HasIndex("ReviewersId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Reviewer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Reviewers");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Owner", b =>
                {
                    b.HasOne("WEBAPI_REL2.Models.Country", "country")
                        .WithMany("owners")
                        .HasForeignKey("countryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("country");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.PokemonCatagory", b =>
                {
                    b.HasOne("WEBAPI_REL2.Models.Category", "Categories")
                        .WithMany("pokemonCatagories")
                        .HasForeignKey("c_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEBAPI_REL2.Models.Pokemon", "Pokemons")
                        .WithMany("PokemonCatagorys")
                        .HasForeignKey("p_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categories");

                    b.Navigation("Pokemons");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Pokemonowner", b =>
                {
                    b.HasOne("WEBAPI_REL2.Models.Owner", "Owners")
                        .WithMany("Pokemonowners")
                        .HasForeignKey("o_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEBAPI_REL2.Models.Pokemon", "Pokemons")
                        .WithMany("Pokemonowners")
                        .HasForeignKey("p_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owners");

                    b.Navigation("Pokemons");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Review", b =>
                {
                    b.HasOne("WEBAPI_REL2.Models.Pokemon", "Pokemons")
                        .WithMany("Reviews")
                        .HasForeignKey("PokemonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WEBAPI_REL2.Models.Reviewer", "Reviewers")
                        .WithMany("Reviews")
                        .HasForeignKey("ReviewersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemons");

                    b.Navigation("Reviewers");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Category", b =>
                {
                    b.Navigation("pokemonCatagories");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Country", b =>
                {
                    b.Navigation("owners");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Owner", b =>
                {
                    b.Navigation("Pokemonowners");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Pokemon", b =>
                {
                    b.Navigation("PokemonCatagorys");

                    b.Navigation("Pokemonowners");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("WEBAPI_REL2.Models.Reviewer", b =>
                {
                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
