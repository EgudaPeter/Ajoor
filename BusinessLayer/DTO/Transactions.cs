using System;

namespace Ajoor.BusinessLayer.DTO
{
    public class Transactions
    {
        public long TransactionId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CapturerName { get; set; }
        public int AccountNumber { get; set; }
        public string TransactionType { get; set; }
        public decimal? AmountContributed { get; set; }
        public decimal? AmountCollected { get; set; }
        public DateTime? Date{ get; set; }
        public decimal? Commission { get; set; }
        public decimal? ExtraCommission { get; set; }
        public decimal? AmountPayable { get; set; }
        public decimal? Debt { get; set; }
        public decimal? TotalDebt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public decimal? EOMBalance { get; set; }
    }
}
