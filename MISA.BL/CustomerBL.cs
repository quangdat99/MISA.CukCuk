using MISA.BL.Exceptions;
using MISA.BL.Interfaces;
using MISA.Common.Attributes;
using MISA.Common.Entities;
using MISA.DL;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.BL
{
    public class CustomerBL:BaseBL<Customer>,ICustomerBL
    {
        public CustomerBL(IBaseDL<Customer> baseDL):base(baseDL)
        {

        }
        protected override void ValidateCustom(Customer entity)
        {
            if (entity is Customer)
            {
                var customer = entity as Customer;
                CustomerDL customerDL = new CustomerDL();
                // validate dữ liệu:
               /* //1. Đã nhập mã hay chưa? nếu chưa nhập thì đưa ra cảnh báo lỗi:
                if (string.IsNullOrEmpty(customer.CustomerCode))
                {
                    throw new GuardException<Customer>("Mã khách hàng không được phép để trống.", entity as Customer);
                }*/

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
