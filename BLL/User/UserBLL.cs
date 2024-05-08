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
			return result;
		}

		/*
		 Hàm để get User by ID
		*/
		public static ResultObject GetUserById(decimal userName)
		{
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
			return result;
		}

		/*
		 Hàm để insert mới dữ liệu User 
		 */
		//public static ResultObject InsertNewUser(MdUser newUser)
		//{
  //          ResultObject result = new ResultObject();
		//	MdUser insertUser = UserDAL.InsertUser(newUser);

  //      }
    }
}

