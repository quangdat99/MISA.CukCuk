using MISA.BL.Exceptions;
using MISA.BL.Interfaces;
using MISA.Common.Entities;
using MISA.DL;
using MISA.DL.Interfaces;
using System;
using System.Collections.Generic;

namespace MISA.BL
{
    public class CustomerGroupBL:BaseBL<CustomerGroup>,ICustomerGroupBL
    {
        public CustomerGroupBL(IBaseDL<CustomerGroup> baseDL) : base(baseDL)
        {

        }
        protected override void ValidateCustom(CustomerGroup entity)
        {
        }
    }
}
