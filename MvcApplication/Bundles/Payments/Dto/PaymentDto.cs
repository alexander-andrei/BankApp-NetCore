using MvcApplication.Bundles.Core.Entity;

namespace MvcApplication.Bundles.Payments.Dto
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public Beneficiary Beneficiary { get; set; }
        public double TransferedValue { get; set; }
    }
}