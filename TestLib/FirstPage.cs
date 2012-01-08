using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestLib
{

    public enum PersonStatus
    {
        NewVisitor = 0,
        OccasionalVisitor,
        FrequentVisitor
    }

    class UnexpectedGuestException : Exception
    {
    }

    class FirstPage
    {
        /// <summary>
        /// Builder of welcome messages. The message returned is highly personalized for the visitor.
        /// </summary>
        /// <param name="visitorName">The name of the visitor. Used to personalize the welcome message.</param>
        /// <returns>A welcome message</returns>
        /// <exception cref="UnexpectedGuestException">An unexpected type of guest visited.</exception>
        public static string BuildWelcomeMessage(string visitorName)
        {
            using (DBContext context = new DBContext())
                switch ((from p in context.Persons
                         where p.DisplayName == visitorName
                         select p.PersonStatus).SingleOrDefault())
                {
                    case PersonStatus.NewVisitor:
                        return "Welcome to my blog, I hope you will find it interesting.";
                    case PersonStatus.OccasionalVisitor:
                        return "Welcome back to my blog, I have written some new posts since the last time for you to read. Especially the last one should be interesting for you.";
                    case PersonStatus.FrequentVisitor:
                        return "Nice to see you here again so soon. I am afraid that there is not very much new content. I hope you'll find my last post interesting.";
                    default:
                        throw new UnexpectedGuestException();
                }
        }
    }
}
