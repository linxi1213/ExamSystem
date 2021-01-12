using System.ComponentModel.DataAnnotations;

namespace MyProject6.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}