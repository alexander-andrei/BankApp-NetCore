using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Bundles.Core.Entity
{
    public class Beneficiary
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45), MinLength(3), Required]
        public string Name { get; set; }

        [MaxLength(45), MinLength(3), Required]
        public string Surname { get; set; }

        [MaxLength(45), MinLength(11), Required]
        public string Account { get; set; }

        [MaxLength(5), MinLength(1), Required]
        public int BankId { get; set; }

        [MaxLength(45), MinLength(3), Required]
        public double TransferredSum { get; set; }
    }
}