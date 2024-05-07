using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

/// <summary>
/// Loại hình thức thuê 
/// </summary>
public partial class MdVehiclerentaltype
{
    public decimal Vehiclerentaltypeid { get; set; }

    /// <summary>
    /// Tên loại hình thức thuê 
    /// </summary>
    public string Vehiclerentaltypename { get; set; } = null!;

    /// <summary>
    /// Là hình thức thuê theo chuyến 
    /// </summary>
    public decimal Isrenbyroute { get; set; }

    /// <summary>
    /// Là hình thức thuê theo ngày 
    /// </summary>
    public decimal Isrenbydate { get; set; }

    /// <summary>
    /// Là hình thức thuê theo tháng 
    /// </summary>
    public decimal Isrenbymonth { get; set; }

    /// <summary>
    /// Mô tả 
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Đã xoá 
    /// </summary>
    public short Isdeleted { get; set; }

    /// <summary>
    /// Ngày xoá 
    /// </summary>
    public DateOnly? Deleteddate { get; set; }

    /// <summary>
    /// Ngày tạo 
    /// </summary>
    public DateOnly Createddate { get; set; }
}
