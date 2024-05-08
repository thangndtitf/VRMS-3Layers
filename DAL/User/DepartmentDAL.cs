﻿using VRMS_3Layers.Models;

namespace VRMS_3layers.DAL.User
{
    public class DepartmentDAL
    {

        /*
         Hàm get All Department vẫn còn hiệu lực ( Isdeleted == 0 )
         */
        public static List<MdDepartment> getListDepartment()
        {
            List<MdDepartment> result = new List<MdDepartment>();
            using (var _userDbContext = new ModelsDbContextcs())
            {
                result = _userDbContext.MdDepartments.Where<MdDepartment>(d => d.Isdeleted == 0).ToList();
            }
            return result;
        }

        /*
         Hàm get 1 Department bằng departmentID
         */
        public static MdDepartment getDepartById(decimal departmentId)
        {
            MdDepartment? mdDepartment = null;
            using(var _userDbContext = new ModelsDbContextcs())
            {
                mdDepartment = _userDbContext.MdDepartments.FirstOrDefault(d => d.Departmentid == departmentId);
            }
            return mdDepartment;
        }

        public static MdDepartment insertNewDepartment(MdDepartment department)
        {
            MdDepartment result = null;
            using (var _userDbContext = new ModelsDbContextcs())
            {
                _userDbContext.MdDepartments.Add(department);
                _userDbContext.SaveChanges();
                result = department;
            }
            return result;
        }

        /*
         Hàm Update dữ liệu Department dựa vào ID
         */
        public static MdDepartment updateDepartment(MdUpdateDepartment department)
        {
            MdDepartment result = null;
            using (var  _userDbContext = new ModelsDbContextcs())
            {
                result = _userDbContext.MdDepartments.FirstOrDefault(d => d.Departmentid == department.Departmentid);
                result.Departmentname = department.Departmentname;
                result.Description = department.Description;
                _userDbContext.SaveChanges();
            }
            return result;
        }

        /*
         Hàm để lấy ID cuối cùng của Department
         */
        public static decimal getLastIdOfDepartment()
        {
            decimal result = 0;
            using (var _userDbContext = new ModelsDbContextcs())
            {
                result = _userDbContext.MdDepartments.Max(d => d.Departmentid);
            }
            return result;
        }

        /*
         Hàm để insert data mới cho Department
         */
        public static MdDepartment addNewDepartment(MdDepartment newDepartment)
        {
            MdDepartment updateDepartment = null;
            using (var _userDbContext = new ModelsDbContextcs())
            {
                try
                {
                    newDepartment.Departmentid = getLastIdOfDepartment() + 1;
                    newDepartment.Createddate = DateOnly.FromDateTime(DateTime.Now);
                    _userDbContext.Add(newDepartment);
                    _userDbContext.SaveChanges();
                    updateDepartment = newDepartment;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString);
                }
            }
                return updateDepartment;
        }

        /*
         Hàm dùng để xoá dữ liệu Department dựa vào ID
         */
        public static Boolean deleteDepartment(decimal deleteDepartmentId)
        {
            Boolean result = false;
            using (var _userDbContext = new ModelsDbContextcs())
            {
                try
                {
                        MdDepartment checkedDepartment = _userDbContext.MdDepartments.FirstOrDefault(d => d.Departmentid == deleteDepartmentId);
                        if (checkedDepartment == null)
                        {
                            result = false;
                        }
                        else
                        {
                            checkedDepartment.Isdeleted = 1;
                            checkedDepartment.Deleteddate = DateOnly.FromDateTime(DateTime.Now);
                            _userDbContext.SaveChanges();
                            result = true;
                        }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

                return result;
        }

    }
}
