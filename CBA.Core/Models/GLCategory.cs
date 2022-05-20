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
        public int GLCategoryId { get; set; }
        public virtual string CategoryName { get; set; }
        public virtual Categories Categories { get; set; }
        public long CategoryCode { get; set; }
        public virtual Status? Status { get; set; }
        public virtual string CategoryDescription { get; set; }
    }
}
