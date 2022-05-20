using CBA.Core.Enums;
using CBA.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class GLCategory  
    {
        public int Id { get; set; }
        public  string CategoryName { get; set; }
        public Categories Categories { get; set; }
        public long CategoryCode { get; set; }
        public Status? Status { get; set; }
        public string CategoryDescription { get; set; }
    }
}
