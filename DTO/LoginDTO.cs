using System.ComponentModel.DataAnnotations;

namespace ApiProjectTest.DTO
{
    public class LoginDTO
    {
        [Required]
        public string UserNAme { get; set; }

        [Required]
        public string PAssword { get; set; }
    }
}
