using System.ComponentModel.DataAnnotations;

namespace MvcApplication.Bundles.Core.Entity
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(45), MinLength(3), Required]
        public string Name { get; set; }

        [MaxLength(45), MinLength(3), Required]
        public string Surname { get; set; }

        [MaxLength(45), MinLength(11), Required]
        public string Account { get; set; }

        [MaxLength(45), Required]
        public double Ballance { get; set; }
    }
}