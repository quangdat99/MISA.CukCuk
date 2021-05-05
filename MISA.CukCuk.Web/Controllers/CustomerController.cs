using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.BL.Exceptions;
using MISA.BL.Interfaces;
using MISA.Common.Entities;
using MISA.CukCuk.Api.Controllers;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Web.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerController : MISAEntityController<Customer>
    {
        public CustomerController(ICustomerBL customerBL):base(customerBL)
        {

        }
        [HttpGet("Paging")]
        public IActionResult GetPaging (int pageIndex, int pageSize)
        {
            // 1. Khai báo thông tin kết nối đến Database :
            string connectionString = "" +
                "Host = 47.241.69.179;" +
                "Port = 3306;" +
                "User Id = dev;" +
                "Password = 12345678;" +
                "Database = MF0_NVManh_CukCuk02;";

            // 2. Khởi tạo kết nối :
            IDbConnection dbConnection = new MySqlConnection(connectionString);

            // 3. Tương tác với Database ( lấy, sửa, xóa )
            var sqlCommand = $"Proc_GetCustomerPaging";
            var param = new
            {
                m_PageIndex = 1,
                m_PageSize = 10
            };
            var customers = dbConnection.Query<Customer>(sqlCommand, param: param, commandType: CommandType.StoredProcedure);

            // 4. Kiểm tra dữ liệu và trả về cho client
            // - Nếu có dữ liệu trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (customers.Count() > 0)
            {
                return Ok(customers);
            } else
            {
                return NoContent();
            }
        }


    }
}
