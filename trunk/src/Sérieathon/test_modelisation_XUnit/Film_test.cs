using modelisation.content;
using modelisation.genres;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace test_modelisation_XUnit
{
    public class Film_test
    {
        [Fact]
        public void Equals_Test()
        {
            List<GenreGlobal> genres = new List<GenreGlobal>
            {
                GenreGlobal.Fantastique,
                GenreGlobal.Horreur
            };

            List<string> acteurs = new List<string>
            {
                "Baptiste",
                "Come" };

            List<string> acteurs1 = new List<string>
            {
                "Baptiste",
                "Come",
                "Normann"
            };

            Film c = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png", acteurs);

            Film c1 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png", acteurs);

            Film c2 = new Film("film2", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png", acteurs);

            Film c3 = new Film("film1", new DateTime(1988, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png", acteurs);

            Film c4 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(3, 10, 4), "Baptiste F.", genres, "image.png", acteurs);

            Film c5 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste D.", genres, "image.png", acteurs);

            Film c6 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "idage.png", acteurs);

            Film c9 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png", acteurs1);

            genres.Add(GenreGlobal.Action);
            Film c7 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png", acteurs);

            genres.Remove(GenreGlobal.Horreur); genres.Remove(GenreGlobal.Fantastique);
            Film c8 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png", acteurs);

            Assert.True(c.Equals(c1));
            Assert.False(c.Equals(c2) && c.Equals(c3) && c.Equals(c4) && c.Equals(c5) && c.Equals(c6) && c.Equals(c7) && c.Equals(c8) && c.Equals(c9));
        }
    }
}
