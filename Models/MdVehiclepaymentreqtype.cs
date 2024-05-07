using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models;

public partial class MdVehiclepaymentreqtype
{
    /// <summary>
    /// Mã loại yêu cầu thanh toán 
    /// </summary>
    public decimal Vehiclepaymentreqtypeid { get; set; }

    /// <summary>
    /// Tên loại yêu cầu thanh toán 
    /// </summary>
    public string Vehiclepaymentname { get; set; } = null!;

    /// <summary>
    /// Mã hình thưc thanh toán : 1- CASH; 2-CK; 3-QUẸT THẺ
    /// </summary>
    public decimal Paymentmethodid { get; set; }
}
