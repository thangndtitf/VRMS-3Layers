using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VRMS_3Layers.Models.Customer;

public partial class CustomerDbContextcs : DbContext
{
    public CustomerDbContextcs()
    {
    }

    public CustomerDbContextcs(DbContextOptions<CustomerDbContextcs> options)
        : base(options)
    {
    }

    public virtual DbSet<MdCustomer> MdCustomers { get; set; }

    public virtual DbSet<MdCustomertype> MdCustomertypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost:5432; Database=VRMS_Postgre; Username=postgres; Password=thang123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MdCustomer>(entity =>
        {
            entity.HasKey(e => e.Customerid).HasName("MD_CUSTOMER_pkey");

            entity.ToTable("MD_CUSTOMER", "MD");

            entity.Property(e => e.Customerid)
                .HasPrecision(10)
                .HasComment("Mã khách hàng ")
                .HasColumnName("CUSTOMERID");
            entity.Property(e => e.Createddate)
                .HasComment("Ngày tạo ")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Customeremail)
                .HasMaxLength(1000)
                .HasComment("Email của khách hàng ")
                .HasColumnName("CUSTOMEREMAIL");
            entity.Property(e => e.Customerfirstname)
                .HasMaxLength(500)
                .HasComment("Họ khách hàng ")
                .HasColumnName("CUSTOMERFIRSTNAME");
            entity.Property(e => e.Customerfulladdress)
                .HasMaxLength(2000)
                .HasComment("Địa chỉ đầy đủ của khách hàng ")
                .HasColumnName("CUSTOMERFULLADDRESS");
            entity.Property(e => e.Customerfullname)
                .HasMaxLength(2000)
                .HasComment("Tên đầy đủ của khách hàng ")
                .HasColumnName("CUSTOMERFULLNAME");
            entity.Property(e => e.Customerlastname)
                .HasMaxLength(1500)
                .HasComment("Tên - tên đệm khách hàng ")
                .HasColumnName("CUSTOMERLASTNAME");
            entity.Property(e => e.Customerphone)
                .HasPrecision(20)
                .HasComment("SDT khách hàng ")
                .HasColumnName("CUSTOMERPHONE");
            entity.Property(e => e.Customertypeid)
                .HasPrecision(10)
                .HasComment("Mã loại khách hàng ")
                .HasColumnName("CUSTOMERTYPEID");
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
            entity.Property(e => e.Passworld)
                .HasMaxLength(200)
                .HasComment("Mật khẩu đăng nhập hệ thống")
                .HasColumnName("PASSWORLD");

            entity.HasOne(d => d.Customertype).WithMany(p => p.MdCustomers)
                .HasForeignKey(d => d.Customertypeid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CUSTOMERTYPEID");
        });

        modelBuilder.Entity<MdCustomertype>(entity =>
        {
            entity.HasKey(e => e.Customertypeid).HasName("MD_CUSTOMERTYPE_pkey");

            entity.ToTable("MD_CUSTOMERTYPE", "MD");

            entity.Property(e => e.Customertypeid)
                .HasPrecision(10)
                .HasComment("Mã loại khách hàng ")
                .HasColumnName("CUSTOMERTYPEID");
            entity.Property(e => e.Createddate)
                .HasComment("Ngày tạo ")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Customertypename)
                .HasMaxLength(1000)
                .HasComment("Tên loại khách hàng ")
                .HasColumnName("CUSTOMERTYPENAME");
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
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
