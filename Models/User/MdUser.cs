﻿using System;
using System.Collections.Generic;

namespace VRMS_3layers.Models.User;

/// <summary>
/// Danh sách nhân viên
/// </summary>
public partial class MdUser
{
    /// <summary>
    /// Mã nhân viên 
    /// </summary>
    public decimal Username { get; set; }

    /// <summary>
    /// Tên đầy đủ của nhân viên 
    /// </summary>
    public string Userfullname { get; set; } = null!;

    /// <summary>
    /// Ngày vào làm chính thức của nhân viên 
    /// </summary>
    public DateOnly Insitedate { get; set; }

    /// <summary>
    /// Ngày nghỉ chính thức của nhân viên 
    /// </summary>
    public DateOnly? Outdate { get; set; }

    /// <summary>
    /// Đã được kích hoạt 
    /// </summary>
    public short? Isactived { get; set; }

    /// <summary>
    /// Ngày kích hoạt 
    /// </summary>
    public DateOnly? Activeddate { get; set; }

    /// <summary>
    /// Số CCCD/ CMND
    /// </summary>
    public string Usercardid { get; set; } = null!;

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
    /// Địa chỉ đầy đủ của NV 
    /// </summary>
    public string Userfulladdress { get; set; } = null!;

    /// <summary>
    /// Mã vị trí 
    /// </summary>
    public decimal Positionid { get; set; }

    /// <summary>
    /// Mã phòng ban 
    /// </summary>
    public decimal Departmentid { get; set; }
}
