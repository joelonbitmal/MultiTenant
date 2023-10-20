using MultiTenant.Models.BranchUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiTenant.Models.Branches
{
    public class Branch
    {
        public Guid Id { get; set; }
        public string BranchName { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<BranchUser> BranchUsers { get; set; } = new List<BranchUser>();
    }
}
