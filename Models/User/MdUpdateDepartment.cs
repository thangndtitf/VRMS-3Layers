using System;
namespace VRMS_3Layers.Models.User
{
	public class MdUpdateDepartment
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
    }
}

