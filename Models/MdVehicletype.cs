using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

/// <summary>
/// Loại xe
/// </summary>
public partial class MdVehicletype
{
    /// <summary>
    /// Mã loại phương tiện 
    /// </summary>
    public int Vehicletypeid { get; set; }

    /// <summary>
    /// Tên loại phương tiện 
    /// </summary>
    public string Vehicletypename { get; set; } = null!;

    /// <summary>
    /// Mã nhóm xe 
    /// </summary>
    public decimal Vehiclegroupid { get; set; }

    /// <summary>
    /// Trọng tải tối đa của xe ( Tấn ) 
    /// </summary>
    public long Weight { get; set; }

    /// <summary>
    /// Chiều cao tổng thể của xe (m) 
    /// </summary>
    public long Height { get; set; }

    /// <summary>
    /// Chiều rộng tối tổng thể của xe (m) 
    /// </summary>
    public long Width { get; set; }

    /// <summary>
    /// Chiều cao tổng thể của xe 
    /// </summary>
    public long Lenght { get; set; }

    /// <summary>
    /// Thể tích của thùng xe 
    /// </summary>
    public long Volume { get; set; }

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
