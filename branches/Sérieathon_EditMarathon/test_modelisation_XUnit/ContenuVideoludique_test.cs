using System;
using System.Collections.Generic;
using System.Text;
using modelisation.content;
using modelisation.genres;
using Xunit;
using static modelisation.genres.GenreGlobal;

namespace test_modelisation_XUnit
{
    public class ContenuVideoludique_test
    {
        [Fact]
        public void Equals_Test()
        {
            List<GenreGlobal> genres = new List<GenreGlobal>
            {
                GenreGlobal.Fantastique,
                GenreGlobal.Horreur
            };

            ContenuVideoludique c = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png");

            ContenuVideoludique c1 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png");

            ContenuVideoludique c2 = new Film("film2", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png");

            ContenuVideoludique c3 = new Film("film1", new DateTime(1988, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png");

            ContenuVideoludique c4 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(3, 10, 4), "Baptiste F.", genres, "image.png");

            ContenuVideoludique c5 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste D.", genres, "image.png");

            ContenuVideoludique c6 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "idage.png");

            genres.Add(GenreGlobal.Action);
            ContenuVideoludique c7 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png");

            genres.Remove(GenreGlobal.Horreur); genres.Remove(GenreGlobal.Fantastique);
            ContenuVideoludique c8 = new Film("film1", new DateTime(1987, 6, 1), new TimeSpan(2, 10, 4), "Baptiste F.", genres, "image.png");

            Assert.True(c.Equals(c1));
            Assert.False(c.Equals(c2) && c.Equals(c3) && c.Equals(c4) && c.Equals(c5) && c.Equals(c6) && c.Equals(c7) && c.Equals(c8));
        }
    }
}
