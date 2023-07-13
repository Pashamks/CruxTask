
using CruxTask.Enums;
using CruxTask.Extentions;
using CruxTask.Settings;
using CruxTask.Validator;

namespace CruxTask.Helpers
{
    internal static class MenuHelper
    {
        static Dictionary<int, string> menus = new Dictionary<int, string>();

        static MenuHelper()
        {
            menus = new Dictionary<int, string>
            {
                {(int)MenuOptions.CountPasswword, "Count valid password in file." },
                {(int)MenuOptions.End, "End work." }            
            };
        }

        public static void StartMenu()
        {
            int key = (int) MenuOptions.None;
            bool isParsed = false;

            while (key != (int)MenuOptions.End)
            {
                Console.WriteLine("Choose menu option: \n" + menus.DictionaryToString());

                isParsed = int.TryParse(Console.ReadLine(), out key);

                CommonValidator.ValidateInput(key, isParsed, menus);

                if(key == (int)MenuOptions.CountPasswword)
                {
                    var amount = PasswordParserHelper.CountValidPasswordFromFile(FileSettings.FilePath);
                    Console.WriteLine($"Amount of valid passwords = {amount}");
                }
            }
        }
    }
}
