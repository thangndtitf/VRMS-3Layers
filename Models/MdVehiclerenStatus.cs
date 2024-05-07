using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

public partial class MdVehiclerenStatus
{
    /// <summary>
    /// Mã trạng thái 
    /// </summary>
    public decimal Vehiclerenstatusid { get; set; }

    /// <summary>
    /// Tên trạng thái 
    /// </summary>
    public string Vehiclerenstatusname { get; set; } = null!;

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
