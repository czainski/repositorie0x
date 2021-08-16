using WebApiSelfHostBC.Context;
using System;

namespace WebApiSelfHostBC.Models
{
    public static class UnitOfWork
    {
        public static IRepository SQLServer(bool sqlServer) 
        {
            if (sqlServer)  return SQLEXPRESS();
            return Localdb();
        }
        public static IRepository Localdb()         => new Repository(new Context.Context("localdb"));
        public static IRepository SQLEXPRESS() => new Repository(new Context.Context("SQLEXPRESS"));
    }
}
