app.component("registration-component", {
  template: /* html*/ `<div
    class="modal fade"
    data-bs-backdrop="static"
    data-bs-keyboard="false"
    id="registationModel"
    tabindex="-1"
    aria-labelledby="informationModal"
    aria-hidden="true"
  >
    <div class="modal-dialog modal-dialog-centered">
      <div class="modal-content">
        <div class="modal-header bg-dark">
          <h5 class="modal-title text-light" id="informationModal">
            Registration
          </h5>
          <button
            type="button"
            class="btn-close btn-close-white"
            data-bs-dismiss="modal"
            aria-label="Close"
          ></button>
        </div>
        <div class="modal-body bg-dark">
        <div class="col-12">  
          <p v-if="errors.length">
            <b class="text-light">Please correct the following error(s):</b>
            <ul>
              <li class="text-light" v-for="error in errors">{{ error }}</li>
            </ul>
          </p>
        </div>
          <form class="row g-3" @submit="submitUser">
          <div class="col-12">
            <input id="profileId" type="hidden" v-model.lazy="id"/>      
          </div>
          <div class="col-12">
            <img class="img-fluid w-50 d-block rounded-circle mx-auto" v-bind:src="picture" id="profilePicture"/>
            <input type="hidden" id="profilePicture" v-model.lazy="picture"/>
          </div>
            <div class="col-md-6">
              <label for="profileEmail" class="form-label text-light">Email</label>
              <input type="email" class="form-control" id="profileEmail" v-model.lazy="email">
            </div>
            <div class="col-md-6">
              <label for="profileName" class="form-label text-light">Name</label>
              <input type="text" class="form-control" id="profileName" v-model.lazy="username">
            </div>
            <div class="col-12">
              <label for="profileAddress" class="form-label text-light">Address</label>
              <input type="text" class="form-control" id="profileAddress" placeholder="1234 Main St" v-model.lazy="address">
            </div>
            <div class="col-12">
              <button class="btn btn-success" type="submit" value="Submit">
                Create
              </button>
            </div>
          </form>
        </div>
      </div>
    </div>
  </div>`,
  props: ["id", "username", "email", "picture"],
  data() {
    return {
      errors: [],
      address: null,
    };
  },

  methods: {
    submitUser: function (e) {
      // this.spotifyId = this.username;
      let user = {
        id: 4,
        spotifyId: this.id,
        name: this.username,
        email: this.email,
        address: this.address,
        profilePhotoURL: this.picture,
      };
      console.log(JSON.stringify(user));
      if (
        this.username &&
        this.email &&
        this.id &&
        this.address &&
        this.picture
      ) {
        const response = fetch("https://localhost:44367/api/User/", {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(user),
        }).then($("#registationModel").modal("hide"));
      }

      this.errors = []; // Make suren no boo boo from last time

      if (!this.username) {
        // Is there any value in there?
        this.errors.push("Name required");
      }

      if (!this.email) {
        // Is there any value in there?
        this.errors.push("Email required");
      }

      if (!this.address) {
        // Is there any value in there?
        this.errors.push("Address required");
      }
      console.log("End of method");
      e.preventDefault();
    },
  },
  created() {
    // Create a api call to figure out if user exists already, this is the way
  },
});
