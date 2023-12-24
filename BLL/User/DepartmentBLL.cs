using VRMS_3layers.DAL.User;
using VRMS_3layers.Models.ResultObj;
using VRMS_3Layers.Models.User;

namespace VRMS_3layers.BLL.User
{
    public class DepartmentBLL
    {
        //  private  DepartmentDAL _departmentDAL = new DepartmentDAL();
      // DepartmentDAL _departmentDAL = new DepartmentDAL();
        public static ResultObject getListDepartment()
        {
            
            ResultObject result = new ResultObject();
            
            List<MdDepartment> listDepartment = DepartmentDAL.getListDepartment();
            if(listDepartment != null)
            {
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
            return result;
        }

        public static ResultObject addNewDepartment(MdDepartment newDepartment)
        {
            ResultObject result = new ResultObject();
            MdDepartment updatedDepartment = DepartmentDAL.addNewDepartment(newDepartment);
            if(updatedDepartment == null)
            {
                result.isError = true;
                result.message = "Add new department Failed";
                result.messageDetail = string.Empty;
                result.dataObject = updatedDepartment;
            }
            else
            {
                result.isError = false;
                result.message = "Add new department Success";
                result.messageDetail = string.Empty;
                result.dataObject = updatedDepartment;
            }
            return result;
        }

    }
}
