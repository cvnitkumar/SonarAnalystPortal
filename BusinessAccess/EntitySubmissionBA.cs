using DataRepository;
using DataRepository.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccess
{
    public class EntitySubmissionBA
    {
        public IList<EntitySubmission> GetEntitySubmissionList()
        {
            var dataObj = new EntitySubmissionData();
            return dataObj.GetEntitySubmissionList();
        }

        public int AssignEntities(List<EntitySubmission> entities, string userName)
        {
            var dataObj = new EntitySubmissionData();
            var assignedEntitiesCount = dataObj.AssignEntities(entities, userName);

            //Audit
            var auditLogObj = new WorkBenchAuditLogData();
            foreach (var entity in entities)
            {
                auditLogObj.AddLog(new WorkBenchAuditLog() {
                    EntityId = entity.Id,
                    OldState = "0",
                    NewState = "1",
                    Notes = $"Entity is assigne to {entity.AnalystName}",
                    Username = userName
                });
            }

            return assignedEntitiesCount;
        }
    }
}
