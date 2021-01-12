using System.ComponentModel.DataAnnotations;

namespace ExamText.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}