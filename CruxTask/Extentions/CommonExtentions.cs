using CruxTask.Enums;

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
    }
}
