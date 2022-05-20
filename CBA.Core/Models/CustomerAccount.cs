using CBA.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CBA.Core.Enums.Enums;

namespace CBA.Core.Models
{
    public class CustomerAccount
    {
        [Key]
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Status Status { get; set; }
    }
}
