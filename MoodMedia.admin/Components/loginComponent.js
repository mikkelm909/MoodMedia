app.component("login-component", {
  template: /* html */ `
  <h1 class="display-1 text-center pt-5">MoodMedia Admin Panel</h1>
    <div
      class="
        d-flex
        flex-column
        pt-5
        justify-content-center
        align-items-center
      "
    >
      <form class="w-50">
        <div class="mb-3">
          <label for="usernameLogin" class="form-label">Username</label>
          <input type="text" v-model="username" class="form-control" id="usernameLogin" />
        </div>
        <div class="mb-3">
          <label for="exampleInputPassword1" class="form-label"
            >Password</label
          >
          <input
            type="password"
            class="form-control"
            id="exampleInputPassword1"
            v-model="password"
          />
        </div>
        <button type="button" @click="login" class="btn btn-primary">
          Submit
        </button>
      </form>
      <div v-if="error" class="alert alert-danger" role="alert">
        Invalid username or password!
      </div>
    </div>
    `,
  data() {
    return {
      username: "",
      password: "",
      error: false,
    };
  },
  methods: {
    login() {
      axios
        .post("https://localhost:44367/api/Administrator", {
          username: `${this.username}`,
          password: `${this.password}`,
          id: 0,
        })
        .then((response) => {
          if (response.data) {
            this.$parent.login();
          }
        })
        .catch((error) => {
          this.error = true;
        });
    },
  },
});
