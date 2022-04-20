using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class Playlist
    {
        public string Mood { get; set; }
        public string Id { get; set; }
        public Playlist()
        {

        }

        public Playlist(string mood, string id)
        {
            Mood = mood;
            Id = id;
        }
    }
}
