using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    /// <summary>
    /// Extended the HtmlHelper for Calendar
    /// </summary>
    public static class CalendarExtensions
    {
        /// <summary>
        /// Generate a default calendar with the current date
        /// </summary>
        /// <param name="helper">the HtmlHelper object</param>
        /// <returns>well-formed XHTML string</returns>
        public static string Calendar(this HtmlHelper helper)
        {
            Calendar cal = new Calendar();
            return cal.ToString();
        }

        /// <summary>
        /// Generate a calendar with the specified name and the current date
        /// </summary>
        /// <param name="helper">the HtmlHelper object</param>
        /// <param name="name">the name of the calendar</param>
        /// <returns>well-formed XHTML string</returns>
        public static string Calendar(this HtmlHelper helper, string name)
        {
            Calendar cal = new Calendar(name);
            return cal.ToString();
        }

        /// <summary>
        /// Generate a calendar with the specified name and date
        /// </summary>
        /// <param name="helper">the HtmlHelper object</param>
        /// <param name="name">the name of the calendar</param>
        /// <param name="selectedDate">the date to show in the calendar</param>
        /// <returns>well-formed XHTML string</returns>
        public static string Calendar(this HtmlHelper helper, string name, DateTime selectedDate)
        {
            Calendar cal = new Calendar(name, selectedDate);
            return cal.ToString();
        }

        /// <summary>
        /// Generate a calendar with data array and specified fields
        /// </summary>
        /// <param name="helper">the HtmlHelper object</param>
        /// <param name="name">the name of the calendar</param>
        /// <param name="rawDates">the DateTime array</param>
        /// <param name="controllerName">the controller name</param>
        /// <param name="actionName">the action name</param>
        /// <returns>well-formed XHTML string</returns>
        public static string Calendar(this HtmlHelper helper, string name,
            IEnumerable<DateTime> rawDates,
            string controllerName, string actionName)
        {
            Calendar cal = new Calendar(name, DateTime.Now, rawDates, helper, controllerName, actionName);
            return cal.ToString();
        }

        /// <summary>
        /// Generate a calendar with data array and specified fields
        /// </summary>
        /// <param name="helper">the HtmlHelper object</param>
        /// <param name="name">the name of the calendar</param>
        /// <param name="selectedDate">the date to show int the calendar</param>
        /// <param name="rawDates">the DateTime array</param>
        /// <param name="controllerName">the controller name</param>
        /// <param name="actionName">the action name</param>
        /// <returns>well-formed XHTML string</returns>
        public static string Calendar(this HtmlHelper helper, string name,
            DateTime selectedDate,
            IEnumerable<DateTime> rawDates,
            string controllerName, string actionName)
        {
            Calendar cal = new Calendar(name, selectedDate, rawDates, helper, controllerName, actionName);
            return cal.ToString();
        }

    }
}
