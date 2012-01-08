using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodingAbelNu.Utilities;
using System.IO;

namespace TestLib
{
public class LogWriterFromDisposable : Disposable
{
    private StreamWriter m_Stream;

    public LogWriterFromDisposable(string logFile)
    {
        m_Stream = new StreamWriter(logFile, true);
        m_Stream.WriteLine("Starting logging at {0}", DateTime.Now);
    }

    public void WriteLine(string message)
    {
        m_Stream.WriteLine(message);
    }

    protected override void Dispose(bool disposing)
    {
        if (!Disposed && disposing)
        {
            m_Stream.Dispose();
        }

        base.Dispose(disposing);
    }
}
}
