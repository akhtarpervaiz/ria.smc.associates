using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ria.smc.associates.Common.CommonLayerHelper.DataTypeEnum;

namespace ria.smc.associates.Common.CommonLayerHelper
{
    public static class DatatypeConversions
    {
        public static int ToIntVaue(this object obj)
        {
            string value = obj.ToStringValue();
            return string.IsNullOrEmpty(value) ? 0 : Convert.ToInt32(value);
        }

        public static int? ToIntNullVaue(this object obj)
        {
            string value = obj.ToStringValue();
            return string.IsNullOrEmpty(value) ? (int?)null : Convert.ToInt32(value);
        }
        public static short ToShortValue(this object obj)
        {
            string value = obj.ToStringValue();
            return string.IsNullOrEmpty(value) ? (short)0 : Convert.ToInt16(value);
        }

        public static int ToIntValueFromDecimalString(this object obj)
        {
            decimal value = obj.ToDecimalVaue();
            return Convert.ToInt32(value);
        }
        public static long ToLongValueFromDecimalString(this object obj)
        {
            decimal value = obj.ToDecimalVaue();
            return Convert.ToInt64(value);
        }
        public static decimal ToDecimalFromDate(this DateTime date) => Convert.ToDecimal(date.ToString("yyyyMMddHHmmss"));

        public static long ToLongVaue(this object obj)
        {
            string value = (obj ?? "").ToString().Trim();
            if (string.IsNullOrEmpty(value))
                return 0;

            return Convert.ToInt64(value);
        }
        public static decimal ToDecimalVaue(this object obj)
        {
            string value = (obj ?? "").ToString().Trim();
            if (string.IsNullOrEmpty(value))
                return 0;

            return Convert.ToDecimal(value);
        }

        public static decimal ToDecimalVaue(this object obj, CultureInfo cultureInfo)
        {
            string value = (obj ?? "").ToString().Trim();
            if (string.IsNullOrEmpty(value))
                return 0;

            return Convert.ToDecimal(value, cultureInfo);
        }

        public static decimal ToDecimalRoud0(this object obj) => Math.Round(obj.ToDecimalVaue(), 0);

        public static string ToBoolStringValue(this object obj, BoolFormat boolFormat = BoolFormat.TRUEFALSE)
        {
            string value = (obj ?? "").ToString().ToLower().Trim();
            if (string.IsNullOrEmpty(value))
                return "";

            if (BoolFormat.TRUEFALSE == boolFormat)
            {
                if (value == "0" || value == "false" || value == "no") // || value == string.Empty
                    return "False";
                else if (value == "1" || value == "true" || value == "yes")
                    return "True";

            }
            else if (BoolFormat.YESNO == boolFormat)
            {
                if (value == "0" || value == "false" || value == "no")
                    return "No";
                else if (value == "1" || value == "true" || value == "yes")
                    return "Yes";
            }
            else if (BoolFormat.ZEROONE == boolFormat)
            {
                if (value == "0" || value == "false" || value == "no")
                    return "0";
                else if (value == "1" || value == "true" || value == "yes")
                    return "1";
            }

            return "";
        }

        public static bool ToBoolFromString(this object obj)
        {
            string value = obj.ToBoolStringValue();
            if (string.IsNullOrEmpty(value) || value == "False" || value == "0" || value == "No")
                return false;
            else
                return true;
        }

        public static string ToStringValue(this object obj) => (obj ?? "").ToString().Trim();

        public static string ToStringLower(this object obj) => obj.ToStringValue().ToLower();
        public static string ToStringUpper(this object obj) => obj.ToStringValue().ToUpper();
        public static string ToTitleCase(this object s) =>
      CultureInfo.InvariantCulture.TextInfo.ToTitleCase(s.ToStringValue().ToLower());
        public static string ToReplaceEmptyLower(this object obj) => obj.ToStringLower().Replace(" ", string.Empty);

        public static string ToStringCleanHtml(this object obj)
        {
            string objString = obj.ToStringValue();

            return objString
                        .Replace("\r", "")
                        .Replace("\n", "")
                        .Replace("\t", "");
        }
        public static DateTime ToDateTime(this decimal value, IFormatProvider provider) => DateTime.ParseExact(value.ToString(provider), "yyyyMMddHHmmss", provider);
        public static DateTime? ToDateTime(this object value)
        {
            var obj = value.ToStringValue();
            if (string.IsNullOrEmpty(obj))
                return null;

            bool isConvert = DateTime.TryParse(obj, out DateTime result);

            if (isConvert)
                return result;

            return null;
        }

        public static object ToDbValue(this object obj)
        {
            string str = obj.ToStringValue();

            if (string.IsNullOrEmpty(str))
                return DBNull.Value;

            return str;
        }

        public static string ToDateTimeAsString(this object val, string datetimePattern)
        {
            if (val != null && val is DateTime)
                return Convert.ToDateTime(val).ToString(datetimePattern);
            else
            {
                var obj = val.ToStringValue();
                if (string.IsNullOrEmpty(obj))
                    return "";

                DateTime dateTime = DateTime.ParseExact(obj, datetimePattern, CultureInfo.InvariantCulture);
                return dateTime.ToString(datetimePattern);
            }
        }

        public static string ToStringIntermediateBoolean(this bool? obj) => obj.HasValue == false ? "2" : obj.Value.ToStringBoolean();
        public static string ToStringBoolean(this bool obj) => obj ? "1" : "0";

        public static bool IsValidNumber(this string value)
        {
            return string.IsNullOrEmpty(value) || value.All(char.IsDigit);
        }
        public static bool IsFromAndToDateValid(this DateTime fromDate, DateTime toDate, bool isFullDateValidation = false)
        {

            if (fromDate.Date >= toDate.Date)
                return false;

            return true;
        }

        public static string ToHexString(this byte[] bytes)
        {
            return bytes != null ? BitConverter.ToString(bytes).Replace("-", string.Empty) : string.Empty;
        }
        public static string ToStringWithoutDash(this Guid guid)
        {
            return guid.ToStringUpper().Replace("-", string.Empty);
        }



        public static string ToGetQurtzReadableCronExpression(this string cronExpression)
        {

            string[] parts = cronExpression.Split(' ');

            if (parts.Length < 6)
                throw new ArgumentException("Invalid cron expression format.");

            string seconds = parts[0];
            string minutes = parts[1];
            string hours = parts[2];
            string dayOfMonth = parts[3];
            string month = parts[4];
            string dayOfWeek = parts[5];

            string readableFormat = "At ";

            // Handle hours and minutes
            if (minutes == "*")
                readableFormat += "every minute";
            else if (minutes.Contains("/"))
                readableFormat += $"every {minutes.Split('/')[1]} minutes";
            else
                readableFormat += $"{minutes} minutes past the hour";

            if (hours == "*")
                readableFormat += ", every hour";
            else
                readableFormat += $" at {hours}";

            // Handle day of the month
            if (dayOfMonth == "?")
                readableFormat += "";
            else if (dayOfMonth == "*")
                readableFormat += ", every day";
            else
                readableFormat += $", on day {dayOfMonth}";

            // Handle month
            if (month == "*")
                readableFormat += " of every month";
            else
                readableFormat += $" in {month}";

            // Handle day of the week
            if (dayOfWeek != "?")
            {
                if (dayOfWeek == "*")
                    readableFormat += ", every day of the week";
                else
                    readableFormat += $", on {dayOfWeek}";
            }

            return readableFormat;
        }
    }

    public static class DataTypeEnum
    {
        public enum BoolFormat
        {
            YESNO,
            TRUEFALSE,
            ZEROONE
        };
    }

}
