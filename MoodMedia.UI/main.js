const baseUrl = "https://localhost:44367/api/Sensor/";

const app = Vue.createApp({
  data() {
    return {
      currentMood: "",
      users: Seed.users,
      rain: true,
      login: false,
      playlistSettings: false,
      client_id: "8c68d039b2544b31a1064152fbb24c51",
      stateKey: "spotify_auth_state",
      currentSpotifyUser: null,
      user: null,
      currentUser: null,
      moodPlaylists: [
        {
          mood: "snow",
          id: "1HQRFxcNdEoe95AMEdOj9E",
        },
        {
          mood: "rain",
          id: "00vHAKl40DCK6bQQZdZobS",
        },
        {
          mood: "freezing",
          id: "1Ewdu5hyej4DpbnXemF0Sy",
        },
        {
          mood: "cold",
          id: "2pS6BUCSzV0RXUGmKgfPIn",
        },
        {
          mood: "nice",
          id: "18vbiPv6E5bVLP3A3wkFhN",
        },
        {
          mood: "sunny",
          id: "27brHmEUn5N9R4Qm1i9kQQ",
        },
      ],
      currentPlaylist: [],
      player: null,
      deviceId: "",
      userId: "",
    };
  },
  methods: {
    RecordActivity(url, button) {
      axios.post("https://localhost:44367/api/Statistics/", {
        id: 0,
        userId: this.currentSpotifyUser.id,
        userName: this.currentSpotifyUser.display_name,
        action: {
          url: url,
          button: button,
          time: "2000-01-01T00:00:00.127Z",
        },
      });
    },
    logout() {
      this.login = false;
      localStorage.removeItem(this.stateKey);
    },
    async getCurrentUser() {
      await axios
        .get(
          `https://localhost:44367/api/User/GetBySpotifyId/${this.currentSpotifyUser.id}`
        )
        .then((response) => (this.currentUser = response.data));
    },
    setMoodPlaylists(moodPlaylists) {
      // const apiUrl = "https://localhost:44367/api/User/MoodPlaylists/";
      // apiUrl = +this.userId;
      // console.log(this.currentSpotifyUser);
      this.moodPlaylists = moodPlaylists;
      fetch(
        `https://localhost:44367/api/User/MoodPlaylists/${this.currentSpotifyUser.id}`,
        {
          method: "PUT",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(moodPlaylists),
        }
      )
        .then((response) => console.log(response))
        .catch((error) => console.log(error));
    },
    getPlaylistSettings() {
      this.playlistSettings = true;
      this.togglePlaylistSettingsModal();
    },
    async spotifyAuthentication() {
      // Setup parameters for URL
      let client_id = "8c68d039b2544b31a1064152fbb24c51";
      let redirect_uri = "http://127.0.0.1:5501/MoodMedia.UI/index.html";

      let state = generateRandomString(16);
      localStorage.setItem(this.stateKey, state);

      let scope =
        "user-read-private user-read-email playlist-modify-private playlist-read-private";
      // Generate the url
      var url = "https://accounts.spotify.com/authorize";
      url += "?response_type=token";
      url += "&client_id=" + encodeURIComponent(client_id);
      url += "&scope=" + encodeURIComponent(scope);
      url += "&redirect_uri=" + encodeURIComponent(redirect_uri);
      url += "&state=" + encodeURIComponent(state);
      window.location = url;
      this.login = true;
    },
    async getCurrentSpotifyUser() {
      let currentSpotifyUserUrl = "https://api.spotify.com/v1/me";
      await axios
        .get(currentSpotifyUserUrl, {
          headers: {
            Authorization: "Bearer " + this.access_token,
          },
        })
        .then((response) =>
          console.log((this.currentSpotifyUser = response.data))
        );
      await this.createUserFromSpotifyUser();
      await this.getCurrentUser();
    },
    async createUserFromSpotifyUser() {
      console.log("hej");
      await axios.post("https://localhost:44367/api/User/", {
        name: this.currentSpotifyUser.display_name,
        address: this.currentSpotifyUser.country,
        email: this.currentSpotifyUser.email,
        profilePhotoUrl: this.currentSpotifyUser.images[0].url,
        spotifyId: this.currentSpotifyUser.id,
        userActivity: this.currentSpotifyUser.userActivity,
        moodPlaylists: this.moodPlaylists,
      });
    },
    doesUserExist(data) {
      const tempUsers = JSON.parse(JSON.stringify(this.users));
      return tempUsers.some((u) => u.spotifyId === data.id);
    },
    toggleRegistrationModal() {
      $(document).ready(function () {
        $("#registationModel").modal("show");
      });
    },
    togglePlaylistSettingsModal() {
      $(document).ready(function () {
        $("#playlistSettingsModel").modal("show");
      });
    },
    doesUserExist() {
      const tempUsers = JSON.parse(JSON.stringify(this.users));
      return tempUsers.some((u) => u.spotifyId === this.user.id);
    },
    toggleRegistrationModal() {
      $(document).ready(function () {
        $("#registationModel").modal("show");
      });
    },
    togglePlaylistSettingsModal() {
      $(document).ready(function () {
        $("#playlistSettingsModel").modal("show");
      });
    },

    async getSong() {
      let playlist = null;
      let playlists = JSON.parse(JSON.stringify(this.moodPlaylists));
      // console.log(playlists);
      const playlistId = playlists.find(
        (playlist) => playlist.mood == this.songMood
      );
      console.log(playlistId.id);
      let url = `https://api.spotify.com/v1/playlists/${playlistId.id}/tracks`;
      await axios
        .get(url, {
          headers: {
            Authorization: "Bearer " + this.access_token,
          },
        })
        .then((response) => (this.currentPlaylist = response));
      // console.log(this.currentPlaylist.data.items);
      let song = this.currentPlaylist.data.items[0];
      // console.log(song.track.uri);

      return song.track.uri;
    },
    playMusic() {
      this.RecordActivity(window.location.pathname, "play-music-button");
      this.initiatePlayer();
    },
    waitForSpotifyWebPlaybackSDKToLoad: async function () {
      return new Promise((resolve) => {
        if (window.Spotify) {
          resolve(window.Spotify);
        } else {
          window.onSpotifyWebPlaybackSDKReady = () => {
            resolve(window.Spotify);
          };
        }
      });
    },
    initiatePlayer: async function () {
      const token = this.access_token;
      let song = await this.getSong();
      const { Player } = await this.waitForSpotifyWebPlaybackSDKToLoad();
      let sdk = new Player({
        name: "Web Playback SDK Quick Start Player",
        getOAuthToken: (cb) => {
          cb(token);
        },
        volume: 0.5,
      });

      sdk.addListener("ready", ({ device_id }) => {
        this.deviceId = device_id;
        // console.log("Ready with Device ID", device_id);
        const play = ({
          spotify_uri,
          playerInstance: {
            _options: { getOAuthToken },
          },
        }) => {
          getOAuthToken((access_token) => {
            fetch(
              `https://api.spotify.com/v1/me/player/play?device_id=${this.deviceId}`,
              {
                method: "PUT",
                body: JSON.stringify({ uris: [spotify_uri] }),
                headers: {
                  "Content-Type": "application/json",
                  Authorization: `Bearer ${access_token}`,
                },
              }
            );
          });
        };

        play({
          playerInstance: sdk,
          spotify_uri: `${song}`,
        });
      });
      // this.player.togglePlay();
      sdk.connect();
    },
    back() {
      this.RecordActivity(window.location.pathname, "music-player-back-button");
    },
    forward() {
      this.RecordActivity(
        window.location.pathname,
        "music-player-forward-button"
      );
    },
  },
  computed: {
    songMood() {
      // console.log(`This is the currentMood: ${this.currentMood}`);
      return this.currentMood;
    },
  },
  async mounted() {
    var params = getHashParams();
    (this.access_token = params.access_token),
      (state = params.state),
      (storedState = localStorage.getItem(this.stateKey));
    if (this.access_token && (state == null || state !== storedState)) {
      alert("There was an error during the authentication");
    } else {
      if (this.access_token) {
        this.login = true;
        axios
          .get("https://api.spotify.com/v1/me", {
            headers: {
              Authorization: "Bearer " + this.access_token,
            },
          })
          .then((reponse) => console.log(reponse.data))
          .catch((error) => console.log(error));
      }
    }
    window.onSpotifyWebPlaybackSDKReady = () => {};
    await this.getCurrentSpotifyUser();
    console.log(this.currentSpotifyUser);
    console.log(this.currentUser);
    this.moodPlaylists = this.currentUser.moodPlaylists;
  },
});

/** Helper Functions */

/**
 * Used to generate a random ID to store the access token.
 * @param {*} length
 * @returns string
 */
function generateRandomString(length) {
  var text = "";
  var possible =
    "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

  for (var i = 0; i < length; i++) {
    text += possible.charAt(Math.floor(Math.random() * possible.length));
  }
  return text;
}

/**
 * Used to seperate the url in the navigation bar.
 * This seperates into a access_token and a state array
 */
function getHashParams() {
  var hashParams = {};
  var e,
    r = /([^&;=]+)=?([^&;]*)/g,
    q = window.location.hash.substring(1);
  while ((e = r.exec(q))) {
    hashParams[e[1]] = decodeURIComponent(e[2]);
  }
  return hashParams;
}
