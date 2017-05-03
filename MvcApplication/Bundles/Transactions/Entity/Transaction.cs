using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace MvcApplication.Bundles.Transactions.Entity
{
    public class Transaction : DbContext
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45), MinLength(5), Required]
        public string Information { get; set; }

        [Required]
        public int ActiveBankId { get; set; }

        [Required]
        public int BeneficiaryId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}