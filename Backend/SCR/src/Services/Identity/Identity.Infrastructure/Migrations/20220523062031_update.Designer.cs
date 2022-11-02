﻿// <auto-generated />
using System;
using Identity.Infrastructure.RDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Identity.Infrastructure.Migrations
{
    [DbContext(typeof(IdentityContext))]
    [Migration("20220523062031_update")]
    partial class update
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.HasSequence<int>("CompanyId")
                .HasMin(1L)
                .HasMax(2147483647L);

            modelBuilder.HasSequence<int>("PermissionId")
                .HasMin(1L)
                .HasMax(2147483647L);

            modelBuilder.HasSequence<int>("RoleId")
                .HasMin(1L)
                .HasMax(2147483647L);

            modelBuilder.HasSequence<int>("UserId")
                .HasMin(1L)
                .HasMax(2147483647L);

            modelBuilder.Entity("Identity.Domain.Aggregates.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"CompanyId\"')");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("CompanyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.Entity.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"UserId\"')");

                    b.Property<string>("Account")
                        .HasColumnType("text");

                    b.Property<string>("Avatar")
                        .HasColumnType("text");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("DefaultCompanyId")
                        .HasColumnType("integer");

                    b.Property<string>("Descrption")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<bool>("IsActived")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("LastLoginTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Mobile")
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PswEncryptCode")
                        .HasColumnType("text");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"PermissionId\"')");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PermissionId");

                    b.ToTable("Permisson");
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValueSql("nextval('\"RoleId\"')");

                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<int?>("ModifiedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoleId");

                    b.HasIndex("CompanyId");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.RolePermissionRelation", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("PermissionId")
                        .HasColumnType("integer");

                    b.HasKey("RoleId", "PermissionId");

                    b.ToTable("RolePermissionRelation");
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.UserCompanyRelation", b =>
                {
                    b.Property<int>("CompanyId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("CompanyId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserCompanyRelation");
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.UserRoleRelation", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoleRelation");
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.Entity.User", b =>
                {
                    b.HasOne("Identity.Domain.Aggregates.Role", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.Permission", b =>
                {
                    b.OwnsMany("Identity.Domain.Aggregates.PermissionAction", "Actions", b1 =>
                        {
                            b1.Property<int>("PermissionId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("integer")
                                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                            b1.Property<string>("Action")
                                .HasColumnType("text");

                            b1.Property<int>("PermissionId1")
                                .HasColumnType("integer");

                            b1.HasKey("PermissionId");

                            b1.HasIndex("PermissionId1");

                            b1.ToTable("Permission_Action");

                            b1.WithOwner()
                                .HasForeignKey("PermissionId1");
                        });

                    b.Navigation("Actions");
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.Role", b =>
                {
                    b.HasOne("Identity.Domain.Aggregates.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.UserCompanyRelation", b =>
                {
                    b.HasOne("Identity.Domain.Aggregates.Entity.User", null)
                        .WithMany("Companies")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.UserRoleRelation", b =>
                {
                    b.HasOne("Identity.Domain.Aggregates.Entity.User", null)
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.Entity.User", b =>
                {
                    b.Navigation("Companies");

                    b.Navigation("Roles");
                });

            modelBuilder.Entity("Identity.Domain.Aggregates.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}