//using CBA.Core.Models;
//using CBA.DAL.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CBA.DAL.Implementations
//{
//    public class GLAccountDAO : IGLAccountDAO
//    {
//        private List<GLAccount> _glAccountList;
//        public GLAccount Add(GLAccount glAcccount)
//        {
//            _glAccountList = new List<GLAccount>()
//            {
//                new GLAccount() { GLAccountID = 1, Code = 1, GLCategory = 1 }
//            };
//        }

//        public IEnumerable<GLAccount> GetAllAccounts(GLAccount account)
//        {
//            account.GLAccountID = _glAccountList.Max(e => e.GLAccountID) + 1;
//            _glAccountList.Add(account);
//            return account;
//        }

//        public IEnumerable<GLAccount> GetAllAccounts()
//        {
//            return _glAccountList;
//        }

//        public GLAccount GetGLAccount(int id)
//        {
//            return _glAccountList.FirstOrDefault(x => x.GLAccountID == id);
//        }

//        public GLAccount Update(GLAccount glAccount)
//        {
//            GLAccount account = _glAccountList.FirstOrDefault(e => e.GLAccountID == accountChanges.GLAccountID);
//            if (account == null)
//            {
//                account.Id = categoryChanges.Id;
//                account.Name = categoryChanges.Name;
//                account.State = categoryChanges.State;
//                account.Description = categoryChanges.Description;
//            }
//            return category;
//        }
//    }
//}
