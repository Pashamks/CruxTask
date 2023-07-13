
namespace CruxTask.Models
{
    internal class PasswordValidationModel
    {
        public string Letter { get; set; }
        public int MinRepeatCount { get; set; }
        public int MaxRepeatCount { get; set; }
        public string Password { get; set; }
    }
}
