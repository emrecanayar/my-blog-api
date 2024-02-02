﻿// <auto-generated />
using System;
using Core.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Core.Persistence.Migrations
{
    [DbContext(typeof(BaseDbContext))]
    [Migration("20240201123837_AboutRelationshipUploadedFile")]
    partial class AboutRelationshipUploadedFile
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Domain.Entities.About", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Description");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Title");

                    b.Property<Guid>("UploadedFileId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.HasIndex("UploadedFileId");

                    b.ToTable("Abouts", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.Dictionary", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Entity")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Entity");

                    b.Property<string>("EntryKey")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("EntryKey");

                    b.Property<string>("EntryValue")
                        .IsRequired()
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("EntryValue");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<Guid>("LanguageId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("LanguageId");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Property")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Property");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("ValueType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("ValueType");

                    b.HasKey("Id");

                    b.HasIndex("LanguageId");

                    b.ToTable("Dictionaries", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.EmailAuthenticator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("ActivationKey")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)")
                        .HasColumnName("ActivationKey");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit")
                        .HasColumnName("IsVerified");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedDate");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EmailAuthenticators", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.Language", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Flag")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Flag");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Symbol");

                    b.HasKey("Id");

                    b.ToTable("Languages", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("EventId")
                        .HasMaxLength(36)
                        .HasColumnType("nvarchar(36)")
                        .HasColumnName("EventId");

                    b.Property<string>("Exception")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("Exception");

                    b.Property<string>("ExceptionMessage")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("ExceptionMessage");

                    b.Property<string>("GetErrorLog")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("GetErrorLog");

                    b.Property<string>("GetLog")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("GetLog");

                    b.Property<string>("Headers")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("Headers");

                    b.Property<string>("Host")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Host");

                    b.Property<string>("InnerException")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("InnerException");

                    b.Property<string>("InnerExceptionMessage")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("InnerExceptionMessage");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<DateTime>("LogDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("LogDate");

                    b.Property<string>("LogDomain")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("LogDomain");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedDate");

                    b.Property<string>("Path")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Path");

                    b.Property<string>("QueryString")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("QueryString");

                    b.Property<string>("RemoteIp")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("RemoteIp");

                    b.Property<string>("RequestBody")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("RequestBody");

                    b.Property<string>("RequestMethod")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("RequestMethod");

                    b.Property<string>("ResponseBody")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("ResponseBody");

                    b.Property<string>("ResponseHeaders")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("ResponseHeaders");

                    b.Property<long?>("ResponseTime")
                        .HasColumnType("bigint")
                        .HasColumnName("ResponseTime");

                    b.Property<string>("Scheme")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Scheme");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<int?>("StatusCode")
                        .HasColumnType("int")
                        .HasColumnName("StatusCode");

                    b.Property<string>("UserAgent")
                        .HasColumnType("nvarchar(MAX)")
                        .HasColumnName("UserAgent");

                    b.Property<string>("UserId")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.ToTable("Logs", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.OperationClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedDate");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Name");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UK_OperationClaims_Name")
                        .IsUnique();

                    b.ToTable("OperationClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("5ea19859-a3b1-4191-8429-8e840c8e83de"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 1, 15, 38, 35, 384, DateTimeKind.Local).AddTicks(6183),
                            IsDeleted = false,
                            Name = "Admin",
                            Status = 1
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.OtpAuthenticator", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("SecretKey")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("OtpAuthenticator");
                });

            modelBuilder.Entity("Core.Domain.Entities.RefreshToken", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<string>("CreatedByIp")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedByIp");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime2")
                        .HasColumnName("Expires");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedDate");

                    b.Property<string>("ReasonRevoked")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ReasonRevoked");

                    b.Property<string>("ReplacedByToken")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ReplacedByToken");

                    b.Property<DateTime?>("Revoked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("Revoked");

                    b.Property<string>("RevokedByIp")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("RevokedByIp");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Token");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshTokens", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.UploadedFile", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Directory")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Directory");

                    b.Property<string>("Extension")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Extension");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FileType")
                        .HasColumnType("int")
                        .HasColumnName("FileType");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedDate");

                    b.Property<string>("Path")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Path");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Token");

                    b.HasKey("Id");

                    b.ToTable("UploadedFiles", (string)null);
                });

            modelBuilder.Entity("Core.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<int>("AuthenticatorType")
                        .HasColumnType("int")
                        .HasColumnName("AuthenticatorType");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<int>("CultureType")
                        .HasColumnType("int")
                        .HasColumnName("CultureType");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedDate");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varbinary(256)")
                        .HasColumnName("PasswordHash");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varbinary(256)")
                        .HasColumnName("PasswordSalt");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "UK_Users_Email")
                        .IsUnique();

                    b.ToTable("Users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9925603e-4b1b-4822-b83a-5e57eb6e55c7"),
                            AuthenticatorType = 0,
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 1, 15, 38, 35, 389, DateTimeKind.Local).AddTicks(8402),
                            CultureType = 0,
                            Email = "admin@admin.com",
                            FirstName = "Admin",
                            IsDeleted = false,
                            LastName = "Admin",
                            PasswordHash = new byte[] { 28, 108, 106, 88, 229, 224, 215, 197, 14, 67, 20, 208, 218, 93, 223, 149, 239, 219, 110, 90, 144, 138, 184, 114, 242, 66, 203, 30, 157, 7, 221, 202, 8, 11, 102, 66, 209, 246, 24, 43, 225, 56, 169, 48, 41, 250, 104, 164, 251, 3, 207, 139, 254, 32, 37, 239, 116, 192, 41, 51, 32, 66, 74, 216 },
                            PasswordSalt = new byte[] { 138, 160, 110, 69, 205, 0, 238, 110, 33, 90, 81, 67, 15, 48, 94, 181, 240, 236, 74, 189, 43, 30, 108, 75, 191, 21, 102, 60, 198, 180, 195, 41, 47, 7, 82, 41, 176, 221, 217, 220, 231, 67, 221, 159, 56, 14, 24, 4, 72, 147, 192, 248, 135, 92, 125, 71, 28, 160, 2, 26, 117, 139, 170, 209, 142, 125, 159, 174, 113, 229, 89, 223, 170, 117, 226, 125, 36, 14, 114, 71, 43, 128, 53, 134, 19, 62, 143, 115, 196, 250, 108, 239, 19, 94, 144, 4, 222, 220, 11, 64, 121, 85, 103, 51, 54, 157, 232, 139, 210, 12, 223, 39, 57, 121, 36, 49, 203, 18, 239, 173, 119, 47, 68, 27, 114, 231, 34, 245 },
                            Status = 1
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.UserOperationClaim", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("CreatedBy");

                    b.Property<DateTime>("CreatedDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("CreatedDate");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("DeletedDate");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false)
                        .HasColumnName("IsDeleted");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("ModifiedDate");

                    b.Property<Guid>("OperationClaimId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("OperationClaimId");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1)
                        .HasColumnName("Status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex(new[] { "UserId", "OperationClaimId" }, "UK_UserOperationClaims_UserId_OperationClaimId")
                        .IsUnique();

                    b.ToTable("UserOperationClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("fb922621-1b33-494e-8fb8-aba2197a7d4b"),
                            CreatedBy = "Admin",
                            CreatedDate = new DateTime(2024, 2, 1, 15, 38, 35, 390, DateTimeKind.Local).AddTicks(3967),
                            IsDeleted = false,
                            OperationClaimId = new Guid("5ea19859-a3b1-4191-8429-8e840c8e83de"),
                            Status = 1,
                            UserId = new Guid("9925603e-4b1b-4822-b83a-5e57eb6e55c7")
                        });
                });

            modelBuilder.Entity("Core.Domain.Entities.About", b =>
                {
                    b.HasOne("Core.Domain.Entities.UploadedFile", "UploadedFile")
                        .WithMany("Abouts")
                        .HasForeignKey("UploadedFileId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("UploadedFile");
                });

            modelBuilder.Entity("Core.Domain.Entities.Dictionary", b =>
                {
                    b.HasOne("Core.Domain.Entities.Language", "Language")
                        .WithMany("Dictionaries")
                        .HasForeignKey("LanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Core.Domain.Entities.EmailAuthenticator", b =>
                {
                    b.HasOne("Core.Domain.Entities.User", "User")
                        .WithMany("EmailAuthenticators")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Domain.Entities.OtpAuthenticator", b =>
                {
                    b.HasOne("Core.Domain.Entities.User", "User")
                        .WithMany("OtpAuthenticators")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Domain.Entities.RefreshToken", b =>
                {
                    b.HasOne("Core.Domain.Entities.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Domain.Entities.UserOperationClaim", b =>
                {
                    b.HasOne("Core.Domain.Entities.OperationClaim", "OperationClaim")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Domain.Entities.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Domain.Entities.Language", b =>
                {
                    b.Navigation("Dictionaries");
                });

            modelBuilder.Entity("Core.Domain.Entities.OperationClaim", b =>
                {
                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Core.Domain.Entities.UploadedFile", b =>
                {
                    b.Navigation("Abouts");
                });

            modelBuilder.Entity("Core.Domain.Entities.User", b =>
                {
                    b.Navigation("EmailAuthenticators");

                    b.Navigation("OtpAuthenticators");

                    b.Navigation("RefreshTokens");

                    b.Navigation("UserOperationClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
