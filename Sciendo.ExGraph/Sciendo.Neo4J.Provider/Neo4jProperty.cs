using System;

namespace Sciendo.Neo4J.Provider
{
    [AttributeUsage(AttributeTargets.Property,AllowMultiple = true)]
    public class Neo4jProperty:Attribute
    {
        public Neo4jType Neo4JType { get; set; }
        public string Name { get; set; }

        public Neo4jProperty(string name, Neo4jType neo4jType)
        {
            Name = name;
            Neo4JType = neo4jType;
        }
    }

    public enum Neo4jType
    {
        None,
        Node,
        Relationship,
    }
}
