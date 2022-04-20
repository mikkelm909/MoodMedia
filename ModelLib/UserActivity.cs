using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class UserActivity
    {
        public UserActivity()
        {

        }
        public UserActivity(int id, int listenedSongs, int playlistChanged, int siteVisits)
        {
            Id = id;
            ListenedSongs = listenedSongs;
            PlaylistChanged = playlistChanged;
            SiteVisits = siteVisits;
            User = new User();
        }

        public int Id { get; set; }
        public User User { get; set; }
        public int ListenedSongs { get; set; }
        public int PlaylistChanged { get; set; }
        public int SiteVisits { get; set; }

        public override bool Equals(object obj)
        {
            return obj is UserActivity activity &&
                   Id == activity.Id &&
                   ListenedSongs == activity.ListenedSongs &&
                   PlaylistChanged == activity.PlaylistChanged &&
                   SiteVisits == activity.SiteVisits;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ListenedSongs, PlaylistChanged, SiteVisits);
        }
    }
}
