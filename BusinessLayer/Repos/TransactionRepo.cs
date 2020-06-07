using Ajoor.BusinessLayer.Core;
using Ajoor.BusinessLayer.DTO;
using BusinessLayer.DTO;
using DataLayer.Model;
using EntityFramework.BulkInsert.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ajoor.BusinessLayer.Repos
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
                ExtraCommission = transaction.ExtraCommission,
                AmountPayable = transaction.AmountPayable,
                TotalDebt = transaction.TotalDebt,
                Debt = 0m,
                EOMBalance = 0m,
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
                            ExtraCommission = transaction.ExtraCommission,
                            AmountPayable = transaction.AmountPayable,
                            Debt = 0m,
                            TotalDebt = 0m,
                            EOMBalance = 0m,
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
                            ExtraCommission = transaction.ExtraCommission,
                            AmountPayable = transaction.AmountPayable,
                            Debt = record.Debt + diff,
                            EOMBalance = 0m,
                            TotalDebt = diff + record.TotalDebt,
                            CreatedBy = transaction.CreatedBy,
                            CreatedDate = transaction.CreatedDate
                        };
                        entities.cor_transactions.Add(model);
                        return entities.SaveChanges() > 0;
                    }
                } //For commissions only

                if (transaction.TransactionType == "Extra Commission Charge")
                {
                    if (record.AmountPayable >= transaction.ExtraCommission)
                    {
                        decimal? amountToSubtractFrom = record.AmountPayable;
                        decimal? amountToSubstract = transaction.ExtraCommission;
                        transaction.AmountPayable = amountToSubtractFrom - amountToSubstract;
                        var model = new cor_transactions()
                        {
                            CustomerId = transaction.CustomerId,
                            AmountContributed = transaction.AmountContributed,
                            AmountCollected = transaction.AmountCollected,
                            TransactionType = transaction.TransactionType,
                            Date = transaction.Date,
                            Commission = transaction.Commission,
                            ExtraCommission = transaction.ExtraCommission,
                            AmountPayable = transaction.AmountPayable,
                            Debt = 0m,
                            TotalDebt = 0m,
                            EOMBalance = 0m,
                            CreatedBy = transaction.CreatedBy,
                            CreatedDate = transaction.CreatedDate
                        };
                        entities.cor_transactions.Add(model);
                        return entities.SaveChanges() > 0;
                    }

                    if (transaction.ExtraCommission >= record.AmountPayable)
                    {
                        decimal? diff = transaction.ExtraCommission - record.AmountPayable;
                        var model = new cor_transactions()
                        {
                            CustomerId = transaction.CustomerId,
                            AmountContributed = transaction.AmountContributed,
                            AmountCollected = transaction.AmountCollected,
                            TransactionType = transaction.TransactionType,
                            Date = transaction.Date,
                            Commission = transaction.Commission,
                            ExtraCommission = transaction.ExtraCommission,
                            AmountPayable = transaction.AmountPayable,
                            Debt = record.Debt + diff,
                            TotalDebt = diff + record.TotalDebt,
                            EOMBalance = 0m,
                            CreatedBy = transaction.CreatedBy,
                            CreatedDate = transaction.CreatedDate
                        };
                        entities.cor_transactions.Add(model);
                        return entities.SaveChanges() > 0;
                    }
                } //For extra commissions only
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
                    ExtraCommission = transaction.ExtraCommission,
                    AmountPayable = 0m,
                    Debt = transaction.Debt,
                    EOMBalance = 0m,
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
                ExtraCommission = transaction.ExtraCommission,
                AmountPayable = transaction.AmountPayable,
                EOMBalance = 0m,
                CreatedBy = transaction.CreatedBy,
                CreatedDate = transaction.CreatedDate
            };
            entities.cor_transactions.Add(modelWithoutDebt);
            return entities.SaveChanges() > 0;
        }

        public bool EndOfMonthTransaction(List<EndOfMonthTransactions> transactions)
        {
            List<cor_transactions> listOfTransactions = new List<cor_transactions>();
            foreach (var item in transactions)
            {
                var transaction = new cor_transactions()
                {
                    CustomerId = item.CustomerId,
                    AmountContributed = item.AmountContributed,
                    AmountCollected = item.AmountCollected,
                    TransactionType = item.TransactionType,
                    Date = item.Date,
                    Commission = item.Commission,
                    ExtraCommission = item.ExtraCommission,
                    AmountPayable = item.AmountPayable,
                    Debt = item.Debt,
                    EOMBalance = item.EOMBalance,
                    TotalDebt = item.TotalDebt,
                    CreatedBy = item.CreatedBy,
                    CreatedDate = item.CreatedDate
                };
                listOfTransactions.Add(transaction);
            }
            entities.cor_transactions.AddRange(listOfTransactions);
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
                            ExtraCommission = a.ExtraCommission,
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
                        select new Transactions()
                        {
                            TransactionId = a.TransactionId,
                            CustomerId = a.CustomerId,
                            CustomerName = b.FullName,
                            AccountNumber = b.AccountNumber,
                            TransactionType = a.TransactionType,
                            AmountContributed = a.AmountContributed,
                            AmountCollected = a.AmountCollected,
                            Date = a.Date,
                            Commission = a.Commission,
                            ExtraCommission = a.ExtraCommission,
                            AmountPayable = a.AmountPayable,
                            Debt = a.Debt,
                            EOMBalance = a.EOMBalance,
                            TotalDebt = a.TotalDebt,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
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
                            AmountPayable = a.AmountPayable,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate
                        };
            return query.AsQueryable();
        }

        public IQueryable<EndOfMonthTransactions> GetEndOfMonthTransactions()
        {
            var query = from a in entities.cor_transactions
                        join b in entities.cor_customer on a.CustomerId equals b.CustomerId

                        where a.TransactionType == "End Of Month"
                        select new EndOfMonthTransactions()
                        {
                            TransactionId = a.TransactionId,
                            CustomerId = a.CustomerId,
                            CustomerName = b.FullName,
                            TransactionType = a.TransactionType,
                            Date = a.Date,
                            EOMBalance = a.EOMBalance,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate
                        };
            return query.AsQueryable();
        }

        public IQueryable<DebitTransactions> GetDebitTransactions()
        {
            var query = from a in entities.cor_transactions
                        join b in entities.cor_customer on a.CustomerId equals b.CustomerId

                        where a.TransactionType == "Debit" || a.TransactionType == "Commission Charge" || a.TransactionType == "Extra Commission Charge"
                        select new DebitTransactions()
                        {
                            TransactionId = a.TransactionId,
                            CustomerId = a.CustomerId,
                            CustomerName = b.FullName,
                            AmountCollected = a.AmountCollected,
                            TransactionType = a.TransactionType,
                            Date = a.Date,
                            Commission = a.Commission,
                            ExtraCommission = a.ExtraCommission,
                            AmountPayable = a.AmountPayable,
                            Debt = a.Debt,
                            TotalDebt = a.TotalDebt,
                            CreatedBy = a.CreatedBy,
                            CreatedDate = a.CreatedDate,
                        };
            return query.AsQueryable();
        }

        public bool CloseMonthOperation()
        {
            var records = GetAllTransactions().GroupBy(p => p.CustomerId).Select(g => new
            {
                CustomerID = g.FirstOrDefault().CustomerId,
                TotalCredit = g.OrderByDescending(s => s.TransactionId).FirstOrDefault().AmountPayable > 0 ? g.OrderByDescending(s => s.TransactionId).FirstOrDefault().AmountPayable : 0,
                TotalDebt = g.OrderByDescending(s => s.TransactionId).FirstOrDefault().TotalDebt > 0 ? g.OrderByDescending(s => s.TransactionId).FirstOrDefault().TotalDebt : 0,
            }).ToList();
            List<EndOfMonthTransactions> eomTransactions = new List<EndOfMonthTransactions>();
            foreach (var record in records)
            {
                EndOfMonthTransactions transaction = new EndOfMonthTransactions()
                {
                    CustomerId = record.CustomerID,
                    AmountContributed = 0m,
                    AmountCollected = 0m,
                    TransactionType = "End Of Month",
                    Date = DateTime.Now,
                    Commission = 0m,
                    ExtraCommission = 0m,
                    AmountPayable = 0m,
                    Debt = 0m,
                    TotalDebt = 0m,
                    EOMBalance = record.TotalCredit == 0 ? -1 * record.TotalDebt : record.TotalCredit,
                    CreatedBy = Utilities.USERNAME,
                    CreatedDate = DateTime.Now
                };
                if (transaction.EOMBalance.ToString().Contains("-"))
                {
                    transaction.TotalDebt = transaction.EOMBalance * -1;
                }
                else
                {
                    transaction.AmountPayable = transaction.EOMBalance;
                }
                eomTransactions.Add(transaction);
            }
            return EndOfMonthTransaction(eomTransactions);
        }

        public bool ClosePreviousMonthOperation()
        {
            var records = GetAllTransactions().GroupBy(p => p.CustomerId).Select(g => new
            {
                CustomerID = g.FirstOrDefault().CustomerId,
                TotalCredit = g.OrderByDescending(s => s.TransactionId).FirstOrDefault().AmountPayable > 0 ? g.OrderByDescending(s => s.TransactionId).FirstOrDefault().AmountPayable : 0,
                TotalDebt = g.OrderByDescending(s => s.TransactionId).FirstOrDefault().TotalDebt > 0 ? g.OrderByDescending(s => s.TransactionId).FirstOrDefault().TotalDebt : 0,
            }).ToList();
            List<EndOfMonthTransactions> eomTransactions = new List<EndOfMonthTransactions>();
            var date = DateTime.Parse(Utilities.GetLastDateOfPreviousMonth());
            foreach (var record in records)
            {
                EndOfMonthTransactions transaction = new EndOfMonthTransactions()
                {
                    CustomerId = record.CustomerID,
                    AmountContributed = 0m,
                    AmountCollected = 0m,
                    TransactionType = "End Of Month",
                    Date = date,
                    Commission = 0m,
                    ExtraCommission = 0m,
                    AmountPayable = 0m,
                    Debt = 0m,
                    TotalDebt = 0m,
                    EOMBalance = record.TotalCredit == 0 ? -1 * record.TotalDebt : record.TotalCredit,
                    CreatedBy = Utilities.USERNAME,
                    CreatedDate = date
                };
                if (transaction.EOMBalance.ToString().Contains("-"))
                {
                    transaction.TotalDebt = transaction.EOMBalance * -1;
                }
                else
                {
                    transaction.AmountPayable = transaction.EOMBalance;
                }
                eomTransactions.Add(transaction);
            }
            return EndOfMonthTransaction(eomTransactions);
        }

        public bool HasMonthBeenClosed(int month)
        {
            month = month == 0 ? 12 : month;
            int year = DateTime.Now.Year;
            var eoms = GetEndOfMonthTransactions().Where(x => x.CreatedDate.Value.Month == month && x.CreatedDate.Value.Year == year).ToList();
            if (eoms.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
