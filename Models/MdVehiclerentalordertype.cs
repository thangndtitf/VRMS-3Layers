using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

public partial class MdVehiclerentalordertype
{
    /// <summary>
    /// Mã loại đơn hàng thuê 
    /// </summary>
    public decimal Vehiclerentalordertypeid { get; set; }

    /// <summary>
    /// Tên loại đơn hàng 
    /// </summary>
    public string Vehiclerentalordertypename { get; set; } = null!;

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
