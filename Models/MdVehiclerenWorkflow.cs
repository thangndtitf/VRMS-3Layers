using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

public partial class MdVehiclerenWorkflow
{
    /// <summary>
    /// Mã loại đơn hàng thuê 
    /// </summary>
    public decimal Vehiclerentalordertypeid { get; set; }

    /// <summary>
    /// Mã bước xử lý 
    /// </summary>
    public decimal Vehiclerenstepid { get; set; }

    /// <summary>
    /// Mã trạng thái 
    /// </summary>
    public decimal Vehiclerenstatusid { get; set; }

    /// <summary>
    /// Là bước khởi đầu 
    /// </summary>
    public decimal Isinitstep { get; set; }

    /// <summary>
    /// Là bước kết thúc 
    /// </summary>
    public decimal Isfinishstep { get; set; }

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
