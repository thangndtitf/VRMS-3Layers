using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VRMS_3Layers.Models;

public partial class ModelsDbContextcs : DbContext
{
    public ModelsDbContextcs()
    {
    }

    public ModelsDbContextcs(DbContextOptions<ModelsDbContextcs> options)
        : base(options)
    {
    }

    public virtual DbSet<MdCustomer> MdCustomers { get; set; }

    public virtual DbSet<MdCustomertype> MdCustomertypes { get; set; }

    public virtual DbSet<MdDepartment> MdDepartments { get; set; }

    public virtual DbSet<MdPosition> MdPositions { get; set; }

    public virtual DbSet<MdPricetableaplly> MdPricetableapllies { get; set; }

    public virtual DbSet<MdStore> MdStores { get; set; }

    public virtual DbSet<MdStoreUser> MdStoreUsers { get; set; }

    public virtual DbSet<MdStoretype> MdStoretypes { get; set; }

    public virtual DbSet<MdStorevehicle> MdStorevehicles { get; set; }

    public virtual DbSet<MdUser> MdUsers { get; set; }

    public virtual DbSet<MdVehicle> MdVehicles { get; set; }

    public virtual DbSet<MdVehiclegroup> MdVehiclegroups { get; set; }

    public virtual DbSet<MdVehiclepaymentreqtype> MdVehiclepaymentreqtypes { get; set; }

    public virtual DbSet<MdVehiclerenStatus> MdVehiclerenStatuses { get; set; }

    public virtual DbSet<MdVehiclerenStep> MdVehiclerenSteps { get; set; }

    public virtual DbSet<MdVehiclerenWfnextstep> MdVehiclerenWfnextsteps { get; set; }

    public virtual DbSet<MdVehiclerenWorkflow> MdVehiclerenWorkflows { get; set; }

    public virtual DbSet<MdVehiclerentalordertype> MdVehiclerentalordertypes { get; set; }

    public virtual DbSet<MdVehiclerentaltype> MdVehiclerentaltypes { get; set; }

    public virtual DbSet<MdVehicletype> MdVehicletypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=VRMS_Postgre;Username=postgres;Password=thang123");

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

        modelBuilder.Entity<MdPricetableaplly>(entity =>
        {
            entity.HasKey(e => new { e.Vehicletypeid, e.Vehiclerentaltypeid, e.Pricetableapllyid }).HasName("MD_PRICETABLEAPLLY_pkey");

            entity.ToTable("MD_PRICETABLEAPLLY", "MD", tb => tb.HasComment("Bảng giá áp dụng "));

            entity.Property(e => e.Vehicletypeid)
                .HasPrecision(10)
                .HasComment("Mã loại xe ")
                .HasColumnName("VEHICLETYPEID");
            entity.Property(e => e.Vehiclerentaltypeid)
                .HasPrecision(10)
                .HasColumnName("VEHICLERENTALTYPEID");
            entity.Property(e => e.Pricetableapllyid)
                .HasPrecision(10)
                .HasComment("Khoá chính ")
                .HasColumnName("PRICETABLEAPLLYID");
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
            entity.Property(e => e.Districtname)
                .HasMaxLength(1000)
                .HasComment("Tên quận/huyện ")
                .HasColumnName("DISTRICTNAME");
            entity.Property(e => e.Isdeleted)
                .HasComment("Đã xoá ")
                .HasColumnName("ISDELETED");
            entity.Property(e => e.Provincename)
                .HasMaxLength(1000)
                .HasComment("Tên tỉnh thành ")
                .HasColumnName("PROVINCENAME");
            entity.Property(e => e.Wardname)
                .HasMaxLength(1000)
                .HasComment("Tên phường/xã")
                .HasColumnName("WARDNAME");
        });

        modelBuilder.Entity<MdStore>(entity =>
        {
            entity.HasKey(e => e.Storeid).HasName("MD_STORE_pkey");

            entity.ToTable("MD_STORE", "MD", tb => tb.HasComment("Danh sách kho"));

            entity.Property(e => e.Storeid)
                .HasPrecision(10)
                .HasComment("Mã kho ")
                .HasColumnName("STOREID");
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
            entity.Property(e => e.Storefulladdress)
                .HasMaxLength(2000)
                .HasComment("Địa chỉ đầy đủ của kho ")
                .HasColumnName("STOREFULLADDRESS");
            entity.Property(e => e.Storename)
                .HasPrecision(1000)
                .HasComment("Tên kho ")
                .HasColumnName("STORENAME");
            entity.Property(e => e.Storetypeid)
                .HasPrecision(10)
                .HasComment("Mã loại kho ")
                .HasColumnName("STORETYPEID");
        });

