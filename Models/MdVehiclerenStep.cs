using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

public partial class MdVehiclerenStep
{
    /// <summary>
    /// Mã bước xử lý 
    /// </summary>
    public decimal Vehiclerenstepid { get; set; }

    /// <summary>
    /// Tên bước xử lý 
    /// </summary>
    public string Vehiclerenstatus { get; set; } = null!;

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
