

using VRMS_3Layers.Models.User;

namespace VRMS_3layers.DAL.User
{
    public class DepartmentDAL
    {


        public static List<MdDepartment> getListDepartment()
        {
            List<MdDepartment> result = new List<MdDepartment>();
            using (var _userDbContext = new UserDbContextcs())
            {
                result = _userDbContext.MdDepartments.Where<MdDepartment>(d => d.Isdeleted == 0).ToList();
            }
            return result;
        }

        public static MdDepartment getDepartById(int departmentId)
        {
            MdDepartment? mdDepartment = null;
            using(var _userDbContext = new UserDbContextcs())
            {
                mdDepartment = _userDbContext.MdDepartments.FirstOrDefault(d => d.Departmentid == departmentId);
            }
            return mdDepartment;
        }

        public static MdDepartment insertNewDepartment(MdDepartment department)
        {
            MdDepartment result = null;
            using (var _userDbContext = new UserDbContextcs())
            {
                _userDbContext.MdDepartments.Add(department);
                _userDbContext.SaveChanges();
                result = department;
            }
            return result;
        }

        public static MdDepartment updateDepartment(MdDepartment department)
        {
            MdDepartment result = null;
            using (var  _userDbContext = new UserDbContextcs())
            {
                result = _userDbContext.MdDepartments.FirstOrDefault(d => d.Departmentid == department.Departmentid);
                result.Departmentname = department.Departmentname;
                result.Description = department.Description;
                _userDbContext.SaveChanges();
            }
            return result;
        }

        public static decimal getLastIdOfDepartment()
        {
            decimal result = 0;
            using (var _userDbContext = new UserDbContextcs())
            {
                result = _userDbContext.MdDepartments.Max(d => d.Departmentid);
            }
            return result;
        }


        public static MdDepartment addNewDepartment(MdDepartment newDepartment)
        {
            MdDepartment updateDepartment = null;
            using (var _userDbContext = new UserDbContextcs())
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

        public static MdDepartment findDepartmentById(decimal departmentId)
        {
            MdDepartment result = null;



            return result;
        }

    }
}
