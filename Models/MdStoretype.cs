using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

/// <summary>
/// Loại kho
/// </summary>
public partial class MdStoretype
{
    /// <summary>
    /// Mã loại kho 
    /// </summary>
    public decimal Storetypeid { get; set; }

    /// <summary>
    /// Tên loại kho 
    /// </summary>
    public string Storetypename { get; set; } = null!;

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
