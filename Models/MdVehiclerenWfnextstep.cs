using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

public partial class MdVehiclerenWfnextstep
{
    /// <summary>
    /// Mã loại đơn hàng thuê 
    /// </summary>
    public decimal Vehiclerentalordertypeid { get; set; }

    /// <summary>
    /// Mã bước xử lý 
    /// </summary>
    public decimal Vehiclerenstepid { get; set; }

    /// <summary>
    /// Mã khoá chính bước xử lý kế tiếp 
    /// </summary>
    public decimal Vehiclerennextstepid { get; set; }

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
