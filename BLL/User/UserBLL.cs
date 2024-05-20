using Serilog;
using System.Reflection;
using VRMS_3layers.DAL.User;
using VRMS_3layers.Models.ResultObj;
using VRMS_3Layers.Models;

namespace VRMS_3Layers.BLL.User
{
	public class UserBLL
	{

		/*
		 Hàm dùng để get List User còn hiệu lực 
		 */
		public static ResultObject GetListUser()
		{
            MethodBase currentMethod = MethodBase.GetCurrentMethod();

            Log.Information(">>> Begin : " + currentMethod.Name + "\n");

            ResultObject result = new ResultObject();
			List<MdUser> listUser = UserDAL.GetListUsers();
			if(listUser == null)
			{
                result.isError = true;
                result.message = "Get List User Error ";
				result.messageDetail = "List User is null";
                result.dataObject = null;
            }
			if(listUser.Count <= 0 )
			{
                result.isError = true;
                result.message = "Get List User Error ";
                result.messageDetail = "List User is Empty";
                result.dataObject = null;
            }
			else
			{
				for(int i = 0; i<= listUser.Count - 2; i++)
				{
					for (int j = 0; j < listUser.Count - 2; j++)
					{
						MdUser userTemp = listUser[j + 1];
						listUser[j + 1] = listUser[j];
						listUser[j] = userTemp;
					}
				}

                result.isError = false;
                result.message = "Get List User Success ";
                result.messageDetail = string.Empty; ;
                result.dataObject = listUser;
            }
            Log.Information(">>> End : " + currentMethod.Name + "\n");
            return result;
		}

		/*
		 Hàm để get User by ID
		*/
		public static ResultObject GetUserById(decimal userName)
		{
            MethodBase currentMethod = MethodBase.GetCurrentMethod();

            Log.Information(">>> Begin : " + currentMethod.Name + "\n");

            ResultObject result = new ResultObject();
			MdUser user = UserDAL.GetUserById(userName);

			if(user == null)
			{
                result.isError = true;
                result.message = "Get User with ID :" + userName + " Error!!!";
                result.messageDetail = "User " + userName + " is Empty";
                result.dataObject = null;
            }
			else if (user.Isdeleted == 1 || user.Isactived == 0)
			{
                result.isError = true;
                result.message = "Get User with ID :" + userName + " Error!!!";
                result.messageDetail = "User " + userName + " is Unactived";
                result.dataObject = null;
            }
			else
			{
				result.isError = false;
                result.message = "Get User " + userName + "Success ";
                result.messageDetail = string.Empty; ;
                result.dataObject = user;
            }
            Log.Information(">>> End : " + currentMethod.Name + "\n");
            return result;
		}

        /*
		 Hàm để insert mới dữ liệu User 
		 */
        public static ResultObject InsertNewUser(MdUser newUser)
        {
            MethodBase currentMethod = MethodBase.GetCurrentMethod();

            Log.Information(">>> Begin : " + currentMethod.Name + "\n");

            ResultObject result = new ResultObject();
            MdUser insertUser = UserDAL.InsertUser(newUser);
            if (insertUser == null)
            {
                result.isError = true;
                result.message = "Insert User Error";
                result.messageDetail = "Insert User " + insertUser.Username + " is Error";
                result.dataObject = null;
            }
            else if (insertUser.Isdeleted == 1 || insertUser.Isactived == 0)
            {

                Log.Error(">>> Error at : " + currentMethod.Name + "Insert User " + insertUser.Username + " is Deleted or Unactive " + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
                result.isError = true;
                result.message = "Insert User Error";
                result.messageDetail = "Insert User " + insertUser.Username + " is Deleted or Unactive ";
                result.dataObject = null;
            }
            else
            {
                result.isError = false;
                result.message = "Insert User " + insertUser.Username + "Success ";
                result.messageDetail = string.Empty; ;
                result.dataObject = insertUser;
            }
            Log.Information(">>> End : " + currentMethod.Name + "\n");
            return result;
        }

        /*
        Hàm để update dữ liệu User 
        */
        public static ResultObject UpdateUser(MdUpdateUser updateUser)
        {
            MethodBase currentMethod = MethodBase.GetCurrentMethod();

            Log.Information(">>> Begin : " + currentMethod.Name + "\n");

            ResultObject result = new ResultObject();
            MdUser updatedUser = UserDAL.UpdateUser(updateUser);
            if(updatedUser == null)
            {
                Log.Error(">>> Error at " + currentMethod.Name + DateOnly.FromDateTime(DateTime.Now) + "\n");
                result.isError = true;
                result.message = "Update User " + updateUser.Username + "is Error ";
                result.messageDetail = string.Empty; ;
                result.dataObject = null;
            }
            else if (updateUser.Isactived == 0)
            {
                Log.Information("Unactive User " + updateUser.Username + " at " + DateOnly.FromDateTime(DateTime.Now) + "\n");
                result.isError = false;
                result.message = "Update User " + updateUser.Username + "is Success ";
                result.messageDetail = "Unactive User " + updateUser.Username + DateOnly.FromDateTime(DateTime.Now);
                result.dataObject = null;
            }
            Log.Information(">>> End : " + currentMethod.Name + "\n");

            return result;
        }

        /*
        Hàm để delete dữ liệu User 
        */
        public static ResultObject DeleteUser(decimal userName)
        {
            MethodBase currentMethod = MethodBase.GetCurrentMethod();

            Log.Information(">>> Begin : " + currentMethod.Name + "\n");
            ResultObject result = new ResultObject();
            Boolean resultDelete = UserDAL.DeleteUser(userName);

            if(resultDelete == false)
            {
                Log.Error(">>> Error at : " + currentMethod.Name + DateOnly.FromDateTime(DateTime.Now) + "\n");
                result.isError = true;
                result.message = "Delete User " + userName + "is Errror ";
                result.messageDetail = String.Empty;
                result.dataObject = null;
            }
            else
            {
                Log.Error(">>> Delete User: " + userName+ " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
                result.isError = true;
                result.message = "Delete User " + userName + "is Success ";
                result.messageDetail = String.Empty;
                result.dataObject = true;
            }
            return result;
        }
    }
}

