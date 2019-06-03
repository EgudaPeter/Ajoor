using System;

namespace Ajoor.BusinessLayer.DTO
{
    public class CreditTransactions
    {
        public long TransactionId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string TransactionType { get; set; }
        public decimal? AmountContributed { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Commission { get; set; }
        public decimal? AmountPayable { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
