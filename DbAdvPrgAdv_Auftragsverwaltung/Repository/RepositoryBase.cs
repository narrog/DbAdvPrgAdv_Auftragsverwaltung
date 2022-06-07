using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace DbAdvPrgAdv_Auftragsverwaltung.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
    {
        public abstract string TableName { get; }
        /* TODO: Implement Interface Members */

        protected RepositoryBase()
        {
            // TODO: Load ConnectionString
            this.ConnectionString = "<ConnString>";
        }
        protected string ConnectionString { get; }
        public T GetSingle<P>(P pkValue)
        {
            throw new NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public long Count(string whereCondition, Dictionary<string, object> parameterValues)
        {
            throw new NotImplementedException();
        }

        public long Count()
        {
            using (var conn = new SqlConnection(this.ConnectionString))
            {
                using (var cmd = conn.CreateCommand())
                {
                    conn.Open();
                    cmd.CommandText = "select count(*) from @table";
                    cmd.Parameters.Add("@table", SqlDbType.NVarChar).Value = this.TableName;
                    return (long)cmd.ExecuteScalar();
                }
            }
        }
        
    }
}
