using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.Models
{
    public class LoginModel
    {
        internal string username;

        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }
    }
}