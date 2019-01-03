using Ajoor.DTO;
using Ajoor.Model;
using System.Collections.Generic;
using System.Linq;

namespace Ajoor.Repos
{
    public class TransactionRepo
    {
        AjoEntities entities = new AjoEntities();

        public bool CreditTransaction(Transactions transaction)
        {
            var record = entities.cor_transactions.OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == transaction.CustomerId).FirstOrDefault();
            if (record != null)
            {
                transaction.AmountPayable += record.AmountPayable;
            }
            var model = new cor_transactions()
            {
                CustomerId = transaction.CustomerId,
                AmountContributed = transaction.AmountContributed,
                AmountCollected = transaction.AmountCollected,
                TransactionType = transaction.TransactionType,
                Date = transaction.Date,
                Commission = transaction.Commission,
                AmountPayable = transaction.AmountPayable,
                TotalDebt = transaction.TotalDebt,
                Debt = 0m,
                CreatedBy = transaction.CreatedBy,
                CreatedDate = transaction.CreatedDate
            };
            entities.cor_transactions.Add(model);
            return entities.SaveChanges() > 0;
        }

        public bool ChangeTransactionCreator(Transactions transaction)
        {
            var recordToUpdate = entities.cor_transactions.Find(transaction.TransactionId);
            recordToUpdate.CreatedBy = transaction.CreatedBy;
            return entities.SaveChanges() > 0;
        }

        public bool DebitTransaction(Transactions transaction)
        {
            var record = entities.cor_transactions.OrderByDescending(x => x.TransactionId).Where(x => x.CustomerId == transaction.CustomerId).FirstOrDefault();
            if (record != null)
            {
                if (transaction.TransactionType != "Commission Charge")
                {
                    if (record.AmountPayable >= transaction.AmountPayable)
                    {
                        var amountToSubtractFrom = record.AmountPayable;
                        var amountToSubstract = transaction.AmountPayable;
                        transaction.AmountPayable = amountToSubtractFrom - amountToSubstract;
                    }
                }

                if (transaction.TransactionType == "Commission Charge")
                {
                    if (record.AmountPayable >= transaction.Commission)
                    {
                        decimal? amountToSubtractFrom = record.AmountPayable;
                        decimal? amountToSubstract = transaction.Commission;
                        transaction.AmountPayable = amountToSubtractFrom - amountToSubstract;
                        var model = new cor_transactions()
                        {
                            CustomerId = transaction.CustomerId,
                            AmountContributed = transaction.AmountContributed,
                            AmountCollected = transaction.AmountCollected,
                            TransactionType = transaction.TransactionType,
                            Date = transaction.Date,
                            Commission = transaction.Commission,
                            AmountPayable = transaction.AmountPayable,
                            Debt = 0m,
                            TotalDebt = 0m,
                            CreatedBy = transaction.CreatedBy,
                            CreatedDate = transaction.CreatedDate
                        };
                        entities.cor_transactions.Add(model);
                        return entities.SaveChanges() > 0;
                    }

                    if (transaction.Commission >= record.AmountPayable)
                    {
                        decimal? diff = transaction.Commission - record.AmountPayable;
                        var model = new cor_transactions()
                        {
                            CustomerId = transaction.CustomerId,
                            AmountContributed = transaction.AmountContributed,
                            AmountCollected = transaction.AmountCollected,
                            TransactionType = transaction.TransactionType,
                            Date = transaction.Date,
                            Commission = transaction.Commission,
                            AmountPayable = transaction.AmountPayable,
                            Debt = record.Debt + diff,
                            TotalDebt = diff + record.TotalDebt,
                            CreatedBy = transaction.CreatedBy,
                            CreatedDate = transaction.CreatedDate
                        };
                        entities.cor_transactions.Add(model);
                        return entities.SaveChanges() > 0;
                    }
                } //For commissions only
            }

            if (transaction.Debt > 0)
            {
                var modelWithDebt = new cor_transactions()
                {
                    CustomerId = transaction.CustomerId,
                    AmountContributed = transaction.AmountContributed,
                    AmountCollected = transaction.AmountCollected,
                    TransactionType = transaction.TransactionType,
                    Date = transaction.Date,
                    Commission = transaction.Commission,
                    AmountPayable = 0m,
                    Debt = transaction.Debt,
                    TotalDebt = transaction.TotalDebt,
                    CreatedBy = transaction.CreatedBy,
                    CreatedDate = transaction.CreatedDate
                };
                entities.cor_transactions.Add(modelWithDebt);
                return entities.SaveChanges() > 0;
            }

            var modelWithoutDebt = new cor_transactions()
            {
                CustomerId = transaction.CustomerId,
                AmountContributed = transaction.AmountContributed,
                AmountCollected = transaction.AmountCollected,
                TransactionType = transaction.TransactionType,
                Date = transaction.Date,
                Debt = 0m,
                TotalDebt = 0m,
                Commission = transaction.Commission,
                AmountPayable = transaction.AmountPayable,
                CreatedBy = transaction.CreatedBy,
                CreatedDate = transaction.CreatedDate
            };
            entities.cor_transactions.Add(modelWithoutDebt);
            return entities.SaveChanges() > 0;
        }

