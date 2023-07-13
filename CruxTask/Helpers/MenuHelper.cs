
using CruxTask.Enums;
using CruxTask.Extentions;

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

                ValidateInput(key, isParsed);


            }
        }

        private static void ValidateInput(int key, bool isParsed)
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
    }
}
