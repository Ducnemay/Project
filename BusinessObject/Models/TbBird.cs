using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class TbBird
    {
        public TbBird()
        {
            TbNestBirdIdFemaleNavigations = new HashSet<TbNest>();
            TbNestBirdIdMaleNavigations = new HashSet<TbNest>();
        }

        public string BirdId { get; set; } = null!;
        public string BirdSpeciesId { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public DateTime BirthMonthYear { get; set; }
        public string? Description { get; set; }
        public string BirdImage { get; set; } = null!;
        public decimal Price { get; set; }
        public bool OffspringAvailable { get; set; }
        public bool StatusSold { get; set; }

        public virtual TbBirdCategory BirdSpecies { get; set; } = null!;
        public virtual ICollection<TbNest> TbNestBirdIdFemaleNavigations { get; set; }
        public virtual ICollection<TbNest> TbNestBirdIdMaleNavigations { get; set; }
    }
}
