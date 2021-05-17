using System;
using System.Collections.Generic;
using System.Text;
using modelisation.content.episodique;
using Xunit;

namespace test_modelisation_XUnit
{
    public class Saison_test
    {
        [Fact]
        public void Contrainte_Constructor_Test()
        {
            LinkedList<Episode> episodes = new LinkedList<Episode>();
            episodes.AddLast(new Episode("episode1", 1, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool"));
            episodes.AddLast(new Episode("episode1", 1, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool"));

            Saison s = new Saison(-5, episodes);
            Saison s2 = new Saison(7);

            Assert.True(0 == s.NumSaison);
            Assert.True(episodes.Count == s.GetNbEpisode());
            Assert.True(s2.NumSaison == 7 && s2.ListEpisodes.Count == 0);
        }

        [Fact]
        public void Equals_Test()
        {
            LinkedList<Episode> episodes = new LinkedList<Episode>();
            episodes.AddLast(new Episode("episode1", 1, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool"));
            episodes.AddLast(new Episode("episode1", 1, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool"));

            Saison s = new Saison(-5, episodes);


            LinkedList<Episode> episodes2 = new LinkedList<Episode>();
            episodes2.AddLast(new Episode("episode1", 1, new DateTime(2000, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool"));
            episodes2.AddLast(new Episode("episode2", 2, new DateTime(2008, 4, 24), new TimeSpan(1, 20, 2), "episode 2 est sympa"));
            episodes2.AddLast(new Episode("episode3", 3, new DateTime(2003, 6, 7), new TimeSpan(3, 4, 2), "episode 3 est long"));

            Saison s2 = new Saison(-5, episodes2);

            LinkedList<Episode> episodes3 = new LinkedList<Episode>();
            episodes3.AddLast(new Episode("episode1", 1, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool"));
            episodes3.AddLast(new Episode("episode1", 1, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool"));

            object s3 = new Saison(-5, episodes3);

            LinkedList<Episode> episodes4 = new LinkedList<Episode>();
            episodes4.AddLast(new Episode("episode1", 1, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool"));
            episodes4.AddLast(new Episode("episode1", 1, new DateTime(1980, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool"));

            Saison s4 = new Saison(6, episodes4);

            Assert.False(s.Equals(s2));
            Assert.False(s2.Equals(s)); // comment ça marche??? c'est pas censé :'(
            Assert.True(s.Equals(s3));
            Assert.False(s.Equals(s4));

        }

        [Fact]
        public void Duree_Dates_Test()
        {
            LinkedList<Episode> episodes = new LinkedList<Episode>();
            episodes.AddLast(new Episode("episode1", 1, new DateTime(2000, 12, 23), new TimeSpan(2, 40, 5), "episode 1 est grave cool"));
            episodes.AddLast(new Episode("episode2", 2, new DateTime(2008, 4, 24), new TimeSpan(1, 20, 2), "episode 2 est sympa"));
            episodes.AddLast(new Episode("episode3", 3, new DateTime(2003, 6, 7), new TimeSpan(3, 4, 2), "episode 3 est long"));

            Saison s = new Saison(-5, episodes);

            Assert.True((new TimeSpan(2, 40, 5) + new TimeSpan(1, 20, 2) + new TimeSpan(3, 4, 2)).Equals(s.GetDuree()));
            Assert.True(new DateTime(2000, 12, 23).Equals(s.GetDateDebut()));
            Assert.True(new DateTime(2008, 4, 24).Equals(s.GetDateFin()));
        }

    }
}
