using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public bool IsActive { get; set; }
        public string? RefreshToken { get; set; }
        public string? Device { get; set; }
    }
}
