using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class TbUser
    {
        public TbUser()
        {
            TbCarts = new HashSet<TbCart>();
        }

        public string UserId { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public DateTime DateOfBird { get; set; }
        public string? Zipcode { get; set; }

        public virtual TbAccount? TbAccount { get; set; }
        public virtual ICollection<TbCart> TbCarts { get; set; }
    }
}