        public Transactions GetTransaction(long transactionId)
        {
            var query = from a in entities.cor_transactions
                        join b in entities.cor_customer on a.CustomerId equals b.CustomerId
                        //join c in entities.cor_sub_admin on a.CreatedBy equals c.Username

                        where a.TransactionId == transactionId
                        select new Transactions()
                        {
                            TransactionId = a.TransactionId,
                            CustomerId = a.CustomerId,
                            CustomerName = b.FullName,
                            //CapturerName = c.FullName,
                            AccountNumber = b.AccountNumber,
                            TransactionType = a.TransactionType,
                            AmountContributed = a.AmountContributed,
                            AmountCollected = a.AmountCollected,
                            Date = a.Date,
                            Commission = a.Commission,
                            AmountPayable = a.AmountPayable,
                            Debt = a.Debt,
                            TotalDebt = a.TotalDebt,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            //UpdatedBy = a.UpdatedBy,
                            //UpdatedDate = a.UpdatedDate
                        };
            return query.FirstOrDefault();
        }

        public IQueryable<Transactions> GetAllTransactions()
        {
            var query = from a in entities.cor_transactions
                        join b in entities.cor_customer on a.CustomerId equals b.CustomerId
                        //join c in entities.cor_sub_admin on a.CreatedBy equals c.Username
                        //join d in entities.cor_super_admin on a.CreatedBy equals d.Username
                        select new Transactions()
                        {
                            TransactionId = a.TransactionId,
                            CustomerId = a.CustomerId,
                            CustomerName = b.FullName,
                            //CapturerName = c.FullName,
                            AccountNumber = b.AccountNumber,
                            TransactionType = a.TransactionType,
                            AmountContributed = a.AmountContributed,
                            AmountCollected = a.AmountCollected,
                            Date = a.Date,
                            Commission = a.Commission,
                            AmountPayable = a.AmountPayable,
                            Debt = a.Debt,
                            TotalDebt = a.TotalDebt,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            //UpdatedBy = a.UpdatedBy,
                            //UpdatedDate = a.UpdatedDate
                        };
            return query.AsQueryable();
        }

        public IQueryable<CreditTransactions> GetCreditTransactions()
        {

            var query = from a in entities.cor_transactions
                        join b in entities.cor_customer on a.CustomerId equals b.CustomerId

                        where a.TransactionType == "Credit"
                        select new CreditTransactions()
                        {
                            TransactionId = a.TransactionId,
                            CustomerId = a.CustomerId,
                            CustomerName = b.FullName,
                            AmountContributed = a.AmountContributed,
                            TransactionType = a.TransactionType,
                            Date = a.Date,
                            //Commission = a.Commission,
                            AmountPayable = a.AmountPayable,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            //UpdatedBy = a.UpdatedBy,
                            //UpdatedDate = a.UpdatedDate
                        };
            return query.AsQueryable();
        }

        public IQueryable<DebitTransactions> GetDebitTransactions()
        {
            var query = from a in entities.cor_transactions
                        join b in entities.cor_customer on a.CustomerId equals b.CustomerId

                        where a.TransactionType == "Debit"
                        select new DebitTransactions()
                        {
                            TransactionId = a.TransactionId,
                            CustomerId = a.CustomerId,
                            CustomerName = b.FullName,
                            AmountCollected = a.AmountCollected,
                            TransactionType = a.TransactionType,
                            Date = a.Date,
                            Commission = a.Commission,
                            AmountPayable = a.AmountPayable,
                            Debt = a.Debt,
                            TotalDebt = a.TotalDebt,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                            //UpdatedBy = a.UpdatedBy,
                            //UpdatedDate = a.UpdatedDate
                        };
            return query.AsQueryable();
        }
    }
}
