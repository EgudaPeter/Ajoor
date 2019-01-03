using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ajoor.DTO
{
    public class DebitTransactions
    {
        public long TransactionId { get; set; }
        public long CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string TransactionType { get; set; }
        public decimal? AmountCollected { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Commission { get; set; }
        public decimal? AmountPayable { get; set; }
        public decimal? Debt { get; set; }
        public decimal? TotalDebt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        //public string UpdatedBy { get; set; }
        //public DateTime? UpdatedDate { get; set; }
    }
}
