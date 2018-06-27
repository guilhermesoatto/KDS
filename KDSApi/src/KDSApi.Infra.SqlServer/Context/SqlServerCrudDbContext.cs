using KDSApi.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Tnf.Runtime.Session;

namespace KDSApi.Infra.SqlServer.Context
{
    public class SqlServerCrudDbContext : CrudDbContext
    {
        public SqlServerCrudDbContext(DbContextOptions<CrudDbContext> options, ITnfSession session) 
            : base(options, session)
        {
        }
    }
}