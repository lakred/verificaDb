using System;
using System.Collections.Generic;

namespace NET.CORE.Models.DB;

public partial class Character
{
    public int IdCharacter { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Artwork> Artworks { get; set; } = new List<Artwork>();
}
