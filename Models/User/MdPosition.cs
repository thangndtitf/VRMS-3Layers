using System;
using System.Collections.Generic;

namespace VRMS_3layers.Models.User;

/// <summary>
/// Danh sách vị trí
/// </summary>
public partial class MdPosition
{
    /// <summary>
    /// Mã vị trí nhân viên 
    /// </summary>
    public decimal Positionid { get; set; }

    /// <summary>
    /// Tên vị trí nhân viên 
    /// </summary>
    public string Positionname { get; set; } = null!;

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
