using System;
using System.Collections.Generic;

namespace BusinessObject.Models
{
    public partial class TbBirdCategory
    {
        public TbBirdCategory()
        {
            TbBirds = new HashSet<TbBird>();
        }

        public string BirdSpeciesId { get; set; } = null!;
        public string BirdSpeciesName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<TbBird> TbBirds { get; set; }
    }
}
