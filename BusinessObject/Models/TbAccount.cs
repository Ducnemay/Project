using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class TbAccount
    {
        public string UserId { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual TbUser User { get; set; } = null!;
    }
}
