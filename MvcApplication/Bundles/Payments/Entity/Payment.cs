using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Bundles.Payments.Entity
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int CreditCardId { get; set; }

        [Required]
        public double TransferedValue { get; set; }

        [Required]
        public int BeneficiaryId { get; set; }

        [MaxLength(100)]
        public string Information { get; set; }
    }
}