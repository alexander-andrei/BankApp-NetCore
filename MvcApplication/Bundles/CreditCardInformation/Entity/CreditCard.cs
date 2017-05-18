using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Bundles.CreditCardInformation.Entity
{
    public class CreditCard
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }

        [MaxLength(7), MinLength(4), Required]
        public string PinNumber { get; set; }

        [MaxLength(45), MinLength(16), Required]
        public string CardNumber { get; set; }

        [MaxLength(45), MinLength(16), Required]
        public string Type { get; set; }

        [MaxLength(7), MinLength(3), Required]
        public string Ccavf { get; set; }

        [Required]
        public bool Security3D { get; set; }
    }
}