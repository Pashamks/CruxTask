using CruxTask.Enums;
using CruxTask.Models;

namespace CruxTask.Extentions
{
    internal static class CommonExtentions
    {
        public static string DictionaryToString<T1, T2>(this Dictionary<T1, T2> keyValues)
        {
            string result = string.Empty;
            foreach (var item in keyValues.Keys)
            {
                result += $"Key - {item} | Option - {keyValues[item]}\n";
            }
            return result;
        }

       
        public static List<string> SplitDataToRows(this string data, string separator) =>
            data.Split(separator).ToList();
    }
}
