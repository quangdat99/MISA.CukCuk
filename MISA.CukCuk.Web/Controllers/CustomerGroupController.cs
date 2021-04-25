using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.BL.Exceptions;
using MISA.Common.Entities;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class CustomerGroupController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            CustomerGroupBL customerGroupBL = new CustomerGroupBL();
            var customerGroups = customerGroupBL.GetAll<CustomerGroup>();
            // 4. Kiểm tra dữ liệu và trả về cho client
            // - Nếu có dữ liệu trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (customerGroups.Count() > 0)
            {
                return Ok(customerGroups);

            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            CustomerGroupBL customerGroupBL = new CustomerGroupBL();
            var customerGroup = customerGroupBL.GetById<CustomerGroup>(id);

            // 4. Kiểm tra dữ liệu và trả về cho client
            // - Nếu có dữ liệu trả về 200 kèm theo dữ liệu
            // - Không có dữ liệu thì trả về 204:
            if (customerGroup != null)
            {
                return Ok(customerGroup);

            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CustomerGroup customerGroup)
        {
            try
            {
                CustomerGroupBL customerGroupBL = new CustomerGroupBL();

                var rowAffects = customerGroupBL.Insert(customerGroup);
                // 4. Kiểm tra dữ liệu và trả về cho client
                // - Nếu có dữ liệu trả về 200 kèm theo dữ liệu
                // - Không có dữ liệu thì trả về 204:
                if (rowAffects > 0)
                {
                    return Ok(rowAffects);

                }
                else
                {
                    return NoContent();
                }
            }
            catch (GuardException<CustomerGroup> ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại!",
                    field = "CustomerCode",
                    data = ex.Data
                };
                return StatusCode(400, mes);
            }
            catch (Exception ex)
            {
                var mes = new
                {
                    devMsg = ex.Message,
                    userMsg = "Có lỗi xảy ra, vui lòng liên hệ MISA để được trợ giúp",
                    field = "CustomerCode"
                };
                return StatusCode(500, mes);
            }

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] CustomerGroup customerGroup)
        {
            CustomerGroupBL customerGroupBL = new CustomerGroupBL();

            var res = customerGroupBL.Update(customerGroup, id);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            CustomerGroupBL customerGroupBL = new CustomerGroupBL();

            var res = customerGroupBL.Delete<CustomerGroup>(id);
            if (res > 0)
            {
                return Ok(res);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
