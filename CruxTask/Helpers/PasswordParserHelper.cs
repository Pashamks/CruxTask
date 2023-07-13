
using CruxTask.Extentions;
using CruxTask.Models;

namespace CruxTask.Helpers
{
    internal class PasswordParserHelper
    {
        private static int CountValidPasswords(string data)
        {
            int counter = 0;
            var passwordModels = ParseRowsToPasswordModels(CommonExtentions.SplitDataToRows(data, "\n"));
            foreach (var passwordModel in passwordModels)
            {
                var amountOfLetters = passwordModel.Password.Where(x => x == passwordModel.Letter[0]).Count();

                if (amountOfLetters <= passwordModel.MaxRepeatCount && amountOfLetters >= passwordModel.MinRepeatCount)
                    counter++;
            }
            return counter;
        }
        public static int CountValidPasswordFromFile(string fileName)=>
            CountValidPasswords(File.ReadAllText(fileName));

        private static List<PasswordValidationModel> ParseRowsToPasswordModels(List<string> rows)=>
            rows.Select(x => PasswordParserExtensions.StringToPasswordValidationModel(x)).ToList();
    }
}
