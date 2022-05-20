using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Enums
{
    public class Enums
    {
        public enum PostingType
        {
            Deposit = 1,
            Withdrawal = 2
        }

        public enum LoanStatus
        {
            Paid = 1,
            Unpaid = 2,
            Breeched = 3
        }

        public enum Business
        {
            Open = 1,
            Inbetween = 2,
            Closed = 3
        }
       
        public enum LoanStatusEnum
        {
            UNPAID = 1,
            PAID = 2,
            DEFAULTED = 3
        }
        public enum GenderEnum
        {
            MALE = 1,
            FEMALE = 2
        }
        public enum AccountStatus
        {
            Closed, Open
        }

        public enum TermsOfLoan
        {
            Fixed, Reducing
        }

        public enum AccountType
        {
            Savings, Current, Loan
        }
    }
}
