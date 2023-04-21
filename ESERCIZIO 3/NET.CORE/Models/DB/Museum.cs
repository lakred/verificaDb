using System;
using System.Collections.Generic;

namespace NET.CORE.Models.DB;

public partial class Museum
{
    public int IdMuseum { get; set; }

    public string MuseumName { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
}
