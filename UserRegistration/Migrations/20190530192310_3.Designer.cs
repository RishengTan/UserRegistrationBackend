﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserRegistration.Models;

namespace UserRegistration.Migrations
{
    [DbContext(typeof(HeroContext))]
    [Migration("20190530192310_3")]
    partial class _3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UserRegistration.Models.Heros", b =>
                {
                    b.Property<int>("HeroID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Defense");

                    b.Property<int>("Health");

                    b.Property<string>("HeroName");

                    b.Property<int>("Offense");

                    b.Property<int>("Speed");

                    b.Property<int>("companyID");

                    b.HasKey("HeroID");

                    b.ToTable("Heros");
                });
#pragma warning restore 612, 618
        }
    }
}