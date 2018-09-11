using System.Collections.Generic;

namespace SoftUniClone.Common.Admin.ViewModels
{
    public class UserDetailsViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string FullName { get; set; }

        public string Email { get; set; }

        public IEnumerable<string> Roles { get; set; }
    }
}
