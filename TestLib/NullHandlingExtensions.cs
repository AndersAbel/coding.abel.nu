using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodingAbelNu.Utilities.NullHandlers;
using System.Xml.Linq;

namespace TestLib
{
    public static class NullHandlingExtensions
    {
        private static void Prepare<T>(T t)
        {
        }

        public static void PrepareEach1<T>(IEnumerable<T> sequence)
        {
            if (sequence != null)
            {
                foreach (T t in sequence)
                {
                    Prepare(t);
                }
            }
        }

        public static void PrepareEach2<T>(IEnumerable<T> sequence)
        {
            foreach (T t in sequence.EmptyIfNull())
            {
                Prepare(t);
            }
        }

        public static string ExpandTimeStamp(string str)
        {
            return str.Replace("%timestamp%", "[" + DateTime.Now.TimeOfDay.ToString() + "]");
        }

public static string GetServerName1(XElement config)
{
    XElement element = config.Element("database");
    string serverName = "(local)";
    if (element != null)
    {
        XAttribute server = element.Attribute("server");
        if (server != null)
        {
            serverName = server.Value;
        }
    }
    return serverName;
}

public static string GetServerName2(XElement config)
{
    return config.Element("database")
        .GetAttributeValueOrDefault("server", "(local)");
}
    }
}
