using System.Linq;
using System.Text.RegularExpressions;

namespace PersonsBase.myStd
{
    public static class MyRegex
    {
        public static string CompactSpaces(string value)
        {
            string pattern = @"\s+";
            string target = " ";
            Regex regex = new Regex(pattern);
            string result = regex.Replace(value, target);
            return result;
        }

        /// <summary>
        /// Удаляет все символны типа + - (). Возвращает только цифры из произвольной строки
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetDigits(string str)
        {
            string resultString = string.Join(string.Empty, Regex.Matches(str, @"\d+").OfType<Match>().Select(m => m.Value));
            return resultString;
        }

        /// <summary>
        /// Преобразует номер телефона в формат "8(999) 000-00-00"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string FormatPhone(string str)
        {
            Regex regex = new Regex(@"8\(\d\d\d\) \d\d\d-\d\d-\d\d");
            MatchCollection matches = regex.Matches(str);
            if (matches.Count > 0)
            {
                return str;
            }

            string p = GetDigits(str);
            if ((p.StartsWith("7") || (p.StartsWith("8")) && p.Length >= 10))
            {
                p = p.Substring(1);
            }
            var a = Regex.Replace(p, @"(\d{3})(\d{3})(\d{2})(\d{2})", "8($1) $2-$3-$4");
            return a;
        }

        /// <summary>
        /// Из строки "8(999) 000-00-00" возвращает только цифры "89990000000"
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetPhoneDigits(string str)
        {
            string p = GetDigits(str);
            if ((p.StartsWith("7") || (p.StartsWith("8")) && p.Length >= 10))
            {
                p = p.Substring(1);
            }
            var a = Regex.Replace(p, @"(\d{3})(\d{3})(\d{2})(\d{2})", "8$1$2$3$4");
            return a;
        }

    }
}
