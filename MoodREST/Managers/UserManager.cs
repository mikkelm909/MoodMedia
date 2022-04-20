using ModelLib;
using MoodREST.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MoodREST.Managers
{
    public class UserManager : IUserManager
    {

        public static List<User> Users = new List<User>()
        {
            new User(0, "Mikkel", "solrød", "mikk568f@edu.zealand.dk", "B)", "1234", new List<Playlist>() {
                new Playlist("snow", "1HQRFxcNdEoe95AMEdOj9E"),
                new Playlist("rain", "00vHAKl40DCK6bQQZdZobS"),
                new Playlist("freezing", "1Ewdu5hyej4DpbnXemF0Sy"),
                new Playlist("cold", "2pS6BUCSzV0RXUGmKgfPIn"),
                new Playlist("nice","18vbiPv6E5bVLP3A3wkFhN"),
                new Playlist("sunny","27brHmEUn5N9R4Qm1i9kQQ"),
            }, new UserActivity(1, 3, 4, 5)),
            new User(1, "Oscar", "Roskål", "oscar568f@edu.zealand.dk", "B)", "1234", new List<Playlist>() {
                new Playlist("snow", "1HQRFxcNdEoe95AMEdOj9E"),
                new Playlist("rain", "00vHAKl40DCK6bQQZdZobS"),
                new Playlist("freezing", "1Ewdu5hyej4DpbnXemF0Sy"),
                new Playlist("cold", "2pS6BUCSzV0RXUGmKgfPIn"),
                new Playlist("nice","18vbiPv6E5bVLP3A3wkFhN"),
                new Playlist("sunny","27brHmEUn5N9R4Qm1i9kQQ"),
            }, new UserActivity(2, 10, 9, 2)),
            new User(2, "Steven", "Kan ikke huske", "steve568f@edu.zealand.dk", "B)", "1234", new List<Playlist>() {
                new Playlist("snow", "1HQRFxcNdEoe95AMEdOj9E"),
                new Playlist("rain", "00vHAKl40DCK6bQQZdZobS"),
                new Playlist("freezing", "1Ewdu5hyej4DpbnXemF0Sy"),
                new Playlist("cold", "2pS6BUCSzV0RXUGmKgfPIn"),
                new Playlist("nice","18vbiPv6E5bVLP3A3wkFhN"),
                new Playlist("sunny","27brHmEUn5N9R4Qm1i9kQQ"),
            }, new UserActivity(3, 20, 6, 30)),
            new User(3, "Christopher", "Roskål", "chris568f@edu.zealand.dk", "B)", "1234", new List<Playlist>() {
                new Playlist("snow", "1HQRFxcNdEoe95AMEdOj9E"),
                new Playlist("rain", "00vHAKl40DCK6bQQZdZobS"),
                new Playlist("freezing", "1Ewdu5hyej4DpbnXemF0Sy"),
                new Playlist("cold", "2pS6BUCSzV0RXUGmKgfPIn"),
                new Playlist("nice","18vbiPv6E5bVLP3A3wkFhN"),
                new Playlist("sunny","27brHmEUn5N9R4Qm1i9kQQ"),
            }, new UserActivity(4, 2, 4, 5)),
        };
        private static int _nextId = 1;

        public UserManager()
        {
            foreach (var data in Users)
            {
                if (data.Id > _nextId) _nextId = data.Id;
            }
            _nextId++;
        }


        public User Get(int id)
        {
            UserActivity userActivity = new UserActivity(1, 2, 3, 4);
            User foundUser = Users.SingleOrDefault(u => u.Id == id);
            if(foundUser == null)
            {
                throw new KeyNotFoundException($"User with Id: {id} not found");
            }
            return foundUser;
        }
        

        public User GetBySpotifyId(string spotifyId)
        {
            User foundUser = Users.SingleOrDefault(u => u.SpotifyId == spotifyId);
            if (foundUser == null)
            {
                throw new KeyNotFoundException($"User with Spotify Id: {spotifyId} not found");
            }
            return foundUser;
        }

        public List<User> GetAll()
        {
            return Users;
        }

        public IDictionary<string, int> UserActivities() 
        {
            Dictionary<string, int> UserActivities = new();
            UserActivities.Add("ListenedSongs", 0);
            UserActivities.Add("PlaylistChanged", 0);
            UserActivities.Add("SiteVisits", 0);

            foreach (var user in Users)
            {
                UserActivities["ListenedSongs"] += user.UserActivity.ListenedSongs;
                UserActivities["PlaylistChanged"] += user.UserActivity.PlaylistChanged;
                UserActivities["SiteVisits"] += user.UserActivity.SiteVisits;
            }

            return UserActivities;
        }


        public User Post(User user)
        {
            user.Id = _nextId++;
            
            if (user != null)
            {
                var checkUser = Users.Find(u => u.SpotifyId == user.SpotifyId);
                if (checkUser == null)
                {
                    Users.Add(user);
                    user.UserActivity.SiteVisits += 1;
                    return user;
                }
                else {
                        checkUser.UserActivity.SiteVisits += 1;
                        return checkUser;
                     };
            }
            return null;
        }

        public User Remove(int id)
        {
            try
            {
                User RemovedUser = Get(id);
                Users.Remove(Get((id)));
                return RemovedUser;
            }
            catch (KeyNotFoundException knfe)
            {
                throw new KeyNotFoundException(knfe.Message);
            }
        }


        public User Update(int id, User updatedUser)
        {
            if (updatedUser != null)
            {
                var obj = Get(id);
                obj.Id = updatedUser.Id;
                obj.Name = updatedUser.Name;
                obj.SpotifyId = updatedUser.SpotifyId;
                obj.Address = updatedUser.Address;
                obj.Email = updatedUser.Email;
                obj.ProfilePhotoURL = updatedUser.ProfilePhotoURL;
                return obj;
            }
            return null;
        }

        public bool ImportMoodPlaylists(string id, IEnumerable<Playlist> moodPlaylists)
        {
            try
            {
                var user = GetBySpotifyId(id);
                user.UserActivity.PlaylistChanged += 1;
                user.MoodPlaylists = moodPlaylists;
                return true;
            }
            catch (KeyNotFoundException knfe)
            {

                throw new KeyNotFoundException(knfe.Message);
            }
        }
        //Methods from here are used for testing
        public void TestSetup()
        {
            List<User> newList = new List<User>() {
                new User(0, "Mikkel", "solrød", "mikk568f@edu.zealand.dk", "B)", "1234"),
                new User(1, "Oscar", "Roskål", "oscar568f@edu.zealand.dk", "B)", "1234"),
                new User(2, "Steven", "Kan ikke huske", "steve568f@edu.zealand.dk", "B)", "1234"),
                new User(3, "Christopher", "Roskål", "chris568f@edu.zealand.dk", "B)", "1234"),
            };
            Users = newList;
        }
    }
}