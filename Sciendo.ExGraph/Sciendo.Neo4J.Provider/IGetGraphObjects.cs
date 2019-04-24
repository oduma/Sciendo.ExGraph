using System.Collections.Generic;

namespace Sciendo.Neo4J.Provider
{
    public interface IGetGraphObjects<T> where T:class
    {
        IEnumerable<T> GetGraphObjects();
    }
}
