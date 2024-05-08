
using VRMS_3Layers.Models;

namespace VRMS_3layers.DAL.User
{
    public class UserDAL
    {

        /*
         Hàm get All thông tin User
         */
        public static List<MdUser> getListUsers()
        {
            List<MdUser> result = new List<MdUser>();

            using(var _modelDbContext = new ModelsDbContextcs())
            {
                _modelDbContext.MdUsers.Where<MdUser>(c => c.Isdeleted == 0).ToList();
            }
            return result;
        }

        /*
         Hàm get 1 user by ID 
         */
        public static MdUser getUserById(decimal userId)
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
        public static decimal getLastUserId()
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
        public static MdUser insertUser(MdUser mdUser)
        {
            MdUser? result = null;
            using(var _modelDbContext = new ModelsDbContextcs())
            {
                try
                {
                    mdUser.Username = getLastUserId() + 1;
                    mdUser.Createddate = DateOnly.FromDateTime(DateTime.Now);
                    _modelDbContext.Add(mdUser);
                    _modelDbContext.SaveChanges();
                    result = mdUser;
                }
                catch (Exception ex)
                {

                }
            }
            return result;
        }
    }
}
