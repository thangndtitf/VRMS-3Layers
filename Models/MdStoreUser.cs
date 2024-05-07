using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

/// <summary>
/// Bảng map user này thuộc kho nào
/// </summary>
public partial class MdStoreUser
{
    /// <summary>
    /// Mã kho 
    /// </summary>
    public decimal Storeid { get; set; }

    /// <summary>
    /// Mã nhân viên 
    /// </summary>
    public decimal Username { get; set; }

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
