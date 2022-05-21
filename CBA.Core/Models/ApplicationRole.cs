using CBA.Core.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CBA.Core.Models
{
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }
        public ApplicationRole(string roleName) : base(roleName) { }

        public ApplicationRole(string roleName, Status? status) : base(roleName)
        {
            this.Status = status;
        }

        public Status? Status { get; set; } 

       // public ApplicationRole(string roleName, string status) : base(roleName)
       // {
       //     this.Status = status;
       // }
        //public string Name { get; set; }
       // public string Status { get; set; }
    }
}
