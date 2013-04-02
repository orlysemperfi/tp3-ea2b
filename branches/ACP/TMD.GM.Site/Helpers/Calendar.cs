using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.Mvc.Html;
using System.Web;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace System.Web.Mvc
{
    /// <summary>
    /// Well-formed XHTML Calendar for ASP.NET MVC
    /// </summary>
    public class Calendar
    {
        /// <summary>
        /// Gets the name of current calendar, it's diaplayed as the "id" of the HTML element "table"
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the selected date of current calendar
        /// </summary>
        public DateTime SelectedDate { get; private set; }

        /// <summary>
        /// Gets the date array which to generate the links
        /// </summary>
        public IEnumerable<DateTime> RawDates { get; private set; }

        /// <summary>
        /// Gets the controller name that to generate the daily links
        /// </summary>
        public string ControllerName { get; private set; }

        /// <summary>
        /// Gets the action name that to generate the daily links
        /// </summary>
        public string ActionName { get; private set; }

        private HtmlHelper helper;

        /// <summary>
        /// default calendar
        /// </summary>
        public Calendar()
        {
            this.SelectedDate = DateTime.Now;
            this.Name = "MvcCalendar";
        }

        /// <summary>
        /// Create a calendar use the specified name
        /// </summary>
        /// <param name="name">the name of calendar</param>
        public Calendar(string name)
            : this()
        {
            this.Name = name;
        }

        /// <summary>
        /// Create a calendar use the specified name and selected date
        /// </summary>
        /// <param name="name">the name of calendar</param>
        /// <param name="selectedDate">selected date</param>
        public Calendar(string name, DateTime selectedDate)
            : this(name)
        {
            this.SelectedDate = selectedDate;
        }

        /// <summary>
        /// Create a calendar use data that generate links
        /// </summary>
        /// <param name="name">the name of calendar</param>
        /// <param name="selectedDate">selected date</param>
        /// <param name="rawDates">the date array</param>
        /// <param name="helper">HtmlHelper object</param>
        /// <param name="controllerName">controller name</param>
        /// <param name="actionName">action name</param>
        public Calendar(string name, DateTime selectedDate, IEnumerable<DateTime> rawDates, HtmlHelper helper, string controllerName, string actionName)
            : this(name)
        {
            this.SelectedDate = selectedDate;
            this.RawDates = rawDates;
            this.helper = helper;
            this.ControllerName = controllerName;
            this.ActionName = actionName;
        }

        private string GenerateHeader()
        {
            string prevLink = string.Empty;
            string nextLink = string.Empty;

            var header = new StringBuilder();
            header.AppendFormat("<table id=\"{0}\" class=\"tbCalendar\">", this.Name);

            if (this.helper != null && this.RawDates != null)
            {
                bool hasPrev = false;
                bool hasNext = false;

                foreach (var date in RawDates)
                {
                    if (date.Year == SelectedDate.Year && date.Month < SelectedDate.Month) hasPrev = true;
                    if (date.Year == SelectedDate.Year && date.Month > SelectedDate.Month) hasNext = true;
                }

                if (hasPrev) prevLink = helper.ActionLink("<<", this.ActionName, this.ControllerName, new { date = string.Format("{0}-{1}", SelectedDate.AddMonths(-1).Year, SelectedDate.AddMonths(-1).Month) }).ToString();
                if (hasNext) nextLink = helper.ActionLink(">>", this.ActionName, this.ControllerName, new { date = string.Format("{0}-{1}", SelectedDate.AddMonths(1).Year, SelectedDate.AddMonths(1).Month) }).ToString();
            }

            header.AppendFormat("<caption>{0} {1} {2}</caption>", prevLink, this.SelectedDate.ToString("y"), nextLink);
            
            header.Append("<tr>");

            //header.Append("<th scope=\"col\" abbr=\"Sunday\" title=\"Sunday\">Sun</th>");
            //header.Append("<th scope=\"col\" abbr=\"Monday\" title=\"Monday\">Mon</th>");
            //header.Append("<th scope=\"col\" abbr=\"Tuesday\" title=\"Tuesday\">Tue</th>");
            //header.Append("<th scope=\"col\" abbr=\"Wednesday\" title=\"Wednesday\">Wed</th>");
            //header.Append("<th scope=\"col\" abbr=\"Thursday\" title=\"Thursday\">Thu</th>");
            //header.Append("<th scope=\"col\" abbr=\"Friday\" title=\"Friday\">Fri</th>");
            //header.Append("<th scope=\"col\" abbr=\"Saturday\" title=\"Saturday\">Sat</th>");

            header.Append("<th scope=\"col\" abbr=\"Domingo\" title=\"Domingo\">do</th>");
            header.Append("<th scope=\"col\" abbr=\"Lunes\" title=\"Lunes\">lu</th>");
            header.Append("<th scope=\"col\" abbr=\"Martes\" title=\"Martes\">ma</th>");
            header.Append("<th scope=\"col\" abbr=\"Miercoles\" title=\"Miercoles\">mi</th>");
            header.Append("<th scope=\"col\" abbr=\"Jueves\" title=\"Jueves\">ju</th>");
            header.Append("<th scope=\"col\" abbr=\"Viernes\" title=\"Viernes\">vi</th>");
            header.Append("<th scope=\"col\" abbr=\"Sabado\" title=\"Sabado\">sa</th>");

            //header.Append("<th scope=\"col\" abbr=\"星期日\" title=\"星期日\">日</th>");
            //header.Append("<th scope=\"col\" abbr=\"星期一\" title=\"星期一\">一</th>");
            //header.Append("<th scope=\"col\" abbr=\"星期二\" title=\"星期二\">二</th>");
            //header.Append("<th scope=\"col\" abbr=\"星期三\" title=\"星期三\">三</th>");
            //header.Append("<th scope=\"col\" abbr=\"星期四\" title=\"星期四\">四</th>");
            //header.Append("<th scope=\"col\" abbr=\"星期五\" title=\"星期五\">五</th>");
            //header.Append("<th scope=\"col\" abbr=\"星期六\" title=\"星期六\">六</th>");

            header.Append("</tr>");

            return header.ToString();
        }

        private string GenerateFooter()
        {
            return "</table>";
        }

        private string GenerateDays()
        {
            var now = DateTime.Now;
            var date = new DateTime(this.SelectedDate.Year, this.SelectedDate.Month, 1);
            var days = DateTime.DaysInMonth(this.SelectedDate.Year, this.SelectedDate.Month);
            var weekDayOfFirstDay = (int)date.DayOfWeek;

            var daysXhtml = new StringBuilder();

            int day = 1;//first day of the date's month
            int weekDay = 0;//0 - 6

            if (weekDayOfFirstDay > 0)
            {
                daysXhtml.Append("<tr>");
                while (weekDay < weekDayOfFirstDay)
                {
                    daysXhtml.Append("<td>&nbsp;</td>");
                    weekDay++;
                }
            }

            while (day <= days)
            {
                if (weekDay == 0) daysXhtml.Append("<tr>");

                if (date.Year == now.Year && date.Month == now.Month && day == now.Day)
                    daysXhtml.Append("<td class=\"today\">" + "<a href='#" + day + "'>" + day + "</a>" + "</td>");
                else
                    daysXhtml.Append("<td>" + "<a href='#" + day + "'>" + day + "</a>" + "</td>");

                if (weekDay == 6)
                {
                    daysXhtml.Append("</tr>");
                    weekDay = -1;
                }

                day++;
                weekDay++;
            }

            if (weekDay > 0)
            {
                while (weekDay < 7)
                {
                    daysXhtml.Append("<td>&nbsp;</td>");
                    weekDay++;
                }
                daysXhtml.Append("</tr>");
            }

            return daysXhtml.ToString();
        }

        private string GenerateDays(IEnumerable<DateTime> rawDates)
        {
            var now = DateTime.Now;
            var date = new DateTime(this.SelectedDate.Year, this.SelectedDate.Month, 1);
            var days = DateTime.DaysInMonth(this.SelectedDate.Year, this.SelectedDate.Month);
            var weekDayOfFirstDay = (int)date.DayOfWeek;

            var daysXhtml = new StringBuilder();

            int day = 1;//first day of the date's month
            int weekDay = 0;//0 - 6

            if (weekDayOfFirstDay > 0)
            {
                daysXhtml.Append("<tr>");
                while (weekDay < weekDayOfFirstDay)
                {
                    daysXhtml.Append("<td>&nbsp;</td>");
                    weekDay++;
                }
            }

            while (day <= days)
            {
                if (weekDay == 0) daysXhtml.Append("<tr>");

                var caldate = new DateTime(date.Year, date.Month, day);
                int count = (from d in rawDates
                         where d.Date == caldate.Date
                         select d).Count();
                string dayString = day.ToString();

                if (count > 0) dayString = helper.ActionLink(day.ToString(), ActionName, ControllerName, new { date = string.Format("{0}-{1}-{2}", caldate.Year, caldate.Month, caldate.Day) }).ToString();

                if (date.Year == now.Year && date.Month == now.Month && day == now.Day)
                    daysXhtml.Append("<td class=\"today\">" + dayString + "</td>");
                else
                    daysXhtml.Append("<td>" + dayString + "</td>");

                if (weekDay == 6)
                {
                    daysXhtml.Append("</tr>");
                    weekDay = -1;
                }

                day++;
                weekDay++;
            }

            if (weekDay > 0)
            {
                while (weekDay < 7)
                {
                    daysXhtml.Append("<td>&nbsp;</td>");
                    weekDay++;
                }
                daysXhtml.Append("</tr>");
            }

            return daysXhtml.ToString();
        }

        /// <summary>
        /// Returns the built calendar
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var calendar = new StringBuilder();

            if (this.RawDates != null)
            {
                //Build a calendar with links
                calendar.AppendFormat("{0}{1}{2}",
                    GenerateHeader(),
                    GenerateDays(RawDates),
                    GenerateFooter()
                    );
            }
            else
            {
                //build an empty calendar for current month
                calendar.AppendFormat("{0}{1}{2}",
                    GenerateHeader(),
                    GenerateDays(),
                    GenerateFooter()
                    );
            }

            return calendar.ToString();
        }
    }

}