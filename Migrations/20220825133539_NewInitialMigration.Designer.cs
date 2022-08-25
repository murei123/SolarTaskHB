﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Solsr.domains;

#nullable disable

namespace Solsr.Migrations
{
    [DbContext(typeof(AppDB))]
    [Migration("20220825133539_NewInitialMigration")]
    partial class NewInitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Solsr.domains.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("FatherName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("longblob");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });
#pragma warning restore 612, 618
        }
    }
}
