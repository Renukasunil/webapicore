﻿// <auto-generated />
using System;
using LMS.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LMS.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220216054243_migrationsendotpverify")]
    partial class migrationsendotpverify
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("LMS.Model.SendOTP", b =>
                {
                    b.Property<long>("VId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("VId"));

                    b.Property<string>("MobileNo")
                        .HasColumnType("text");

                    b.Property<string>("OTP")
                        .HasColumnType("text");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("VId");

                    b.ToTable("TblSendOTP");
                });

            modelBuilder.Entity("LMS.Model.UserInfo", b =>
                {
                    b.Property<long>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("UserID"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("Country")
                        .HasColumnType("text");

                    b.Property<string>("EmailId")
                        .HasColumnType("text");

                    b.Property<string>("GSTNO")
                        .HasColumnType("text");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("OrganizationName")
                        .HasColumnType("text");

                    b.Property<string>("Other")
                        .HasColumnType("text");

                    b.Property<string>("OwnerContactNo")
                        .HasColumnType("text");

                    b.Property<string>("OwnerEmailId")
                        .HasColumnType("text");

                    b.Property<string>("OwnerName")
                        .HasColumnType("text");

                    b.Property<string>("Pin")
                        .HasColumnType("text");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("TypeOfOrganization")
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.ToTable("UserInfos");
                });

            modelBuilder.Entity("LMS.Model.VerifyOTP", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("UserId"));

                    b.Property<DateTime>("GenerateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("MobileNo")
                        .HasColumnType("text");

                    b.Property<string>("OTP")
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("SaveVerifyOTP");
                });
#pragma warning restore 612, 618
        }
    }
}
