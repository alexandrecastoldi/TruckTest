﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using TruckTest.Infrastructure.Context;

namespace TruckTest.Infrastructure.Migrations
{
    [DbContext(typeof(TruckTestContext))]
    partial class TruckTestContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("TruckTest.Domain.Entities.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("character varying(10)");

                    b.Property<int>("YearFactory")
                        .HasColumnType("integer");

                    b.Property<int>("YearModel")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Trucks");
                });
#pragma warning restore 612, 618
        }
    }
}