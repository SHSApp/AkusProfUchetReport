using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SHSApp_Profuchet
{
    public static class Tools
    {
        public static string FirstToUpper(string str)
        {
            if (str.Length > 0) { return Char.ToUpper(str[0]) + str.Substring(1); }
            return "";
        }

        public static string MonthToString(int month)
        {
            string res = "";
            switch (month)
            {
                case 1:
                    res = "января";
                    break;
                case 2:
                    res = "февраля";
                    break;
                case 3:
                    res = "марта";
                    break;
                case 4:
                    res = "апреля";
                    break;
                case 5:
                    res = "мая";
                    break;
                case 6:
                    res = "июня";
                    break;
                case 7:
                    res = "июля";
                    break;
                case 8:
                    res = "августа";
                    break;
                case 9:
                    res = "сентября";
                    break;
                case 10:
                    res = "октября";
                    break;
                case 11:
                    res = "ноября";
                    break;
                case 12:
                    res = "декабря";
                    break;
            }
            return res;
        }

        public static string HoursToString(int hours)
        {
            string res = "";
            switch (hours)
            {
                case 0:
                    res = "00 часов";
                    break;
                case 1:
                    res = "01 час";
                    break;
                case 2:
                    res = "02 часа";
                    break;
                case 3:
                    res = "03 часа";
                    break;
                case 4:
                    res = "04 часа";
                    break;
                case 5:
                    res = "05 часов";
                    break;
                case 6:
                    res = "06 часов";
                    break;
                case 7:
                    res = "07 часов";
                    break;
                case 8:
                    res = "08 часов";
                    break;
                case 9:
                    res = "09 часов";
                    break;
                case 21:
                    res = "21 час";
                    break;
                case 22:
                    res = "22 часа";
                    break;
                case 23:
                    res = "23 часа";
                    break;
                default:
                    res = hours.ToString() + " часов";
                    break;
            }
            return res;
        }

        public static string MinutesToString(int minutes)
        {
            string res = "";
            if (minutes < 10)
            {
                res = "0" + minutes.ToString();
            }
            else
            {
                res = minutes.ToString();
            }
            if ((minutes > 10) && (minutes < 20))
            {
                res += " минут";
            }
            else
            {
                switch (minutes % 10)
                {
                    case 0:
                        res += " минут";
                        break;
                    case 1:
                        res += " минуту";
                        break;
                    case 2:
                        res += " минуты";
                        break;
                    case 3:
                        res += " минуты";
                        break;
                    case 4:
                        res += " минуты";
                        break;
                    default:
                        res += " минут";
                        break;
                }
            }
            return res;
        }
    }
}