        modelBuilder.Entity<MdStoreUser>(entity =>
        {
            entity.HasKey(e => new { e.Storeid, e.Username }).HasName("MD_STORE_USER_pkey");

            entity.ToTable("MD_STORE_USER", "MD", tb => tb.HasComment("Bảng map user này thuộc kho nào"));

            entity.Property(e => e.Storeid)
                .HasPrecision(10)
                .HasComment("Mã kho ")
                .HasColumnName("STOREID");
            entity.Property(e => e.Username)
                .HasPrecision(10)
                .HasComment("Mã nhân viên ")
                .HasColumnName("USERNAME");
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
        });

        modelBuilder.Entity<MdStoretype>(entity =>
        {
            entity.HasKey(e => e.Storetypeid).HasName("MD_STORETYPE_pkey");

            entity.ToTable("MD_STORETYPE", "MD", tb => tb.HasComment("Loại kho"));

            entity.Property(e => e.Storetypeid)
                .HasPrecision(10)
                .HasComment("Mã loại kho ")
                .HasColumnName("STORETYPEID");
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
            entity.Property(e => e.Storetypename)
                .HasMaxLength(1000)
                .HasComment("Tên loại kho ")
                .HasColumnName("STORETYPENAME");
        });

        modelBuilder.Entity<MdStorevehicle>(entity =>
        {
            entity.HasKey(e => new { e.Storeid, e.Vehicleid }).HasName("MD_STOREVEHICLES_pkey");

            entity.ToTable("MD_STOREVEHICLES", "MD", tb => tb.HasComment("Bảng map xe này thuộc kho nào "));

            entity.Property(e => e.Storeid)
                .HasPrecision(10)
                .HasComment("Mã kho ")
                .HasColumnName("STOREID");
            entity.Property(e => e.Vehicleid)
                .HasPrecision(10)
                .HasComment("Mã xe")
                .HasColumnName("VEHICLEID");
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

        modelBuilder.Entity<MdVehicle>(entity =>
        {
            entity.HasKey(e => e.Vehicleid).HasName("_copy_16");

            entity.ToTable("MD_VEHICLE", "MD", tb => tb.HasComment("Danh sách chiếc xe"));

            entity.Property(e => e.Vehicleid)
                .ValueGeneratedNever()
                .HasComment("Mã xe ")
                .HasColumnName("VEHICLEID");
            entity.Property(e => e.Createddate)
                .HasComment("Ngày tạo ")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Deleteddate)
                .HasComment("Ngày xoá ")
                .HasColumnName("DELETEDDATE");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .HasComment("Mô tả ")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Isdeleted)
                .HasComment("Đã xoá ")
                .HasColumnName("ISDELETED");
            entity.Property(e => e.Vehiclename)
                .HasMaxLength(1000)
                .HasComment("Tên xe ")
                .HasColumnName("VEHICLENAME");
        });

