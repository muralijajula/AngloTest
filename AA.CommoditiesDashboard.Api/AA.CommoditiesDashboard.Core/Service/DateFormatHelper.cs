using AA.CommoditiesDashboard.Domain.Models;
using System;

namespace AA.CommoditiesDashboard.Domain.Service
{
    public class DateFormatHelper
    {

        public static string GetDateFormat(MetricType dateRange)
        {
            switch (dateRange)
            {
                case MetricType.Daily:
                    return "MM-dd-yy";
                case MetricType.Monthly:
                    return "MMM yy";
                case MetricType.Yearly:
                    return "yyyy";
                default:
                    throw new NotImplementedException();
            }
        }
    }
}