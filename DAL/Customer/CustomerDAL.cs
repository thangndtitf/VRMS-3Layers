using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
using System.Data.SqlClient;
using VRMS_3Layers.Models.Customer;

namespace VRMS_3layers.DAL.Customer
{
    public class CustomerDAL
    {
        private readonly CustomerDbContextcs customerDbContextcs = new CustomerDbContextcs();


        public List<MdCustomer>? GetListCustomer()
        {
            try
            {
                List<MdCustomer> customerList = customerDbContextcs.MdCustomers.FromSqlRaw
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
                return customerDbContextcs.MdCustomers.FirstOrDefault(c => c.Customerid == customerId);
            }
        }

        public bool insertNewCus(MdCustomer customer)
        {
            bool result = false;
            NpgsqlConnection npgsqlConnection = (NpgsqlConnection)customerDbContextcs.Database.GetDbConnection();
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
            lastIdCustomer = customerDbContextcs.MdCustomers.Max(c => c.Customerid);
            return lastIdCustomer;
        }


        public MdCustomer updateCustomer(MdCustomer customer)
        {

            MdCustomer updateCustomer = customerDbContextcs.MdCustomers.FirstOrDefault(c => c.Customerid == customer.Customerid);
            if (updateCustomer != null)
            {
                updateCustomer.Customerfirstname = customer.Customerfirstname;
                updateCustomer.Customerlastname = customer.Customerlastname;
                updateCustomer.Customerfullname = updateCustomer.Customerfirstname + updateCustomer.Customerlastname;
                updateCustomer.Customerphone = customer.Customerphone;
                updateCustomer.Customeremail = customer.Customeremail;
                updateCustomer.Customerfulladdress = customer.Customerfulladdress;
                customerDbContextcs.SaveChanges();
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
                MdCustomer customerDelete = customerDbContextcs.MdCustomers.FirstOrDefault(c => c.Customerid == customerId);
                customerDelete.Isdeleted = 1;
                customerDelete.Deleteddate = DateOnly.FromDateTime(DateTime.Now);
                customerDbContextcs.SaveChanges();
            }
            else
            {
                result = false;
            }

            return result;
        }



    }
}
