using DataRepository.DataModel;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DataRepository
{
    public class EntitySubmissionData : BaseRepository<EntitySubmission>
    {
        public IList<EntitySubmission> GetEntitySubmissionList()
        {
            return GetList("spGetNewEntitySubmissions", new { days = 3}, CommandType.StoredProcedure);
        }

        public int AssignEntities(List<EntitySubmission> entities, string userName)
        {
            //Dataaccess 
            int NoOfEntitiesAssigned = 0;
            using (var conn = new SqlConnection(Connection))
            {
                conn.Open();

                foreach (var entity in entities)
                {
                    if (conn.State != System.Data.ConnectionState.Open)
                        conn.Open();

                    var cmd = new SqlCommand("spAssignEntitySubmission", conn);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", userName);
                    cmd.Parameters.AddWithValue("@entityId", entity.Id);

                    NoOfEntitiesAssigned = NoOfEntitiesAssigned + cmd.ExecuteNonQuery();
                }
            }


            return NoOfEntitiesAssigned;
        }

        public bool TransferEntities(List<EntitySubmission> entities)
        {
            //Dataaccess 


            return true;
        }


    }
}
