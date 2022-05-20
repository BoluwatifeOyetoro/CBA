using CBA.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class GLAccount
    {
        public int GLAccountId { get; set; }
        [Display(Name = "Account Name")]
        public string AccountName { get; set; }

        [Display(Name = "GL Account Code")]
        public long AccountCode { get; set; }
        public virtual Categories Categories { get; set; }

        [Display(Name = "Account Balance")]
        [DataType(DataType.Currency)]
        public double AccountBalance { get; set; }


        public virtual Status? Status{ get; set;}

        public virtual GLCategory GlCategory { get; set; }








    }
}
