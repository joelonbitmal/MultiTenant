using MultiTenant.Models.Branches;
using MultiTenant.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Models.BranchUsers
{
    public class BranchUser
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public Guid BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}
