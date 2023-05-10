using System.Text;
using System.Security.Cryptography;
using System.Text;

namespace eCommerceProject.Models
{
    public class TransactionKey
    {
        public static string CreateTransactionKey(string transactionId, DateTime timestamp)
    {
        // Combine the transaction data into a single string
        string transactionData = $"{transactionId}|{timestamp.ToString("yyyyMMddHHmmssfff")}";

        // Compute the hash value using the SHA256 algorithm
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(transactionData));
            return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
        }
    }
}
}
