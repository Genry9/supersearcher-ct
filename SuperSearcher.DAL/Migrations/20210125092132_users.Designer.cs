﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SuperSearcher.DAL.Contexts;

namespace SuperSearcher.DAL.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210125092132_users")]
    partial class users
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11");

            modelBuilder.Entity("SuperSearcher.DAL.Entities.SearchRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("At")
                        .HasColumnType("TEXT");

                    b.Property<string>("Term")
                        .HasColumnType("TEXT");

                    b.Property<string>("fromFolder")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("allRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
