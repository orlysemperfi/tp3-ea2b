using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
//using Microsoft.Practices.EnterpriseLibrary.Logging;

namespace TMD.CF.Site
{
    public class ApplicationLogger
    {
        public static void Write(string message, ICollection<string> categories, int priority, int eventId,
            TraceEventType severity, string title, IDictionary<string, object> properties)
        {
            //LogEntry log = new LogEntry()
            //{
            //    Message = message,
            //    Priority = priority,
            //    EventId = eventId,
            //    Severity = severity,
            //    Title = string.IsNullOrEmpty(title) ? "Logging Application block Sample" : title,
            //    ExtendedProperties = properties,
            //};

            ////If categories is null logger will not write it
            ////If categories is not defined log will be written to default category
            //if (categories != null)
            //{
            //    log.Categories = categories;
            //}

            //Logger.Write(log);
        }
    }
}