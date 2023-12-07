using System;
using System.Collections.Generic;

namespace VRMS_3Layers.Models.Customer;

public partial class MdCustomertype
{
    /// <summary>
    /// Mã loại khách hàng 
    /// </summary>
    public decimal Customertypeid { get; set; }

    /// <summary>
    /// Tên loại khách hàng 
    /// </summary>
    public string Customertypename { get; set; } = null!;

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

    public virtual ICollection<MdCustomer> MdCustomers { get; set; } = new List<MdCustomer>();
}
