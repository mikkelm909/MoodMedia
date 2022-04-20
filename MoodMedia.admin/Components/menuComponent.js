app.component("menu-component", {
  data() {
    return {
      showUsage: false,
      showSensorData: false,
      showGraphs: false,
      showAdminSettings: false,
    }
  },
  template: /* html */ `
  <div class="container">

    <div class="row mt-2 g-4">
      <div class="col-md-4">
        <button-component 
          :buttonText="'Usage Data'" 
          :icon="'./images/icons/people.svg'"
          @clicked="toggleUsage">
        </button-component>
      </div>
      <div class="col-md-4">
        <button-component 
          :buttonText="'Sensor Data'" 
          :icon="'./images/icons/clipboard-data.svg'"
          @clicked="toggleSensorData">
        </button-component>
      </div>
      <div class="col-md-4">
        <button-component 
          :buttonText="'Graphs'" 
          :icon="'./images/icons/graph-up.svg'"
          @clicked="toggleGraphs">
        </button-component>
      </div>
    </div>

    <div class="row mt-2 g-4">
      <div class="col-md-4">
        <button-component 
          :buttonText="'Admin Settings'" 
          :icon="'./images/icons/people.svg'"
          @clicked="toggleAdminSettings">
        </button-component>
      </div>
    </div>
    
  </div> 

  <usage-component 
    v-if="showUsage"
    @closed="closeModals">
  </usage-component>

  <sensordata-component 
    v-if="showSensorData"
    @closed="closeModals">
  </sensordata-component>

  <graphs-component 
    v-if="showGraphs"
    @closed="closeModals">
  </graphs-component>

  <admin-component 
    v-if="showAdminSettings"
    @closed="closeModals">
  </admin-component>
  
  
  `,
  methods: {
    toggleUsage() {
      this.showUsage = true;
    },
    toggleSensorData() {
      this.showSensorData = true;
    },
    toggleGraphs() {
      this.showGraphs = true;
    },
    toggleAdminSettings() {
      this.showAdminSettings = true;
    },
    closeModals() {
      this.showUsage = false;
      this.showSensorData = false;
      this.showGraphs = false;
      this.showAdminSettings = false;
    }
    
  }
});
