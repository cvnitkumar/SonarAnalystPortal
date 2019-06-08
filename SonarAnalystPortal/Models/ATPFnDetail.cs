using DataRepository.DataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SonarAnalystPortal.Models
{
    public class ATPFnDetail
    {
        //[Required]
        public long EntityId { get; set; }
        public string EntityHash { get; set; }
        public string WorkloadContext { get; set; }
        public string Severity { get; set; }
        public string DetectionName { get; set; }


        public ATPFnDetail(EntitySubmission data)
        {
            EntityId        = data.Id;
            EntityHash      = data.EntityHash;
            WorkloadContext = data.WorkloadContext;
            Severity        = data.Severity;
            DetectionName   = data.DetectionName;
        }

        public EntitySubmission ToData()
        {
            var data = new EntitySubmission()
            {
                Id = EntityId,
                EntityHash = EntityHash,
                WorkloadContext = WorkloadContext,
                Severity = Severity,
                DetectionName = DetectionName
            };
            return data;
        }
    }
}