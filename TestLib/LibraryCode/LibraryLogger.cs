using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Configuration;

namespace TestLib.LibraryCode
{
public enum LogSeverity
{ 
    Critical,
    Error,
    Warning,
    SystemInformation,
    TransactionInformation,
    SystemDebug,
    TransactionDebug,
    ExtraVerbose
}

public interface ILogger
{
    void Write(LogSeverity severity, string message);
}

public interface ILogFilterBehaviour
{
    bool Filtered(LogSeverity severity, string message);
}

public interface ILogFormatterBehaviour
{
    string Format(LogSeverity severity, string message);
}
    
public interface ILogWriterBehaviour
{
    void WriteLine(string message);
}

public class DefaultLogBehaviours : ILogFilterBehaviour, ILogFormatterBehaviour,
    ILogWriterBehaviour
{
    public static LogSeverity MinimumSeverity = LogSeverity.SystemInformation;
    private static readonly string logFileName;

    static DefaultLogBehaviours()
    {
        logFileName = ConfigurationManager.AppSettings["LogFile"];
    }

    public bool Filtered(LogSeverity severity, string message)
    {
        return severity > MinimumSeverity;
    }

    public string Format(LogSeverity severity, string message)
    {
        return string.Format("{0} [{1}]: {2}", DateTime.Now, 
            severity.ToString(), message);
    }

    public void WriteLine(string message)
    {
        using (StreamWriter writer = new StreamWriter(logFileName, true))
        {
            writer.WriteLine(message);
        }
    }
}

public class LibraryLogger : ILogger
{
    private ILogFilterBehaviour filter;
    private ILogFormatterBehaviour formatter;
    private ILogWriterBehaviour writer;

    public LibraryLogger(ILogFilterBehaviour filter, 
        ILogFormatterBehaviour formatter,
        ILogWriterBehaviour writer)
    {
        this.filter = filter;
        this.formatter = formatter;
        this.writer = writer;
    }

    public void Write(LogSeverity severity, string message)
    {
        if (!filter.Filtered(severity, message))
        {
            writer.WriteLine(formatter.Format(severity, message));
        }
    }
}

public static class LogFactory
{
    public static ILogger CreateLogger()
    { 
        DefaultLogBehaviours defaultBehaviours = new DefaultLogBehaviours();
        return new LibraryLogger(defaultBehaviours, 
            defaultBehaviours, defaultBehaviours);
    }
}

}
