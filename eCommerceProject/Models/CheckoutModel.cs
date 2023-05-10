using System.ComponentModel.DataAnnotations;

namespace eCommerceProject.Models
{
    public class CheckoutModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "CardNumber")]
        public string CardNumber { get; set; }

        [Required]
        [Display(Name = "CardExpDate")]
        public string CardExpDate { get; set; }

        [Required]
        [Display(Name = "CardSecCode")]
        public string? CardSecCode { get; set; }
        public int CardFunds { get; set; }
        public Boolean OnHold { get; set; }


    }
}
