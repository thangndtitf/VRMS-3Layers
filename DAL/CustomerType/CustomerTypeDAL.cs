using System;
using System.Reflection;
using Serilog;
using VRMS_3layers.Models.ResultObj;
using VRMS_3Layers.Models;

namespace VRMS_3Layers.DAL.CustomerType
{
	public class CustomerTypeDAL
	{
		/*
		 * Ham dung de Query all Customer Type
		 */
		public static List<MdCustomertype> getListCustomerType()
		{
            Log.Logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.WriteTo.Console()
			.WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/CustomerTypeMD.txt")
			.CreateLogger();

            // Dùng để lấy tên function hiên tại đang thực thi
            MethodBase currentMethod = MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>> " + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            List<MdCustomertype> customerTypes = new List<MdCustomertype>();

			using(var _modelDbContext = new ModelsDbContextcs())
			{
				customerTypes = _modelDbContext.MdCustomertypes.Where<MdCustomertype>(ct => ct.Isdeleted == 0).ToList();
			}

            Log.Information(">>> End >>> " + currentMethod.Name + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return customerTypes;
		}


		/*
		 * Ham dung de search CustomerType dua theo customerTypeId
		 */
		public static MdCustomertype getCustomerTypeByID(decimal customerTypeId)
		{
			Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.WriteTo.Console()
				.WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/CustomerTypeMD.txt")
				.CreateLogger();
			MethodBase currentMethod =  MethodBase.GetCurrentMethod();
			Log.Information(">>> Begin >>>" + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            MdCustomertype? customertype = null;

            using (var _modelDbContext = new ModelsDbContextcs())
			{
				customertype = _modelDbContext.MdCustomertypes.FirstOrDefault<MdCustomertype>(ct => ct.Customertypeid == customerTypeId && ct.Isdeleted == 0);
			}

            Log.Information(">>> End >>>" + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
            return customertype;
		}



		/*
		 * Ham dung de insert du lieu loai khach hang
		 */
		public static MdCustomertype insertCustomerType(MdCustomertype it_CustomerType)
		{
			Log.Logger = new LoggerConfiguration()
						.MinimumLevel.Debug()
						.WriteTo.Console()
						.WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/CustomerTypeMD.txt")
						.CreateLogger();

			MethodBase currentMethod =  MethodBase.GetCurrentMethod();
            Log.Information(">>> Begin >>>" + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
			MdCustomertype ot_Customertype = null;

            using (var _modelDbContext = new ModelsDbContextcs())
			{
				_modelDbContext.MdCustomertypes.Add(it_CustomerType);
				_modelDbContext.SaveChanges();
				ot_Customertype = it_CustomerType;
			}

            Log.Information(">>> End >>>" + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
			return ot_Customertype;
		}



		public static MdCustomertype updateCustomerType(MdCustomertype it_customerType)
		{
			Log.Logger = new LoggerConfiguration()
						.MinimumLevel.Debug()
						.WriteTo.Console()
						.WriteTo.File("/Users/nguyendinhtatthang/Documents - NguyenDinhTatThang’s MacBook Pro/Develop/DotNetProject/VRMS_Log/logs/CustomerTypeMD.txt")
						.CreateLogger();

			MethodBase currentMethod =  MethodBase.GetCurrentMethod();
			Log.Information(">>> Begin >>>" + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
			MdCustomertype ot_customerType = new MdCustomertype();
            using (var _modelDbContext = new ModelsDbContextcs())
			{
				ot_customerType = _modelDbContext.MdCustomertypes.FirstOrDefault(ct => ct.Customertypeid == it_customerType.Customertypeid);
				ot_customerType.Customertypename = it_customerType.Customertypename;
				ot_customerType.Description = it_customerType.Description;
			}
					

                Log.Information(">>> End >>>" + currentMethod.Name + " " + DateOnly.FromDateTime(DateTime.Now) + "\n");
			return ot_customerType;
		}
	}
}

