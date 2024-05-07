using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

/// <summary>
/// Danh sách chiếc xe
/// </summary>
public partial class MdVehicle
{
    /// <summary>
    /// Mã xe 
    /// </summary>
    public int Vehicleid { get; set; }

    /// <summary>
    /// Tên xe 
    /// </summary>
    public string Vehiclename { get; set; } = null!;

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
