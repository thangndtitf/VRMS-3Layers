using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

/// <summary>
/// Nhóm xe 
/// </summary>
public partial class MdVehiclegroup
{
    /// <summary>
    /// Mã nhóm phương tiện 
    /// </summary>
    public decimal Vehiclegroupid { get; set; }

    /// <summary>
    /// Tên nhóm phương tiện 
    /// </summary>
    public string Vehiclegroupname { get; set; } = null!;

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
