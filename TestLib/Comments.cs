using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TestLib
{
    namespace CommentsBad
    {
// ********************************************************************
// * Logger helper                                                    *
// *                                                                  *
// * 2005-03-01 First Version, Anders Abel                            *
// * 2007-08-17 Added Console Output, Anders Abel                     *
// * 2009-12-15 Removed file output, John Doe                         *
// *                                                                  *
// * Usage: Call Logger.Write() with string to be logged.             *
// ********************************************************************
public static class Logger
{
    public static void Write(string message)
    {
        //using(StreamWriter writer = new StreamWriter("c:\\temp\\log.txt"))
        //{
        //    writer.WriteLine(message);
        //}
        Console.WriteLine(message);
    }
}
    }

    namespace CommentsGood
    {
/// <summary>
/// Logger helper
/// </summary>
public static class Logger
{
    /// <summary>
    /// Logs a string ot the log output.
    /// </summary>
    /// <param name="message">String to log.</param>
    public static void Write(string message)
    {
        // File logging code removed 2009-12-15. See version control.

        Console.WriteLine(message);
    }
}
    }
}
