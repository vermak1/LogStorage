using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace LogStorage
{
    internal interface IDatabaseAccessor
    {
        Task<Int32> RunWriteStoredProcedureAsync(String spName, IEnumerable<SqlParameter> spParams);
        Task<DataSet> RunReadeStoredProcedureAsync(string spName, IEnumerable<SqlParameter> spParams);

    }
}
