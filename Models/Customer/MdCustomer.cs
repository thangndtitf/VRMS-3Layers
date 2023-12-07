using System;
using System.Collections.Generic;

namespace VRMS_3layers.Models.Customer;

public partial class MdCustomer
{
    /// <summary>
    /// Mã khách hàng 
    /// </summary>
    public decimal Customerid { get; set; }

    /// <summary>
    /// Mã loại khách hàng 
    /// </summary>
    public decimal Customertypeid { get; set; }

    /// <summary>
    /// Tên đầy đủ của khách hàng 
    /// </summary>
    public string Customerfullname { get; set; } = null!;

    /// <summary>
    /// Họ khách hàng 
    /// </summary>
    public string Customerfirstname { get; set; } = null!;

    /// <summary>
    /// Tên - tên đệm khách hàng 
    /// </summary>
    public string Customerlastname { get; set; } = null!;

    /// <summary>
    /// SDT khách hàng 
    /// </summary>
    public decimal Customerphone { get; set; }

    /// <summary>
    /// Email của khách hàng 
    /// </summary>
    public string? Customeremail { get; set; }

    /// <summary>
    /// Địa chỉ đầy đủ của khách hàng 
    /// </summary>
    public string Customerfulladdress { get; set; } = null!;

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
    /// Mật khẩu đăng nhập hệ thống
    /// </summary>
    public string Passworld { get; set; } = null!;

 
}
