app.component("admin-component", {
  template: /*html*/ `
      <div  class="text-light modal fade modal-dialog-centered" id="adminSettingsModel" @click.self="close">
        <div class="modal-dialog modal-dialog-centered">
          <div class="modal-content">
            <div class="modal-header bg-dark">
              <h4 class="modal-title text-light">
                Admin Settings 
              </h4>
            </div>
            <div class="modal-body bg-dark">
              <div class="row">
                <div class="col-sm-6">
                  <h5>
                      Create New Admin 
                  </h5>
                  <form>
                      <label>Admin name: </label>
                      <br>
                      <input type="text" v-model.lazy="adminName"><br><br>
                      <label for="aPassword">Admin password: </label>
                      <br>
                      <input type="text" v-model.lazy="adminPassword"><br><br>
                      <button class="btn btn-primary" type="button" @click="addAdmin()">Confirm</button>
                    </form>
                  </div>
                  <div class="col-sm-6">
                  <h5>
                      Delete Admin
                  </h5>
                  <form>
                    <label>Id: </label>
                    <br>
                    <input type="number" v-model.lazy="idToDelete"><br><br>
                    <br>
                    <br>
                    <br style="line-height: 30px;">
                    <button class="btn btn-primary" type="button" @click="removeAdmin()">Confirm</button>
                  </form>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      `,
  data() {
    return {
      adminSettings: false,
      adminName: "",
      adminPassword: "",
      idToDelete: 0,
      responseText: "",
    };
  },
  emits: ["closed"],
  methods: {
    async addAdmin() {
      const apiUrl = "https://localhost:44367/api/Administrator";
      await axios
        .post(apiUrl, {
          username: this.adminName,
          password: this.adminPassword,
          id: 0,
        })
        .then(function (response) {
          console.log(this.responseText = response.status)
        });
      this.adminName = "";
      this.adminPassword = "";
    },
    async removeAdmin() {
      const apiUrl = `https://localhost:44367/api/Administrator/${this.idToDelete}`;
      await axios
        .delete(apiUrl)
        .then(function (response) {
          console.log(this.responseText = response.status)
        });
      this.idToDelete = 0;
    },
    close() {
      this.$emit("closed")
    }
  },
  mounted() {
    $("#adminSettingsModel").modal("show")
  }
});
