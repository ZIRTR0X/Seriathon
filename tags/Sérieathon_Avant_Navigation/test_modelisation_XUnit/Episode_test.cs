using System;
using Xunit;
using modelisation;
using modelisation.content.episodique;

namespace test_modelisation_XUnit
{
    public class Episode_test
    {
        [Fact]
        public void Contrainte_Constructor_Test()
        {
            Episode a = new Episode(null, -1, new DateTime(1894, 12, 3), new TimeSpan(-6, -3, -3), "toto est là");

            Assert.Equal("Nom inconnu", a.Nom);
            Assert.True(0 == a.NumEpisode);
            Assert.True(new DateTime(1895, 1, 1).Equals(a.Date));
            Assert.True(0 == a.DureeEpisode.Ticks);
        }

        [Fact]
        public void Equals_Test()
        {
            Episode a = new Episode("episode1", 1, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool");
            Object o = new Episode("episode1", 1, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool");
            Episode a2 = new Episode("episode2", 2, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 2 est grave cool");
            Episode a3 = new Episode("episode1", 1, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool");

            Assert.True(a.Equals(a3));
            Assert.True(a.Equals(o));
            Assert.False(a.Equals(a2));
        }


    }
}
