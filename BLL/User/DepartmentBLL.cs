using Serilog;
using System.Reflection;
using VRMS_3layers.DAL.User;
using VRMS_3layers.Models.ResultObj;
using VRMS_3Layers.Models;

namespace VRMS_3layers.BLL.User
{
    public class DepartmentBLL
    {

        /*
         Hàm get All Department còn hiệu lực
         */
        public static ResultObject getListDepartment()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/DepartmentBLL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");

            ResultObject result = new ResultObject();
            List<MdDepartment> listDepartment = DepartmentDAL.getListDepartment();
            if(listDepartment != null)
            {
                

                for (int i = 0; i <= listDepartment.Count -2; i++)
                {
                    for (int j = 0; j <= listDepartment.Count -2; j++)
                    {
                        if (listDepartment[j].Departmentid > listDepartment[j + 1].Departmentid)
                        {
                            MdDepartment temp = listDepartment[j + 1];
                            listDepartment[j + 1] = listDepartment[j];
                            listDepartment[j] = temp;
                        }
                    }
                }

                result.isError = false;
                result.message = "Get List Department Success ";
                result.messageDetail = string.Empty;
                result.dataObject = listDepartment;
                
            }else if(listDepartment.Count <= 0)
            {
                result.isError = false;
                result.message = "List Department is empty ";
                result.messageDetail = string.Empty;
                result.dataObject = listDepartment;
            }
            else
            {
                result.isError = false;
                result.message = "List Department is Empty  ";
                result.messageDetail = string.Empty;
                result.dataObject = listDepartment;
            }

            Log.Information(">>> End >>> " + currentMethod.Name + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;
        }

        /*
         Hàm thêm mới Department 
         */
        public static ResultObject addNewDepartment(MdDepartment newDepartment)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/DepartmentBLL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");

            ResultObject result = new ResultObject();
            MdDepartment insertedDepartment = DepartmentDAL.addNewDepartment(newDepartment);
            if(insertedDepartment == null)
            {
                result.isError = true;
                result.message = "Add new department Failed";
                result.messageDetail = string.Empty;
                result.dataObject = insertedDepartment;
            }
            else
            {
                result.isError = false;
                result.message = "Add new department Success";
                result.messageDetail = string.Empty;
                result.dataObject = insertedDepartment;
            }

            Log.Information(">>> End >>> " + currentMethod.Name + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;
        }


        /*
         Hàm update dữ liệu Department
         */
        public static ResultObject updateDepartment(MdUpdateDepartment updateDepartment)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/DepartmentBLL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");

            ResultObject result = new ResultObject();

            if(updateDepartment == null)
            {
                result.isError = true;
                result.message = "Updated department with id : " + updateDepartment.Departmentid.ToString() + " is Failed";
                result.messageDetail = "Department is Null ";
                result.dataObject = updateDepartment;
            }
            else
            {
                try
                {
                    MdDepartment checkedDepartment = DepartmentDAL.getDepartById(updateDepartment.Departmentid);
                    if (checkedDepartment == null)
                    {
                        result.isError = true;
                        result.message = "Cannot find department with id : " + updateDepartment.Departmentid.ToString() ;
                        result.messageDetail = String.Empty;
                        result.dataObject = updateDepartment;
                    }
                    else
                    {

                        checkedDepartment = DepartmentDAL.updateDepartment(updateDepartment);
                        result.isError = false;
                        result.message = "Updated department with id : " + updateDepartment.Departmentid.ToString() + " is Success";
                        result.messageDetail = String.Empty;
                        result.dataObject = updateDepartment;
                    }
                }
                catch (Exception ex)
                {
                    result.isError = true;
                    result.message = "Update Department Faile" ;
                    result.messageDetail =ex.ToString();
                    result.dataObject = null;
                }
            }

            Log.Information(">>> End >>> " + currentMethod.Name + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;
        }

        /*
         Xoá dữ liệu Department dựa vào departmentID
         */
        public static ResultObject deleteDepartment(decimal deleteDepartmentId)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/DepartmentBLL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");

            ResultObject result = new ResultObject();

            if (deleteDepartmentId <= 0)
            {
                result.isError = true;
                result.message = "Delete Department Faile";
                result.messageDetail = "Department Id is <=0 ";
                result.dataObject = null;
            }
            else
            {
                Boolean checkDelete = DepartmentDAL.deleteDepartment(deleteDepartmentId);
                if(checkDelete == true)
                {
                    result.isError = false;
                    result.message = "Delete Department Success";
                    result.messageDetail = String.Empty;
                    result.dataObject = null;
                }
                else
                {
                    result.isError = true;
                    result.message = "Delete Department Faile";
                    result.messageDetail = String.Empty;
                    result.dataObject = null;
                }
            }

            Log.Information(">>> End >>> " + currentMethod.Name + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;
        }


    }
}
