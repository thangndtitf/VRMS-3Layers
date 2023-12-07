using System;
using System.Collections.Generic;

namespace VRMS_3layers.Models.User;

/// <summary>
/// Danh sách phòng ban
/// </summary>
public partial class MdDepartment
{
    /// <summary>
    /// Mã phòng ban 
    /// </summary>
    public decimal Departmentid { get; set; }

    /// <summary>
    /// Tên phòng ban 
    /// </summary>
    public string Departmentname { get; set; } = null!;

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
