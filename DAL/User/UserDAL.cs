using System.Reflection;
using Serilog;
using VRMS_3Layers.Models;

namespace VRMS_3layers.DAL.User
{
    public class UserDAL
    {

    /*
     Hàm get All thông tin User
     */
    public static List<MdUser> GetListUsers()
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/LogUserDAL.txt")
            .CreateLogger();


            Log.Information(">>> Begin GetListUsers >>> " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            List<MdUser> result = new List<MdUser>();

            using(var _modelDbContext = new ModelsDbContextcs())
            {
                _modelDbContext.MdUsers.Where<MdUser>(c => c.Isdeleted == 0).ToList();
            }

            Log.Information(">>> End GetListUsers >>> " + DateOnly.FromDateTime(DateTime.Now) + "\n");

            return result;

        }

        /*
         Hàm get 1 user by ID 
         */
        public static MdUser GetUserById(decimal userId)
        {
            MdUser? mdUser = null;

            using(var _modelDbContext = new ModelsDbContextcs())
            {
                mdUser = _modelDbContext.MdUsers.FirstOrDefault(u => u.Username == userId && u.Isactived == 1 && u.Isdeleted == 0);
            }

            return mdUser;
        }

        /*
         Hàm dùng để lấy được ID cuối cùng của dữ liệu Users
         */
        public static decimal GetLastUserId()
        {
            decimal result = 0;
            using(var _modelDbContext = new ModelsDbContextcs())
            {
                result = _modelDbContext.MdUsers.Max(u => u.Username);
            }
            return result;
        }

        /*
         Hàm dùng để insert dữ liệu mới cho User
         */
        public static MdUser InsertUser(MdUser mdUser)
        {
            MdUser? result = null;
            using(var _modelDbContext = new ModelsDbContextcs())
            {
                try
                {
                    mdUser.Username = GetLastUserId() + 1;
                    mdUser.Createddate = DateOnly.FromDateTime(DateTime.Now);
                    mdUser.Isactived = 1;
                    mdUser.Isdeleted = 0;
                    _modelDbContext.Add(mdUser);
                    _modelDbContext.SaveChanges();
                    result = mdUser;
                }
                catch (Exception ex)
                {
                    // NOTE nhớ ghi log phần này bắng Serilog
                    MethodBase currentMethod = MethodBase.GetCurrentMethod();
                    Log.Error(">>> Error at : " + currentMethod.Name + ex.ToString() + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
                }
            }
            return result;
        }

        /*
         Hàm dùng để Update dữ liệu User
         */
        public static MdUser UpdateUser(MdUpdateUser mdUpdateUser)
        {
            MdUser? result = null;
            using (var _modelDbContext = new ModelsDbContextcs())
            {
                result = _modelDbContext.MdUsers.FirstOrDefault(u => u.Username == mdUpdateUser.Username);
                if(result == null)
                {
                    return result;
                }
                else
                {
                    result.Userfullname = mdUpdateUser.Userfullname;
                    result.Insitedate = mdUpdateUser.Insitedate;
                    result.Isactived = mdUpdateUser.Isactived;
                    result.Usercardid = mdUpdateUser.Usercardid;
                    result.Description = mdUpdateUser.Description;
                    result.Userfulladdress = mdUpdateUser.Userfulladdress;
                }
            }
            return result;
        }

        /*
        Hàm dùng để xoá dữ liệu User 
        */
        public static Boolean DeleteUser(decimal userName)
        {
            Boolean result = false;
            using (var _modelDbContext = new ModelsDbContextcs())
            {
                MdUser checkUser = _modelDbContext.MdUsers.FirstOrDefault(u => u.Username == userName);
                if(checkUser.Isactived == 0 || checkUser.Isdeleted == 1)
                {
                    result = false;
                    return result;
                }
                else
                {
                    checkUser.Isactived = 0;
                    checkUser.Isdeleted = 1;
                    _modelDbContext.SaveChanges();
                    result = true;
                }
            }

            return result;
        }
    }
}
