using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Bundles.Core.Entity
{
    public class ActiveBank
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45), MinLength(5), Required]
        public string Name { get; set; }

        [MaxLength(45), MinLength(5), Required]
        public string ApiEntryPoint { get; set; }

        [MaxLength(45), MinLength(5), Required]
        public string Info { get; set; }
    }
}