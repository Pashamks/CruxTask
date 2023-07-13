using CruxTask.Models;

namespace CruxTask.Validator
{
    internal static class CommonValidator
    {
        static readonly int MIN_SYMBOLS_COUNT = 4;
        public static void ValidateInput(int key, bool isParsed, Dictionary<int, string> menus)
        {
            if (!isParsed)
            {
                Console.WriteLine("Sorry we can not parse your input. Try again.");
            }
            else if (!menus.ContainsKey(key))
            {
                Console.WriteLine("Sorry we do not have this option in menu.");
            }
        }
        public static void ValidateNumbersRange(string range, (int Min, int Max) rangeValues)
        {
            if (range.Count() < MIN_SYMBOLS_COUNT)
                throw new Exception($"The is not enough symbol for range {range}.");

            if (rangeValues.Max < rangeValues.Min)
                throw new Exception("Sorry we can not accept min value bigger then max.");
        }
        public static void ValidateValueToInt(bool isValid, string valueName)
        {
            if (!isValid)
                throw new Exception($"Sorry we can not parse {valueName} value of range to int");

        }
        public static void ValdiateFirstLetter(string letter)
        {
            if (letter.Count() != 1)
                throw new Exception($"The is more then one letter in {letter}.");
        }
        public static void ValidateElementsCount(List<string> items)
        {
            if (items.Count != 3)
                throw new Exception($"String can not be parsed to type {nameof(PasswordValidationModel)}.");
        }
    }
}
