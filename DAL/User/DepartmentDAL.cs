using System.Reflection;

using Serilog;

using VRMS_3Layers.Models;

namespace VRMS_3layers.DAL.User
{
    public class DepartmentDAL
    {

        //private static MethodBase currentMethod = MethodBase.GetCurrentMethod();
        /*
         Hàm get All Department vẫn còn hiệu lực ( Isdeleted == 0 )
         */
        public static List<MdDepartment> getListDepartment()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/LogUserDAL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");

            List<MdDepartment> result = new List<MdDepartment>();
            using (var _modelDbContext = new ModelsDbContextcs())
            {
                result = _modelDbContext.MdDepartments.Where<MdDepartment>(d => d.Isdeleted == 0).ToList();
            }

            Log.Information(">>> End getListDepartment >>> " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;
        }
            
        /*
         Hàm get 1 Department bằng departmentID
         */
        public static MdDepartment getDepartById(decimal departmentId)
        {

            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/LogUserDAL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");

            MdDepartment? mdDepartment = null;
            using(var _modelDbContext = new ModelsDbContextcs())
            {
                mdDepartment = _modelDbContext.MdDepartments.FirstOrDefault(d => d.Departmentid == departmentId);
            }

            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return mdDepartment;
        }

        public static MdDepartment insertNewDepartment(MdDepartment department)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/LogUserDAL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");

            MdDepartment result = null;
            using (var _modelDbContext = new ModelsDbContextcs())
            {
                _modelDbContext.MdDepartments.Add(department);
                _modelDbContext.SaveChanges();
                result = department;
            }

            Log.Information(">>> End >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;
        }

        /*
         Hàm Update dữ liệu Department dựa vào ID
         */
        public static MdDepartment updateDepartment(MdUpdateDepartment department)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/LogUserDAL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");

            MdDepartment result = null;
            using (var  _modelDbContext = new ModelsDbContextcs())
            {
                result = _modelDbContext.MdDepartments.FirstOrDefault(d => d.Departmentid == department.Departmentid);
                result.Departmentname = department.Departmentname;
                result.Description = department.Description;
                _modelDbContext.SaveChanges();
            }

            Log.Information(">>> End >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;
        }

        /*
         Hàm để lấy ID cuối cùng của Department
         */
        public static decimal getLastIdOfDepartment()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/LogUserDAL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");

            decimal result = 0;
            using (var _modelDbContext = new ModelsDbContextcs())
            {
                result = _modelDbContext.MdDepartments.Max(d => d.Departmentid);
            }

            Log.Information(">>> End >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;
        }

        /*
         Hàm để insert data mới cho Department
         */
        public static MdDepartment addNewDepartment(MdDepartment newDepartment)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/LogUserDAL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");

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

            Log.Information(">>> End >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return updateDepartment;
        }

        /*
         Hàm dùng để xoá dữ liệu Department dựa vào ID
         */
        public static Boolean deleteDepartment(decimal deleteDepartmentId)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/LogUserDAL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");

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
            Log.Information(">>> End >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;
        }

    }
}
