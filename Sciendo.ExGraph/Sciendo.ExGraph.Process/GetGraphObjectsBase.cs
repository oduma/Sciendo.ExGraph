using System;
using System.Collections.Generic;
using Neo4j.Driver.V1;

namespace Sciendo.ExGraph.Process
{
    public abstract class GetGraphObjectsBase<T>:IGetGraphObjects<T>,IDisposable where T:class
    {
        protected readonly IDriver Driver;
        public GetGraphObjectsBase(string url, string userName, string password)
        {
            Driver = GraphDatabase.Driver(url, AuthTokens.Basic(userName, password));
        }

        public IEnumerable<T> GetGraphObjects()
        {
            using (var session = Driver.Session())
            {
                return session.ReadTransaction(ExecuteQueryWithReturn);
            }
        }

        protected abstract IEnumerable<T> ExecuteQueryWithReturn(ITransaction tx);
        public void Dispose()
        {
            Driver?.Dispose();
        }
    }
}
