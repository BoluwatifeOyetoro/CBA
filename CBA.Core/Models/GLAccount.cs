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
        public int GLAccountID { get; set; }
        [Display(Name = "GL Code")]
        public int Code { get; set; }
        [Display(Name = "GL Category")]
        public GLCategory GLCategory { get; set; }
    }
}
