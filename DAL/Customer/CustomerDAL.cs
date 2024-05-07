using Microsoft.EntityFrameworkCore;
using Npgsql;

using VRMS_3Layers.Models;

namespace VRMS_3layers.DAL.Customer
{
    public class CustomerDAL
    {
        private readonly ModelsDbContextcs odelsDbContextcs = new ModelsDbContextcs();


        public List<MdCustomer>? GetListCustomer()
        {
            try
            {
                List<MdCustomer> customerList = odelsDbContextcs.MdCustomers.FromSqlRaw
                    ("select * from  \"MD\".customer_getlist()").ToList();
                return customerList;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public MdCustomer FindCustomerById(decimal customerId)
        {
            if (customerId <= 0)
            {
                return null;
            }
            else
            {
                return odelsDbContextcs.MdCustomers.FirstOrDefault(c=> c.Customerid == customerId);
            }
        }

        public bool insertNewCus(MdCustomer customer)
        {
            bool result = false;
            NpgsqlConnection npgsqlConnection = (NpgsqlConnection)odelsDbContextcs.Database.GetDbConnection();
            try
            {

                NpgsqlCommand cmd = new NpgsqlCommand("select \"MD\".customer_add(@customerID,@customerTypeID,@customerFullName," +
                    "@customerFirstName,@customerLastName,@customerPhone,@customerEmail,@customerFullAddress,@description,@passworld);",
                   npgsqlConnection);
                cmd.Parameters.AddWithValue("@customerID", getLastIdCustomer() + 1);
                cmd.Parameters.AddWithValue("@customerTypeID", customer.Customertypeid);
                cmd.Parameters.AddWithValue("@customerFullName", customer.Customerfullname);
                cmd.Parameters.AddWithValue("@customerFirstName", customer.Customerfirstname);
                cmd.Parameters.AddWithValue("@customerLastName", customer.Customerlastname);
                cmd.Parameters.AddWithValue("@customerPhone", customer.Customerphone);
                cmd.Parameters.AddWithValue("@customerEmail", customer.Customeremail);
                cmd.Parameters.AddWithValue("@customerFullAddress", customer.Customerfulladdress);
                cmd.Parameters.AddWithValue("@description", customer.Description);
                cmd.Parameters.AddWithValue("@passworld", customer.Passworld);
                npgsqlConnection.Open();
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (DbUpdateException dbUpdateException)
            {
                Console.WriteLine(dbUpdateException.ToString());
                result = false;
            }
            finally
            {
                npgsqlConnection.Close();
            }
            return result;
        }

        public decimal getLastIdCustomer()
        {
            decimal lastIdCustomer = 0;
            lastIdCustomer = odelsDbContextcs.MdCustomers.Max(c => c.Customerid);
            return lastIdCustomer;
        }


        public MdCustomer updateCustomer(MdCustomer customer)
        {

            MdCustomer updateCustomer = odelsDbContextcs.MdCustomers.FirstOrDefault(c => c.Customerid == customer.Customerid);
            if (updateCustomer != null)
            {
                updateCustomer.Customerfirstname = customer.Customerfirstname;
                updateCustomer.Customerlastname = customer.Customerlastname;
                updateCustomer.Customerfullname = updateCustomer.Customerfirstname + updateCustomer.Customerlastname;
                updateCustomer.Customerphone = customer.Customerphone;
                updateCustomer.Customeremail = customer.Customeremail;
                updateCustomer.Customerfulladdress = customer.Customerfulladdress;
                odelsDbContextcs.SaveChanges();
            }
            else
            {
                updateCustomer = null;
            }
            return updateCustomer;

        }


        public bool deleteCustomer(decimal customerId)
        {
            bool result = false;
            if (FindCustomerById(customerId) != null)
            {
                MdCustomer customerDelete = odelsDbContextcs.MdCustomers.FirstOrDefault(c => c.Customerid == customerId);
                customerDelete.Isdeleted = 1;
                customerDelete.Deleteddate = DateOnly.FromDateTime(DateTime.Now);
                odelsDbContextcs.SaveChanges();
            }
            else
            {
                result = false;
            }

            return result;
        }



    }
}
