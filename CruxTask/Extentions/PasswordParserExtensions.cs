using CruxTask.Models;
using CruxTask.Validator;

namespace CruxTask.Extentions
{
    internal static class PasswordParserExtensions
    {
        static readonly int LETTER_INDEX = 0, NUMBERS_RANGE_INDEX = 1, PASSWORD_INDEX = 2;
        static readonly string NUMBERS_SEPARATOR = "-", RANGE_AND_PASSWORD_SEPARATOR = ":";
        public static PasswordValidationModel StringToPasswordValidationModel(string item)
        {
            try
            {
                var items = item.SplitDataToRows(" ");
                CommonValidator.ValidateElementsCount(items);

                var model = new PasswordValidationModel();
                FillAndValidatePasswordModel(model, items);

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception($"{ex.Message} in item : {item}");
            }

        }
        private static void FillAndValidatePasswordModel(PasswordValidationModel model, List<string> items)
        {
            CommonValidator.ValdiateFirstLetter(items[LETTER_INDEX]);         
            model.Letter = items[LETTER_INDEX];

            var elements = items[NUMBERS_RANGE_INDEX].SplitDataToRows(NUMBERS_SEPARATOR);
            var rangeValues = GetMinMaxValueFromRange(elements);

            CommonValidator.ValidateNumbersRange(items[NUMBERS_RANGE_INDEX], rangeValues);
            model.MinRepeatCount = rangeValues.Min;
            model.MaxRepeatCount = rangeValues.Max;

            model.Password = items[PASSWORD_INDEX];
        }
        
        private static (int Min, int Max) GetMinMaxValueFromRange(List<string> elements)
        {
            var isMinNumberParsed = int.TryParse(elements[0], out int min);
            CommonValidator.ValidateValueToInt(isMinNumberParsed, nameof(min));

            elements[1] = elements[1].Replace(RANGE_AND_PASSWORD_SEPARATOR, string.Empty);
            var isMaxNumberParsed = int.TryParse(elements[1], out int max);
            CommonValidator.ValidateValueToInt(isMaxNumberParsed, nameof(max));

            return (min, max);
        }

    }
}