        modelBuilder.Entity<MdVehiclegroup>(entity =>
        {
            entity.HasKey(e => e.Vehiclegroupid).HasName("_copy_1");

            entity.ToTable("MD_VEHICLEGROUP", "MD", tb => tb.HasComment("Nhóm xe "));

            entity.Property(e => e.Vehiclegroupid)
                .HasPrecision(10)
                .HasComment("Mã nhóm phương tiện ")
                .HasColumnName("VEHICLEGROUPID");
            entity.Property(e => e.Createddate)
                .HasComment("Ngày tạo ")
                .HasColumnName("CREATEDDATE");
            entity.Property(e => e.Deleteddate)
                .HasComment("Ngày xoá ")
                .HasColumnName("DELETEDDATE");
            entity.Property(e => e.Description)
                .HasMaxLength(2000)
                .IsFixedLength()
                .HasComment("Mô tả ")
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.Isdeleted)
                .HasComment("Đã xoá ")
                .HasColumnName("ISDELETED");
            entity.Property(e => e.Vehiclegroupname)
                .HasMaxLength(1000)
                .IsFixedLength()
                .HasComment("Tên nhóm phương tiện ")
                .HasColumnName("VEHICLEGROUPNAME");
        });

        modelBuilder.Entity<MdVehiclepaymentreqtype>(entity =>
        {
            entity.HasKey(e => e.Vehiclepaymentreqtypeid).HasName("MD_VEHICLEPAYMENTREQTYPE_pkey");

            entity.ToTable("MD_VEHICLEPAYMENTREQTYPE", "MD");

            entity.Property(e => e.Vehiclepaymentreqtypeid)
                .HasPrecision(10)
                .HasComment("Mã loại yêu cầu thanh toán ")
                .HasColumnName("VEHICLEPAYMENTREQTYPEID");
            entity.Property(e => e.Paymentmethodid)
                .HasPrecision(20)
                .HasComment("Mã hình thưc thanh toán : 1- CASH; 2-CK; 3-QUẸT THẺ")
                .HasColumnName("PAYMENTMETHODID");
            entity.Property(e => e.Vehiclepaymentname)
                .HasMaxLength(2000)
                .HasComment("Tên loại yêu cầu thanh toán ")
                .HasColumnName("VEHICLEPAYMENTNAME");
        });

        modelBuilder.Entity<MdVehiclerenStatus>(entity =>
        {
            entity.HasKey(e => e.Vehiclerenstatusid).HasName("_copy_9");

            entity.ToTable("MD_VEHICLEREN_STATUS", "MD");

            entity.Property(e => e.Vehiclerenstatusid)
                .HasPrecision(10)
                .HasComment("Mã trạng thái ")
                .HasColumnName("VEHICLERENSTATUSID");
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
            entity.Property(e => e.Vehiclerenstatusname)
                .HasMaxLength(1000)
                .HasComment("Tên trạng thái ")
                .HasColumnName("VEHICLERENSTATUSNAME");
        });

        modelBuilder.Entity<MdVehiclerenStep>(entity =>
        {
            entity.HasKey(e => e.Vehiclerenstepid).HasName("_copy_8");

            entity.ToTable("MD_VEHICLEREN_STEP", "MD");

            entity.Property(e => e.Vehiclerenstepid)
                .HasPrecision(10)
                .HasComment("Mã bước xử lý ")
                .HasColumnName("VEHICLERENSTEPID");
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
            entity.Property(e => e.Vehiclerenstatus)
                .HasMaxLength(1000)
                .HasComment("Tên bước xử lý ")
                .HasColumnName("VEHICLERENSTATUS");
        });

        modelBuilder.Entity<MdVehiclerenWfnextstep>(entity =>
        {
            entity.HasKey(e => new { e.Vehiclerentalordertypeid, e.Vehiclerenstepid, e.Vehiclerennextstepid }).HasName("_copy_2");

            entity.ToTable("MD_VEHICLEREN_WFNEXTSTEP", "MD");

            entity.Property(e => e.Vehiclerentalordertypeid)
                .HasPrecision(10)
                .HasComment("Mã loại đơn hàng thuê ")
                .HasColumnName("VEHICLERENTALORDERTYPEID");
            entity.Property(e => e.Vehiclerenstepid)
                .HasPrecision(10)
                .HasComment("Mã bước xử lý ")
                .HasColumnName("VEHICLERENSTEPID");
            entity.Property(e => e.Vehiclerennextstepid)
                .HasPrecision(10)
                .HasComment("Mã khoá chính bước xử lý kế tiếp ")
                .HasColumnName("VEHICLERENNEXTSTEPID");
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
        });

        modelBuilder.Entity<MdVehiclerenWorkflow>(entity =>
        {
            entity.HasKey(e => new { e.Vehiclerentalordertypeid, e.Vehiclerenstepid }).HasName("_copy_7");

            entity.ToTable("MD_VEHICLEREN_WORKFLOW", "MD");

            entity.Property(e => e.Vehiclerentalordertypeid)
                .HasPrecision(10)
                .HasComment("Mã loại đơn hàng thuê ")
                .HasColumnName("VEHICLERENTALORDERTYPEID");
            entity.Property(e => e.Vehiclerenstepid)
                .HasPrecision(10)
                .HasComment("Mã bước xử lý ")
                .HasColumnName("VEHICLERENSTEPID");
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
            entity.Property(e => e.Isfinishstep)
                .HasPrecision(1)
                .HasComment("Là bước kết thúc ")
                .HasColumnName("ISFINISHSTEP");
            entity.Property(e => e.Isinitstep)
                .HasPrecision(1)
                .HasComment("Là bước khởi đầu ")
                .HasColumnName("ISINITSTEP");
            entity.Property(e => e.Vehiclerenstatusid)
                .HasPrecision(10)
                .HasComment("Mã trạng thái ")
                .HasColumnName("VEHICLERENSTATUSID");
        });

        modelBuilder.Entity<MdVehiclerentalordertype>(entity =>
        {
            entity.HasKey(e => e.Vehiclerentalordertypeid).HasName("public.MD_VEHICLERENTALORDERTYPE_pkey");

            entity.ToTable("MD_VEHICLERENTALORDERTYPE", "MD");

            entity.Property(e => e.Vehiclerentalordertypeid)
                .HasPrecision(10)
                .HasComment("Mã loại đơn hàng thuê ")
                .HasColumnName("VEHICLERENTALORDERTYPEID");
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
            entity.Property(e => e.Vehiclerentalordertypename)
                .HasMaxLength(500)
                .HasComment("Tên loại đơn hàng ")
                .HasColumnName("VEHICLERENTALORDERTYPENAME");
        });

        modelBuilder.Entity<MdVehiclerentaltype>(entity =>
        {
            entity.HasKey(e => e.Vehiclerentaltypeid).HasName("MD_VEHICLERENTALTYPE_pkey");

            entity.ToTable("MD_VEHICLERENTALTYPE", "MD", tb => tb.HasComment("Loại hình thức thuê "));

            entity.Property(e => e.Vehiclerentaltypeid)
                .HasPrecision(10)
                .HasColumnName("VEHICLERENTALTYPEID");
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
            entity.Property(e => e.Isrenbydate)
                .HasPrecision(1)
                .HasComment("Là hình thức thuê theo ngày ")
                .HasColumnName("ISRENBYDATE");
            entity.Property(e => e.Isrenbymonth)
                .HasPrecision(1)
                .HasComment("Là hình thức thuê theo tháng ")
                .HasColumnName("ISRENBYMONTH");
            entity.Property(e => e.Isrenbyroute)
                .HasPrecision(1)
                .HasComment("Là hình thức thuê theo chuyến ")
                .HasColumnName("ISRENBYROUTE");
            entity.Property(e => e.Vehiclerentaltypename)
                .HasMaxLength(1000)
                .HasComment("Tên loại hình thức thuê ")
                .HasColumnName("VEHICLERENTALTYPENAME");
        });

        modelBuilder.Entity<MdVehicletype>(entity =>
        {
            entity.HasKey(e => e.Vehicletypeid).HasName("_copy_17");

            entity.ToTable("MD_VEHICLETYPE", "MD", tb => tb.HasComment("Loại xe"));

            entity.Property(e => e.Vehicletypeid)
                .ValueGeneratedNever()
                .HasComment("Mã loại phương tiện ")
                .HasColumnName("VEHICLETYPEID");
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
            entity.Property(e => e.Height)
                .HasComment("Chiều cao tổng thể của xe (m) ")
                .HasColumnName("HEIGHT");
            entity.Property(e => e.Isdeleted)
                .HasComment("Đã xoá ")
                .HasColumnName("ISDELETED");
            entity.Property(e => e.Lenght)
                .HasComment("Chiều cao tổng thể của xe ")
                .HasColumnName("LENGHT");
            entity.Property(e => e.Vehiclegroupid)
                .HasPrecision(10)
                .HasComment("Mã nhóm xe ")
                .HasColumnName("VEHICLEGROUPID");
            entity.Property(e => e.Vehicletypename)
                .HasMaxLength(1000)
                .HasComment("Tên loại phương tiện ")
                .HasColumnName("VEHICLETYPENAME");
            entity.Property(e => e.Volume)
                .HasComment("Thể tích của thùng xe ")
                .HasColumnName("VOLUME");
            entity.Property(e => e.Weight)
                .HasComment("Trọng tải tối đa của xe ( Tấn ) ")
                .HasColumnName("WEIGHT");
            entity.Property(e => e.Width)
                .HasComment("Chiều rộng tối tổng thể của xe (m) ")
                .HasColumnName("WIDTH");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
