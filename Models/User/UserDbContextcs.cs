using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VRMS_3Layers.Models.User;

public partial class UserDbContextcs : DbContext
{
    public UserDbContextcs()
    {
    }

    public UserDbContextcs(DbContextOptions<UserDbContextcs> options)
        : base(options)
    {
    }

    public virtual DbSet<MdDepartment> MdDepartments { get; set; }

    public virtual DbSet<MdPosition> MdPositions { get; set; }

    public virtual DbSet<MdUser> MdUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5432; Database=VRMS_Postgre; Username=postgres; Password=thang123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MdDepartment>(entity =>
        {
            entity.HasKey(e => e.Departmentid).HasName("_copy_14");

            entity.ToTable("MD_DEPARTMENT", "MD", tb => tb.HasComment("Danh sách phòng ban"));

            entity.Property(e => e.Departmentid)
                .HasPrecision(10)
                .HasComment("Mã phòng ban ")
                .HasColumnName("DEPARTMENTID");
            entity.Property(e => e.Createddate)
                .HasComment("Ngày tạo ")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Deleteddate)
                .HasComment("Ngày xoá ")
                .HasColumnName("DELETEDDATE");
            entity.Property(e => e.Departmentname)
                .HasMaxLength(1000)
                .HasComment("Tên phòng ban ")
                .HasColumnName("DEPARTMENTNAME");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasComment("Mô tả ")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Isdeleted)
                .HasComment("Đã xoá ")
                .HasColumnName("ISDELETED");
        });

        modelBuilder.Entity<MdPosition>(entity =>
        {
            entity.HasKey(e => e.Positionid).HasName("_copy_15");

            entity.ToTable("MD_POSITION", "MD", tb => tb.HasComment("Danh sách vị trí"));

            entity.Property(e => e.Positionid)
                .HasPrecision(10)
                .HasComment("Mã vị trí nhân viên ")
                .HasColumnName("POSITIONID");
            entity.Property(e => e.Createddate)
                .HasComment("Ngày tạo ")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Deleteddate)
                .HasComment("Ngày xoá ")
                .HasColumnName("DELETEDDATE");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasComment("Mô tả ")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Isdeleted)
                .HasComment("Đã xoá ")
                .HasColumnName("ISDELETED");
            entity.Property(e => e.Positionname)
                .HasMaxLength(1000)
                .HasComment("Tên vị trí nhân viên ")
                .HasColumnName("POSITIONNAME");
        });

        modelBuilder.Entity<MdUser>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("_copy_13");

            entity.ToTable("MD_USER", "MD", tb => tb.HasComment("Danh sách nhân viên"));

            entity.Property(e => e.Username)
                .HasPrecision(10)
                .HasComment("Mã nhân viên ")
                .HasColumnName("USERNAME");
            entity.Property(e => e.Activeddate)
                .HasComment("Ngày kích hoạt ")
                .HasColumnName("ACTIVEDDATE");
            entity.Property(e => e.Createddate)
                .HasComment("Ngày tạo ")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Deleteddate)
                .HasComment("Ngày xoá ")
                .HasColumnName("DELETEDDATE");
            entity.Property(e => e.Departmentid)
                .HasPrecision(10)
                .HasComment("Mã phòng ban ")
                .HasColumnName("DEPARTMENTID");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasComment("Mô tả ")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Insitedate)
                .HasComment("Ngày vào làm chính thức của nhân viên ")
                .HasColumnName("INSITEDATE");
            entity.Property(e => e.Isactived)
                .HasComment("Đã được kích hoạt ")
                .HasColumnName("ISACTIVED");
            entity.Property(e => e.Isdeleted)
                .HasComment("Đã xoá ")
                .HasColumnName("ISDELETED");
            entity.Property(e => e.Outdate)
                .HasComment("Ngày nghỉ chính thức của nhân viên ")
                .HasColumnName("OUTDATE");
            entity.Property(e => e.Positionid)
                .HasPrecision(10)
                .HasComment("Mã vị trí ")
                .HasColumnName("POSITIONID");
            entity.Property(e => e.Usercardid)
                .HasMaxLength(500)
                .HasComment("Số CCCD/ CMND")
                .HasColumnName("USERCARDID");
            entity.Property(e => e.Userfulladdress)
                .HasMaxLength(3000)
                .HasComment("Địa chỉ đầy đủ của NV ")
                .HasColumnName("USERFULLADDRESS");
            entity.Property(e => e.Userfullname)
                .HasMaxLength(2000)
                .HasComment("Tên đầy đủ của nhân viên ")
                .HasColumnName("USERFULLNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
