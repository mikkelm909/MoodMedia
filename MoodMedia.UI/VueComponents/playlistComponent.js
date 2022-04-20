// JavaScript source code

app.component("playlist-component", {
  template: /*html*/ `
    <div class="text-light modal fade modal-dialog-centered" id="playlistSettingsModel">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header bg-dark">
            <h5 class="modal-title text-light" id="playlistModal">
              Playlist Settings
            </h5>
          </div>
          <div class="modal-body bg-dark">
            <form>
              <label for="snowy">Select a playlist for snowy mood</label>
              <br>
              <select class="w-75" id="snowy" name="playlist" v-model="snow['id']" style="overflow: hidden">
                <option disabled selected>Select a playlist for snowy mood</option>
                <option v-for="playlist in playlists" v-bind:value="playlist.id">{{playlist.name}}</option>
              </select>
            </form>
            <form>
              <label for="rainy">Select a playlist for rainy mood</label>
              <br>
              <select class="w-75" id="rainy" name="playlist" v-model="rain['id']" style="overflow: hidden">
                <option disabled selected>Select a playlist for rainy mood</option>
                <option v-for="playlist in playlists" v-bind:value="playlist.id">{{playlist.name}}</option>
              </select>
            </form>
            <form>
              <label for="freezing">Select a playlist for freezing mood</label>
              <br>
              <select class="w-75" id="freezing" name="playlist" v-model="freezing['id']" style="overflow: hidden">
                <option disabled selected>Select a playlist for freezing mood</option>
                <option v-for="playlist in playlists" v-bind:value="playlist.id">{{playlist.name}}</option>
              </select>
            </form>
            <form>
              <label for="cold">Select a playlist for cold mood</label>
              <br>
              <select class="w-75" id="cold" name="playlist" v-model="cold['id']" style="overflow: hidden">
                <option disabled selected>Select a playlist for cold mood</option>
                <option v-for="playlist in playlists" v-bind:value="playlist.id">{{playlist.name}}</option>
              </select>
            </form>
            <form>
              <label for="nice">Select a playlist for nice mood</label>
              <br>
              <select class="w-75" id="nice" name="playlist" v-model="nice['id']" style="overflow: hidden">
                <option disabled selected>Select a playlist for nice mood}</option>
                <option v-for="playlist in playlists" v-bind:value="playlist.id">{{playlist.name}}</option>
              </select>
            </form>
            <form>
              <label for="sunny">Select a playlist for sunny mood</label>
              <br>
              <select class="w-75" id="sunny" name="playlist" v-model="sunny['id']" style="overflow: hidden">
                <option disabled selected>Select a playlist for sunny mood</option>
                <option v-for="playlist in playlists" v-bind:value="playlist.id">{{playlist.name}}</option>
              </select>
            </form>
            <button class="btn btn-primary" type="button" @click="savePlaylistOptions()">Save</button>
          </div>
        </div>
      </div>
    </div>
    `,
  data() {
    return {
      playlists: [],
      snow: { mood: "snow", id: "" },
      rain: { mood: "rain", id: "" },
      freezing: { mood: "freezing", id: "" },
      cold: { mood: "cold", id: "" },
      nice: { mood: "nice", id: "" },
      sunny: { mood: "sunny", id: "" },
    };
  },
  methods: {
    findPlaylists() {
      const basePlaylistUrl = "https://api.spotify.com/v1/me/playlists";
      axios
        .get(basePlaylistUrl, {
          headers: {
            Authorization: "Bearer " + this.$parent.access_token,
          },
        })
        .then((reponse) => {
          (this.playlists = reponse.data.items),
            console.log(reponse.data.items);
        });
    },
    savePlaylistOptions() {
      const moodPlaylists = [
        this.snow,
        this.rain,
        this.freezing,
        this.cold,
        this.nice,
        this.sunny,
      ];
      this.$emit("activity", window.location.pathname,"save-playlist-options-button");
      this.$emit("setMoodPlaylists", moodPlaylists);
      $(document).ready(function () {
        $("#playlistSettingsModel").modal("hide");
      });
    },
  },
  emits: ["setMoodPlaylists", "activity"],
  mounted() {
    this.findPlaylists();
  },
});
