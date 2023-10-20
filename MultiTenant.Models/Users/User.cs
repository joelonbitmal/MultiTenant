
using Microsoft.AspNetCore.Identity;
using MultiTenant.Models.BranchUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MultiTenant.Models.Users
{
    public class User : IdentityUser<Guid>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<BranchUser> BranchUsers { get; set; } = new List<BranchUser>();
    }
}
