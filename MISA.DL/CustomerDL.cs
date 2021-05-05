using MISA.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using MySqlConnector;

namespace MISA.DL
{
    public class CustomerDL:BaseDL<Customer>
    {
        
        public bool CheckCustomerCodeExist (string customerCode)
        {
            using (_dbConnection = new MySqlConnection(_connectionString))
            {
                // 3. Tương tác với Database 
                var sqlCommand = "Proc_CheckCustomerCodeExists";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@m_CustomerCode", customerCode);
                var res = _dbConnection.ExecuteScalar<bool>(sqlCommand, dynamicParameters, commandType: CommandType.StoredProcedure);
                return res;
            }
            
        }
    }
}
