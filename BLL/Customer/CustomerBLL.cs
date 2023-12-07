using VRMS_3layers.DAL.Customer;
using VRMS_3layers.Models.Customer;
using VRMS_3layers.Models.ResultObj;

namespace VRMS_3layers.BLL.Customer
{
    public class CustomerBLL
    {
     
        private CustomerDAL customerDal = new CustomerDAL();    

        public ResultObject GetListCustomer()
        {
            ResultObject result = new ResultObject();
            List<MdCustomer> customerList = customerDal.GetListCustomer();
            if(customerList.Count > 0)
            {
                result.isError = false;
                result.message = "Get List Customer Success";
                result.messageDetail = string.Empty;
                result.dataObject = customerList;
                return result;
            }
            else
            {
                result.isError = true;
                result.message = "Get List Fail.";
                result.messageDetail = string.Empty;
                result.dataObject = null;
                return result;
            }
        }

        public ResultObject AddNewCustomer(MdCustomer customer)
        {
            ResultObject result = new ResultObject();
            
            if(customer == null)
            {
                result.isError = true;
                result.message = "Customer Object is null";
                result.messageDetail = string.Empty;
                result.dataObject = null;
                return result;
            }
            if (customer.Customerfullname == null || customer.Customerfirstname == null || customer.Customerlastname == null)
            {
                result.isError = true;
                result.message = "Name Of Customer is null";
                result.messageDetail = string.Empty;
                result.dataObject = null;
                return result;
            }
            else
            {
                customerDal.insertNewCus(customer);
                result.isError = false;
                result.message = "Insert success";
                result.messageDetail = "Insert success";
                customer.Customerid= customerDal.getLastIdCustomer();
                result.dataObject = customer;
                return result;
            }
             
        }

        public ResultObject UpdateCustomer(MdCustomer updateCustomer)
        {
            ResultObject result = new ResultObject();
            if(updateCustomer == null)
            {
                result.isError = true;
                result.message = "Fail";
                result.messageDetail = "Update Data Object is Null";
                result.dataObject = null;
            }
            else if ( String.IsNullOrEmpty(updateCustomer.Customerfullname) || String.IsNullOrEmpty(updateCustomer.Customerfirstname )
                || String.IsNullOrEmpty(updateCustomer.Customerlastname))

            {
               
                result.isError = true;
                result.message = "Name Of Customer is null";
                result.messageDetail = string.Empty;
                result.dataObject = null;
            }
            else if (updateCustomer.Customerphone <= 0)
            {
                result.isError = true;
                result.message = "Phone Of Customer is null";
                result.messageDetail = string.Empty;
                result.dataObject = null;
            }
            else if ( String.IsNullOrEmpty(updateCustomer.Customeremail))
            {
                result.isError = true;
                result.message = "Email Of Customer is null";
                result.messageDetail = string.Empty;
                result.dataObject = null;
            }
            else
            {
                result.isError = false;
                result.message = "Success";
                result.messageDetail = "Update Data Customer is Success";
                result.dataObject = customerDal.updateCustomer(updateCustomer);
            }

            return result;
        }

        public ResultObject DeleteCustomer(decimal customerId)
        {
            ResultObject result = new ResultObject();
            if(customerDal.deleteCustomer(customerId))
            {
                result.isError = false;
                result.message = "Success";
                result.messageDetail = "Delete Data Customer is Success";
                result.dataObject = null;
            }
            return result;
        }

        

    }
}
