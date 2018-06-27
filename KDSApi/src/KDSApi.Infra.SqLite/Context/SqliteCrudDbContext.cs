using KDSApi.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Tnf.Runtime.Session;

namespace KDSApi.Infra.SqLite.Context
{
    public class SqliteCrudDbContext : CrudDbContext
    {

        public SqliteCrudDbContext(DbContextOptions<CrudDbContext> options, ITnfSession session) 
            : base(options, session)
        {
        }
    }
}