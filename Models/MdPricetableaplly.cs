using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

/// <summary>
/// Bảng giá áp dụng 
/// </summary>
public partial class MdPricetableaplly
{
    /// <summary>
    /// Mã loại xe 
    /// </summary>
    public decimal Vehicletypeid { get; set; }

    public decimal Vehiclerentaltypeid { get; set; }

    /// <summary>
    /// Khoá chính 
    /// </summary>
    public decimal Pricetableapllyid { get; set; }

    /// <summary>
    /// Tên quận/huyện 
    /// </summary>
    public string Districtname { get; set; } = null!;

    /// <summary>
    /// Tên tỉnh thành 
    /// </summary>
    public string Provincename { get; set; } = null!;

    /// <summary>
    /// Tên phường/xã
    /// </summary>
    public string Wardname { get; set; } = null!;

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
