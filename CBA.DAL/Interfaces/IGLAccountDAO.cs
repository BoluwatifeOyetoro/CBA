using CBA.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.DAL.Interfaces
{
    public interface IGLAccountDAO
    {
        IEnumerable<GLAccount> GetAllAccounts();
        GLAccount GetGLAccount(int id);
        GLAccount Add(GLAccount glAcccount);
        GLAccount Update(GLAccount glAccount);
    }
}
