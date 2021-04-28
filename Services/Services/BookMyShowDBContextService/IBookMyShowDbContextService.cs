using System.Data.Common;

namespace BookMyShow.Services.BookMyShowDBContext
{
    public interface IBookMyShowDbContextService
    {
        public DbConnection GetDbConnection();
    }
}
