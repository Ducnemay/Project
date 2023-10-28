using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class TbNest
    {
        public string NestId { get; set; } = null!;
        public string BirdIdMale { get; set; } = null!;
        public string BirdIdFemale { get; set; } = null!;
        public string BirdSpecies { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string BirdImage { get; set; } = null!;
        public bool Status { get; set; }

        public virtual TbBird BirdIdFemaleNavigation { get; set; } = null!;
        public virtual TbBird BirdIdMaleNavigation { get; set; } = null!;
    }
}
