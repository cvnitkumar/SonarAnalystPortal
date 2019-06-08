using System;
using System.Collections.Generic;
using System.Text;

namespace DataRepository.DataModel
{
    public class EntitySubmission
    {
        public long Id                       {get;set;}
        //CreationTime  datetime            {get;set;}
        public string EntityHash            {get;set;}
        //EntityType  varchar               {get;set;}
        //IssueType   varchar               {get;set;}
        public string Source                {get;set;}
        //Workload    varchar               {get;set;}
        public string WorkloadContext       {get;set;}
        public string Severity              {get;set;}
        public string SubmissionId          {get;set;}
        //SubmissionCreationTime  datetime  {get;set;}
        public string SubmissionToken       {get;set;}
        public string SubmissionType        {get;set;}
        public string DetectionName         {get;set;}
        public string BlobstoreName         {get;set;}
        public string ContainerName         {get;set;}
        public string AnalystName         { get; set; }
        public int    State                 {get;set;}
        public string Var1                  {get;set;}
        public string Var2                  {get;set;}
        public string Var3                  { get; set; }
    }
}
