using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

/// <summary>
/// Danh sách kho
/// </summary>
public partial class MdStore
{
    /// <summary>
    /// Mã kho 
    /// </summary>
    public decimal Storeid { get; set; }

    /// <summary>
    /// Tên kho 
    /// </summary>
    public decimal Storename { get; set; }

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

    /// <summary>
    /// Mã loại kho 
    /// </summary>
    public decimal Storetypeid { get; set; }

    /// <summary>
    /// Địa chỉ đầy đủ của kho 
    /// </summary>
    public string Storefulladdress { get; set; } = null!;
}
