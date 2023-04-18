namespace eCommerceProject.Models
{
    public class CreateAccountModel
    {
        public int Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string? nameFull { get; set; }
        public string? cardNumber { get; set; }
        public string? cardExpDate { get; set; }
        public string? cardSecCode { get; set;}
        public int cardFunds { get; set;}
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
