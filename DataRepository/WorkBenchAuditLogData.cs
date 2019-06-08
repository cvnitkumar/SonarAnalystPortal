using DataRepository.DataModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository
{
    public class WorkBenchAuditLogData : BaseRepository<WorkBenchAuditLog>
    {
        public void AddLog(WorkBenchAuditLog logData)
        {
            Insert(logData, "spInsertAuditLog", System.Data.CommandType.StoredProcedure);            
        }
    }
}
