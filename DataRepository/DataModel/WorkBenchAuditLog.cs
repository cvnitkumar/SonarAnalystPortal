using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRepository.DataModel
{
    public class WorkBenchAuditLog
    {
        public long Id              {get;set;}
        public DateTime Timestamp   {get;set;}
        public long EntityId        {get;set;}
        public string AnalystName   {get;set;}
        public string Notes         {get;set;}
        public string OldState      {get;set;}
        public string NewState { get; set; }
    }
}
