using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Beer
    {
        public int BeerId { get; set; }
        public string Name { get; set; } = null!;
        public int? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
    }
}
