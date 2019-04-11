using System;
using System.Collections.Generic;
using System.Text;

namespace Sciendo.ExGraph.Process
{
    public interface IGetGraphObjects<T> where T:class
    {
        IEnumerable<T> GetGraphObjects();
    }
}
