using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [StringLength(8,ErrorMessage = "You must specifiy password between 4 and 8 characters")]
        public string Password { get; set; }
    }
}