using Microsoft.EntityFrameworkCore;
using NET.CORE.Models.DB;
using System;
using System.Linq;

namespace NET.CORE
{
    class Program
    {
        static void Main(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ArtworkContext>();
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Artwork;Trusted_Connection=True;");

            using (var context = new ArtworkContext(optionsBuilder.Options))
            {
                context.Database.EnsureCreated();

                // Query 1 - lista delle opere degli artisti italiani
                var query1 = from m in context.Museums
                             join aw in context.Artworks on m.IdMuseum equals aw.IdMuseum
                             join a in context.Artists on aw.IdArtist equals a.IdArtist
                             join c in context.Characters on aw.IdCharacter equals c.IdCharacter
                             where a.Country == "Italia"
                             select new
                             {
                                 MuseumName = m.MuseumName,
                                 ArtworkName = aw.Name,
                                 CharacterName = c.Name
                             };

                Console.WriteLine("Query 1 Result: ");
                foreach (var item in query1)
                {
                    Console.WriteLine($"Museum: {item.MuseumName}, Artwork Name: {item.ArtworkName}, Character Name: {item.CharacterName}");
                }
                Console.WriteLine("---------------------------------------------------------------------------");

                // Query 2 - lista degli artisti con opere a Parigi
                var query2 = from a in context.Artists
                             join aw in context.Artworks on a.IdArtist equals aw.IdArtist
                             join m in context.Museums on aw.IdMuseum equals m.IdMuseum
                             where m.City == "Parigi"
                             select new
                             {
                                 ArtistName = a.Name,
                                 ArtworkName = aw.Name
                             };

                Console.WriteLine("Query 2 Result: ");
                foreach (var item in query2)
                {
                    Console.WriteLine($"Artist Name: {item.ArtistName}, Artwork Name: {item.ArtworkName}");
                }
                Console.WriteLine("---------------------------------------------------------------------------");

                // Query 3 - citta in cui è conservato il quadro "Flora"
                var query3 = from a in context.Artworks
                             join m in context.Museums on a.IdMuseum equals m.IdMuseum
                             where a.Name == "Flora"
                             select m.City;

                Console.WriteLine("Query 3 Result: ");
                foreach (var item in query3)
                {
                    Console.WriteLine($"City: {item}");
                }
                Console.WriteLine("---------------------------------------------------------------------------");
            }
        }
    }
}