using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.BL;
using MISA.BL.Exceptions;
using MISA.BL.Interfaces;
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
    public class CustomerGroupController : MISAEntityController<CustomerGroup>
    {
        public CustomerGroupController(ICustomerGroupBL customerGroupBL) : base(customerGroupBL)
        {

        }
    }
}
