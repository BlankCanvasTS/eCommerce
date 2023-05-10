using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.Models
{
    public class CreateAccountModel
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string? username { get; set; }

        [Required]

        public string? password { get; set; }

        [Required]
        public string? nameFull { get; set; }

        [Required]
        public string? cardNumber { get; set; }

        [Required]
        public string? cardExpDate { get; set; }

        [Required]
        public string? cardSecCode { get; set;}

        [Required]
        public int cardFunds { get; set;}

        [Required]
        public Boolean? onHold { get; set; }

        public void CheckInputValue()
        {
            if (cardFunds < 20)
            {
                onHold = false;
            }
        }

    }
}
