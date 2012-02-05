using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;

namespace TestLib.LibraryCode
{
public enum ApplicationLoggerSeverity
{
    Error,
    Warning,
    Information,
    Debug
}

public static class ApplicationLogger
{
    private static readonly string logFileName;

#if DEBUG
    private const ApplicationLoggerSeverity minimumSeverity = ApplicationLoggerSeverity.Debug;
#else
    private const ApplicationLoggerSeverity minimumSeverity = ApplicationLoggerSeverity.Information;
#endif

    static ApplicationLogger()
    {
        logFileName = ConfigurationManager.AppSettings["LogFile"];
    }

    public static void Write(ApplicationLoggerSeverity severity, string message)
    {
        if (severity <= minimumSeverity)
        {
            using (StreamWriter writer = new StreamWriter(logFileName, true))
            {
                writer.WriteLine("{0} [{1}]: {2}", DateTime.Now, severity.ToString(), message);
            }
        }
    }
}
}
