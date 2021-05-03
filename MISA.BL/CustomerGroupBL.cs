using MISA.BL.Exceptions;
using MISA.Common.Entities;
using MISA.DL;
using System;
using System.Collections.Generic;

namespace MISA.BL
{
    public class CustomerGroupBL:BaseBL<CustomerGroup>
    {
        /*  public IEnumerable<CustomerGroup> GetAll()
          {
              CustomerGroupDL customerGroupDL = new CustomerGroupDL();
              var customerGroups = customerGroupDL.GetAll<CustomerGroup>();
              return customerGroups;
          }

          public CustomerGroup GetById(Guid id)
          {
              CustomerGroupDL customerGroupDL = new CustomerGroupDL();
              var customerGroup = customerGroupDL.GetById<CustomerGroup>(id);
              return customerGroup;
          }

          public int Insert(CustomerGroup customerGroup)
          {
              CustomerGroupDL customerGroupDL = new CustomerGroupDL();
              return customerGroupDL.Insert(customerGroup);
          }

          public int Update(CustomerGroup customerGroup, Guid id)
          {
              CustomerGroupDL customerGroupDL = new CustomerGroupDL();

              return customerGroupDL.Update(customerGroup, id);
          }
          public int Delete(Guid id)
          {
              CustomerGroupDL customerGroupDL = new CustomerGroupDL();
              return customerGroupDL.Delete<CustomerGroup>(id);
          }*/

        protected override void Validate(CustomerGroup entity)
        {
            if (entity is CustomerGroup)
            {
                throw new GuardException<CustomerGroup>("O zee", entity as CustomerGroup);
            }
        }
    }
}
