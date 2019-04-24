using System;
using System.Collections.Generic;
using System.Reflection;
using Neo4j.Driver.V1;

namespace Sciendo.Neo4J.Provider
{
    public abstract class GetGraphObjectsBase<T>:IGetGraphObjects<T>,IDisposable where T:class, new()
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

        protected T CastNeo4jObject(IRecord neo4jRecord)
        {
            var returnType = new T();

            IDictionary<string,object> record=new Dictionary<string, object>();
            foreach (var key in neo4jRecord.Keys)
            {
                record.Add(key, neo4jRecord[key]);
            }
            GetInstance(record, returnType);
            return returnType;
        }

        private void GetInstance(IDictionary<string,object> neo4jRecord, object returnType)
        {
            foreach (PropertyInfo property in returnType.GetType().GetProperties())
            {
                foreach (var neo4JProperty in property.GetCustomAttributes<Neo4jProperty>())
                {
                    switch (neo4JProperty.Neo4JType)
                    {
                        case Neo4jType.None:
                        {
                            if(neo4jRecord.Keys.Contains(neo4JProperty.Name))
                                PopulateSimpleProperty(neo4jRecord[neo4JProperty.Name], returnType, property);

                            break;
                        }
                        case Neo4jType.Node:
                        {
                            PopulateInstancePropertyFromNode((INode)neo4jRecord[neo4JProperty.Name], returnType, property);
                            break;
                        }
                    }
                    
                }
            }
        }

        private void PopulateInstancePropertyFromNode(INode neo4JNode, object returnType, PropertyInfo property)
        {
            var instanceProperty = returnType.GetType()
                .GetProperty(property.Name, BindingFlags.Instance | BindingFlags.Public);
            if (instanceProperty != null && instanceProperty.CanWrite)
            {
                var newInstance = Activator.CreateInstance(property.PropertyType);
                GetInstance((IDictionary<string, object>)neo4JNode.Properties,newInstance);
                instanceProperty.SetValue(returnType,newInstance);
            }
            else
            {
                throw new Exception(
                    $"Cast exception for property {property.Name}");
            }

        }

        private void PopulateSimpleProperty(object neo4jField, object returnType, PropertyInfo property)
        {
            var instanceProperty = returnType.GetType().GetProperty(property.Name,
                BindingFlags.Instance | BindingFlags.Public);
            if (instanceProperty != null && instanceProperty.CanWrite)
            {
                instanceProperty.SetValue(returnType,
                    ChangePropertyType(neo4jField, property.PropertyType));
            }
            else
            {
                throw new Exception(
                    $"Cast exception for property {property.Name}");
            }
        }

        private object ChangePropertyType(object value, Type toType)
        {
            return toType.Name.ToLower() == "guid"
                ? Guid.Parse(value.ToString())
                : Convert.ChangeType(value, toType);
        }

        protected abstract IEnumerable<T> ExecuteQueryWithReturn(ITransaction tx);
        public void Dispose()
        {
            Driver?.Dispose();
        }
    }
}
