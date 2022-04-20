app.component("usage-component", {
  template: /* html */ `
    <div class="text-light modal fade modal-dialog-centered" id="usageModal" @click.self="close">
      <div class="modal-dialog modal-xl modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header bg-dark">
            <h4 class="modal-title text-light">Usage Statistics</h4>
          </div>
          <div class="modal-body bg-light text-dark">
            <div class="row">
              <div class="col-md-6 text-dark">
                <label for="fromDateInput" ><b>From: (optional)</b></label>
                <input type="date" class="form-control" id="fromDateInput" v-model="fromDate">
              </div>
              <div class="col-md-6 text-dark">
                <label for="toDateInput"><b>To: (optional)</b></label>
                <input type="date" class="form-control" id="toDateInput" v-model="toDate">
              </div>

              <button class="bg-dark text-light border-0 p-2" @click="getData">Get Data</button>  
            
              <table class="table table-hover table-striped text-dark">
                <thead>
                  <th class="text-center"><b>Id</b></th>
                  <th class="text-center"><b>Spotify ID</b></th>
                  <th class="text-center"><b>Name</b></th>
                  <th class="text-center"><b>Page</b></th>
                  <th class="text-center"><b>Action</b></th>
                  <th class="text-center"><b>Time</b></th>
                </thead>
                <tbody>
                  <tr v-for="data in usageData" class="text-dark" style="border: hidden">
                    <td class="text-center">{{data.id}}</td>
                    <td class="text-center">{{data.userId}}</td>
                    <td class="text-center">{{data.userName}}</td>
                    <td class="text-center">{{data.action.url}}</td>
                    <td class="text-center">{{data.action.button}}</td>
                    <td class="text-center">{{formatDate(data.time)}}</td>
                  </tr>
                </tbody>
              </table>
              
            </div>
          </div>
        </div>
      </div>
    </div>
  `,
  data() {
    return {
      fromDate: "",
      toDate: "",
      usageData: [],
      error: false
    };
  },
  emits: ["closed"],
  methods: {
    formatDate(date) {
      let formattedDate = "";
      formattedDate = new Date(date).toLocaleString("da-DK");
      let tempArray = formattedDate.split(" ");

      tempArray[0] = tempArray[0].replaceAll(".", "/");
      tempArray[1] = tempArray[1].replaceAll(".", ":");
      formattedDate = tempArray.join(" ");
      return formattedDate;
    },
    close() {
      this.$emit("closed")
    },
    async getData() {
      if(this.fromDate == "") this.fromDate = "2010-01-01";
      if(this.toDate == "") this.toDate = "2050-01-01";
      
      let url = "https://localhost:44367/api/Statistics/" + "GetByDates?from=" + this.fromDate + "T00%3A00%3A00.000Z&to=" + this.toDate + "T00%3A00%3A00.000Z";
      let response = await axios.get(url)
      this.usageData = response.data;

      this.fromDate = "";
      this.toDate = "";
    }
  },
  async mounted() {
    let url = "https://localhost:44367/api/Statistics/"
    let response = await axios.get(url)
    this.usageData = response.data;
    $("#usageModal").modal("show")
  },
});


