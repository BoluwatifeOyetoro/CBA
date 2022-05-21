using CBA.Core.Enums;
using CBA.Core.Models;
using CBA.DAL.Context;
using CBA.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DAL.Implementations
{
    public class GLAccountDAO : IGLAccountDAO
    {
        private readonly AppDbContext context;

        public GLAccountDAO(AppDbContext context)
        {
            this.context = context;
        }
        public GLAccount Delete(long id)
        {
            GLAccount gLAccount = context.GLAccounts.Find(id);
            if (gLAccount != null)
            {
                context.GLAccounts.Remove(gLAccount);
                context.SaveChanges();
            }
            return gLAccount;
        }

        public GLAccount RetrieveById(int id)
        {
            GLAccount gLAccount = context.GLAccounts.Find(id);
            return gLAccount;
        }

        public GLAccount Save(GLAccount gLAccount)
        {
            context.GLAccounts.Add(gLAccount);
            context.SaveChanges();
            return gLAccount;
        }

        public GLAccount GetRoles(GLAccount gLAccount)
        {
            throw new NotImplementedException();
        }

        public GLAccount UpdateGLAccount(GLAccount gLAccountsChanges)
        {
            var gLAccount = context.GLAccounts.Attach(gLAccountsChanges);
            gLAccount.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return gLAccountsChanges;
        }

        public IEnumerable<GLAccount> GetAllGLAccounts()
        {
            var gLAccounts = context.GLAccounts.ToList();
            return gLAccounts;
        }

        public long CreateGlCategoryCode(GLAccount glAccount)
        {
            long newGlCode = 10;
            Categories mainGl = glAccount.Categories;

            var categoryList = context.GLAccounts.ToList().OrderByDescending(c => c.Id);

            if (categoryList.Any())
            {
                var lastGlCode = categoryList.First().AccountCode;
                var stringLastGlCode = lastGlCode.ToString();
                //Get the main GlCode

                int endIndex = stringLastGlCode.Length - 3;
                string mainGlCode = stringLastGlCode.Substring(3, endIndex);

                lastGlCode = Convert.ToInt64(mainGlCode);

                newGlCode = lastGlCode + 10;

            }

            string stringGlCode = newGlCode.ToString();
            long finalGlCode;

            switch (mainGl)
            {
                case Categories.Asset:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.AssetCode + stringGlCode);
                    break;
                case Categories.Capital:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.CapitalCode + stringGlCode);
                    break;
                case Categories.Expense:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.ExpenseCode + stringGlCode);
                    break;
                case Categories.Income:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.IncomeCode + stringGlCode);
                    break;
                case Categories.Liability:
                    finalGlCode = Convert.ToInt64(MainCategoryCodes.LiabilityCode + stringGlCode);
                    break;
                default:
                    finalGlCode = 000;
                    break;
            }

            return finalGlCode;
        }



        public class MainCategoryCodes
        {
            public static string AssetCode = "100";
            public static string LiabilityCode = "200";
            public static string CapitalCode = "300";
            public static string IncomeCode = "400";
            public static string ExpenseCode = "500";
        }
    }
}
