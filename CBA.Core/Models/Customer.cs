﻿using CBA.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public int NewCustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public Status Status { get; set; }
        public ICollection<CustomerAccount> CustomerAccount { get; set; }
    }
}
