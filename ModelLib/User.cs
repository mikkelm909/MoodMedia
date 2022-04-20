using System;
using System.Collections.Generic;

namespace ModelLib
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string ProfilePhotoURL { get; set; }
        public string SpotifyId { get; set; }
        public IEnumerable<Playlist> MoodPlaylists { get; set; }
        public UserActivity UserActivity { get; set; }

        public User(int id, string name, string address, string email, string profilePhotoURL, string spotifyId, IEnumerable<Playlist> moodPlaylists)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            ProfilePhotoURL = profilePhotoURL;
            SpotifyId = spotifyId;
            MoodPlaylists = moodPlaylists;
            UserActivity = new UserActivity();
        }

        public User(int id, string name, string address, string email, string profilePhotoURL, string spotifyId)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            ProfilePhotoURL = profilePhotoURL;
            SpotifyId = spotifyId;
            UserActivity = new UserActivity();
        }

        public User()
        {
            UserActivity = new UserActivity();
        }

        public User(int id, string name, string address, string email, string profilePhotoURL, string spotifyId, IEnumerable<Playlist> moodPlaylists, UserActivity userActivity)
        {
            Id = id;
            Name = name;
            Address = address;
            Email = email;
            ProfilePhotoURL = profilePhotoURL;
            SpotifyId = spotifyId;
            MoodPlaylists = moodPlaylists;
            UserActivity = userActivity;
            
        }

        public override string ToString()
        {
            return $"{Name} - Id: {Id}\nAdress: {Address}\nE-mail: {Email}\nProfilePhotoURL: {ProfilePhotoURL}";
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   Name == user.Name &&
                   Address == user.Address &&
                   Email == user.Email &&
                   ProfilePhotoURL == user.ProfilePhotoURL &&
                   SpotifyId == user.SpotifyId &&
                   EqualityComparer<IEnumerable<Playlist>>.Default.Equals(MoodPlaylists, user.MoodPlaylists) &&
                   EqualityComparer<UserActivity>.Default.Equals(UserActivity, user.UserActivity);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Name, Address, Email, ProfilePhotoURL, SpotifyId, MoodPlaylists, UserActivity);
        }
    }
}
