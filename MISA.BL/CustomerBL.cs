using MISA.BL.Exceptions;
using MISA.Common.Entities;
using MISA.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.BL
{
    public class CustomerBL:BaseBL
    {
        /* // Lấy toàn bộ danh sách khách hàng
         public IEnumerable<Customer> GetAll()
         {
             CustomerDL customerDL = new CustomerDL();
             var customers = customerDL.GetAll<Customer>();
             return customers;
         }

         public Customer GetCustomerById(Guid customerId)
         {
             CustomerDL customerDL = new CustomerDL();
             var customer = customerDL.GetById<Customer>(customerId);
             return customer;
         }

         public int InsertCustomer(Customer customer)
         {
             CustomerDL customerDL = new CustomerDL();
             // validate dữ liệu:
             //1. Đã nhập mã hay chưa? nếu chưa nhập thì đưa ra cảnh báo lỗi:
             if (string.IsNullOrEmpty(customer.CustomerCode))
             {
                 throw new GuardException("Mã khách hàng không được phép để trống.");
             }
             //2. Check mã khách hàng đã tồn tại hay chưa ?
             var isExists = customerDL.CheckCustomerCodeExist(customer.CustomerCode);
             if (isExists == true)
             {
                 throw new GuardException("Mã khách hàng đã tồn tại trong hệ thống, vui lòng kiểm tra lại!");
             };
             //3. Kiểm tra Email có đúng định dạng hay không?
             var emailTemplate = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
             if (!Regex.IsMatch(customer.Email, emailTemplate))
             {
                 throw new GuardException("Email không đúng định dạng, vui lòng kiểm tra lại!");
             }
             // Thực hiện lấy dữ liệu:
             return customerDL.Insert(customer);
         }

         public int UpdateCustomer(Customer customer, Guid cusstomerId)
         {
             CustomerDL customerDL = new CustomerDL();
             return customerDL.Update<Customer>(customer, cusstomerId);
         }
         public int DeleteCustomer(Guid id)
         {
             CustomerDL customerDL = new CustomerDL();

             return customerDL.Delete<Customer>(id);
         }*/

        protected override void Validate<MISAEntity>(MISAEntity entity)
        {
            if (entity is Customer)
            {
                var customer = entity as Customer;
                CustomerDL customerDL = new CustomerDL();
                // validate dữ liệu:
                //1. Đã nhập mã hay chưa? nếu chưa nhập thì đưa ra cảnh báo lỗi:
                if (string.IsNullOrEmpty(customer.CustomerCode))
                {
                    throw new GuardException<Customer>("Mã khách hàng không được phép để trống.", entity as Customer);
                }
                //2. Check mã khách hàng đã tồn tại hay chưa ?
                var isExists = customerDL.CheckCustomerCodeExist(customer.CustomerCode);
                if (isExists == true)
                {
                    throw new GuardException<Customer>("Mã khách hàng đã tồn tại trong hệ thống, vui lòng kiểm tra lại!", entity as Customer);
                };
                //3. Kiểm tra Email có đúng định dạng hay không?
                var emailTemplate = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                if (!Regex.IsMatch(customer.Email, emailTemplate))
                {
                    throw new GuardException<Customer>("Email không đúng định dạng, vui lòng kiểm tra lại!", entity as Customer);
                }
            }
            
        }
    }
}
