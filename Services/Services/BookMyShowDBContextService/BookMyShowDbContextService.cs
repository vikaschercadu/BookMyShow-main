using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace BookMyShow.Services.BookMyShowDBContext
{
    public class BookMyShowDbContextService : IBookMyShowDbContextService
    {
        private readonly string DevConnection = "Server=LAPTOP-KDRM4ASL\\PRASHANT;Database=BookMyShowDB;Trusted_Connection=True;MultipleActiveResultSets=true";
        private DbConnection ConnectionDb;
        public DbConnection GetDbConnection()
        {
            return this.Connection;
        }
        public DbConnection Connection
        {
            get
            {
                //***
                //*** Create a new connection if null or disposed
                //***
                if (ConnectionDb == null)
                {
                    ConnectionDb = new SqlConnection(DevConnection);
                    ConnectionDb.Open();
                }
                //***
                //*** Open the connection if the connection state is anything other than disposed
                //***
                else if (ConnectionDb.State != ConnectionState.Open)
                {
                    ConnectionDb.Open();
                }
                return ConnectionDb;
            }
        }
    }
}
