using VRMS_3Layers.Models;

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
            using (var _modelDbContext = new ModelsDbContextcs())
            {
                result = _modelDbContext.MdDepartments.Where<MdDepartment>(d => d.Isdeleted == 0).ToList();
            }
            return result;
        }

        /*
         Hàm get 1 Department bằng departmentID
         */
        public static MdDepartment getDepartById(decimal departmentId)
        {
            MdDepartment? mdDepartment = null;
            using(var _modelDbContext = new ModelsDbContextcs())
            {
                mdDepartment = _modelDbContext.MdDepartments.FirstOrDefault(d => d.Departmentid == departmentId);
            }
            return mdDepartment;
        }

        public static MdDepartment insertNewDepartment(MdDepartment department)
        {
            MdDepartment result = null;
            using (var _modelDbContext = new ModelsDbContextcs())
            {
                _modelDbContext.MdDepartments.Add(department);
                _modelDbContext.SaveChanges();
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
            using (var  _modelDbContext = new ModelsDbContextcs())
            {
                result = _modelDbContext.MdDepartments.FirstOrDefault(d => d.Departmentid == department.Departmentid);
                result.Departmentname = department.Departmentname;
                result.Description = department.Description;
                _modelDbContext.SaveChanges();
            }
            return result;
        }

        /*
         Hàm để lấy ID cuối cùng của Department
         */
        public static decimal getLastIdOfDepartment()
        {
            decimal result = 0;
            using (var _modelDbContext = new ModelsDbContextcs())
            {
                result = _modelDbContext.MdDepartments.Max(d => d.Departmentid);
            }
            return result;
        }

        /*
         Hàm để insert data mới cho Department
         */
        public static MdDepartment addNewDepartment(MdDepartment newDepartment)
        {
            MdDepartment updateDepartment = null;
            using (var _modelDbContext = new ModelsDbContextcs())
            {
                try
                {
                    newDepartment.Departmentid = getLastIdOfDepartment() + 1;
                    newDepartment.Createddate = DateOnly.FromDateTime(DateTime.Now);
                    _modelDbContext.Add(newDepartment);
                    _modelDbContext.SaveChanges();
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
            using (var _modelDbContext = new ModelsDbContextcs())
            {
                try
                {
                        MdDepartment checkedDepartment = _modelDbContext.MdDepartments.FirstOrDefault(d => d.Departmentid == deleteDepartmentId);
                        if (checkedDepartment == null)
                        {
                            result = false;
                        }
                        else
                        {
                            checkedDepartment.Isdeleted = 1;
                            checkedDepartment.Deleteddate = DateOnly.FromDateTime(DateTime.Now);
                            _modelDbContext.SaveChanges();
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
