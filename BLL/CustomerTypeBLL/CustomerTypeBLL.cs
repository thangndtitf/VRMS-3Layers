using System;
using System.Reflection;
using Serilog;
using VRMS_3layers.Models.ResultObj;
using VRMS_3Layers.DAL.CustomerType;
using VRMS_3Layers.Models;

namespace VRMS_3Layers.BLL.CustomerTypeBLL
{
	public class CustomerTypeBLL
	{
		public static ResultObject getListCustomerType()
		{
            Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.WriteTo.Console()
			.WriteTo.File("/Users/nguyendinhtatthang/Documents-NguyenDinhTatThang’sMacBookPro/Develop/DotNetProject/VRMS_Log/logs/DepartmentBLL.txt")
			.CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            ResultObject result = new ResultObject();
			List<MdCustomertype> listCustomerTypes = CustomerTypeDAL.getListCustomerType();
			if(listCustomerTypes != null)
			{
				for (int i = 0; i<= listCustomerTypes.Count -2; i++)
				{
					for(int j = 0; j<= listCustomerTypes.Count -2; j++)
					{
						if (listCustomerTypes[j].Customertypeid > listCustomerTypes[j+1].Customertypeid)
						{
							MdCustomertype temp = listCustomerTypes[j + 1];
							listCustomerTypes[j + 1] = listCustomerTypes[j];
							listCustomerTypes[j] = temp;
						}
					}
				}
                result.isError = false;
                result.message = "Get List Customer Type Success ";
                result.messageDetail = string.Empty;
                result.dataObject = listCustomerTypes;

            }
			else if(listCustomerTypes.Count <= 0)
			{
                result.isError = false;
                result.message = "List Customer Type is Empty ";
                result.messageDetail = string.Empty;
                result.dataObject = null;
            }
			else
			{
                result.isError = true;
                result.message = "Get list Customer Type Error";
                result.messageDetail = string.Empty;
                result.dataObject = null;
            }

            Log.Information(">>> End >>> " + currentMethod.Name + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;
        }


		public static ResultObject addNewCustomerType(MdCustomertype newCustomerType)
		{
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents-NguyenDinhTatThang’sMacBookPro/Develop/DotNetProject/VRMS_Log/logs/DepartmentBLL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            ResultObject result = new ResultObject();
            MdCustomertype insertedCustomerType = CustomerTypeDAL.insertCustomerType(newCustomerType);

            if(insertedCustomerType == null)
            {
                result.isError = true;
                result.message = "Add new Customer Type Failed";
                result.messageDetail = string.Empty;
                result.dataObject = insertedCustomerType;
            }
            else
            {
                result.isError = false;
                result.message = "Add new Customer Type Success";
                result.messageDetail = string.Empty;
                result.dataObject = insertedCustomerType;
            }



            Log.Information(">>> End >>> " + currentMethod.Name + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;
        }



        public static ResultObject updateCustomerType(MdCustomertype updCustomerType)
        {
            Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("/Users/nguyendinhtatthang/Documents-NguyenDinhTatThang’sMacBookPro/Develop/DotNetProject/VRMS_Log/logs/DepartmentBLL.txt")
            .CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            ResultObject result = new ResultObject();

            if(updCustomerType == null)
            {
                result.isError = true;
                result.message = "Updated department with id : " + updCustomerType.Customertypeid.ToString() + " is Failed";
                result.messageDetail = "Department is Null ";
                result.dataObject = updCustomerType;
            }
            else
            {
                try
                {
                    MdCustomertype checkedCustomerType = CustomerTypeDAL.getCustomerTypeByID(updCustomerType.Customertypeid);
                    if(checkedCustomerType == null)
                    {
                        result.isError = true;
                        result.message = "Can not find Customer Type with ID : " + updCustomerType.Customertypeid.ToString();
                        result.messageDetail = "Department is Null ";
                        result.dataObject = updCustomerType;

                    }
                    else
                    {
                        checkedCustomerType = CustomerTypeDAL.updateCustomerType(updCustomerType);
                        result.isError = false;
                        result.message = "Update Customer Type with ID : " + updCustomerType.Customertypeid.ToString() + " is Success";
                        result.messageDetail = " ";
                        result.dataObject = updCustomerType;
                    }
                }
                catch (Exception ex)
                {
                    result.isError = true;
                    result.message = "Update Custoemr Type Faile";
                    result.messageDetail = ex.ToString();
                    result.dataObject = null;
                }
            }

            Log.Information(">>> End >>> " + currentMethod.Name + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return result;

        }















    }
}

