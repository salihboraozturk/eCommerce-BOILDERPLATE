using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}