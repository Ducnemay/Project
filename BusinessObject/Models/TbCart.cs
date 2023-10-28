using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class TbCart
    {
        public int CartId { get; set; }
        public string ProductId { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public decimal Total { get; set; }

        public virtual TbUser User { get; set; } = null!;
    }
}
