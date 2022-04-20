using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModelLib;

namespace MoodREST.Interfaces
{
    interface IUserManager
    {
        List<User> GetAll();
        User Get(int id);
        User GetBySpotifyId(string spotifyId);
        User Update(int id, User user);
        User Post(User user);
        User Remove(int id);
        bool ImportMoodPlaylists(string id, IEnumerable<Playlist> moodPlaylists);
        IDictionary<string, int> UserActivities();
    }
}
