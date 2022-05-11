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

        public ApplicationRole(string roleName, bool status) : base(roleName)
        {
            this.Status = status;
        }

        public bool Status { get; set; }
    }
}
