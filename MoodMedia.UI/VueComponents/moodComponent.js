app.component("mood-component", {
  data() {
    return {
      mood: null,
      weather: null,
      sunny: false,
      nice: false,
      cold: false,
      rain: false,
      snow: false,
      freezing: false,
      debug: true,
    };
  },
  emits: ["activity"],
  methods: {
    setMood(response) {
      this.weather = response;
      this.sunny = false;
      this.nice = false;
      this.cold = false;
      this.rain = false;
      this.snow = false;
      this.freezing = false;
      if (this.debug) console.log(this.weather);

      if (response.temperature < 5) {
        this.mood = "freezing";
        this.freezing = true;
        if (response.humidity >= 80) {
          this.mood += " and snowing";
          this.snow = true;
        }
      } else if (response.temperature < 15) {
        this.mood = "cold";
        this.cold = true;
        if (response.humidity >= 80) {
          this.mood += " and rainy";
          this.rain = true;
        }
      } else if (response.temperature <= 22) {
        this.mood = "nice";
        this.nice = true;
        if (response.humidity >= 80) {
          this.mood += " but rainy";
          this.rain = true;
        }
      } else {
        this.mood = "hot";
        this.sunny = true;
        if (response.humidity >= 80) {
          this.mood += " but rainy";
          this.rain = true;
        }
      }
      if (this.debug) this.printStates();
      this.$emit("activity", window.location.pathname,"mood-button");
    },
    toggleSnow() {
      if (this.snow) this.snow = false;
      else this.snow = true;
      this.printStates();
      this.$parent.currentMood = "snow";
    },
    toggleRain() {
      if (this.rain) this.rain = false;
      else this.rain = true;
      this.printStates();
      this.$parent.currentMood = "rain";
    },
    toggleFreezing() {
      if (this.freezing) this.freezing = false;
      else this.freezing = true;
      this.printStates();
      this.$parent.currentMood = "freezing";
    },
    toggleCold() {
      if (this.cold) this.cold = false;
      else this.cold = true;
      this.printStates();
      this.$parent.currentMood = "cold";
    },
    toggleNice() {
      if (this.nice) this.nice = false;
      else this.nice = true;
      this.printStates();
      this.$parent.currentMood = "nice";
    },
    toggleSunny() {
      if (this.sunny) this.sunny = false;
      else this.sunny = true;
      this.printStates();
      this.$parent.currentMood = "sunny";
    },
    printStates() {
      console.log(
        "Snow: " +
          this.snow +
          " - Rain: " +
          this.rain +
          " | Freezing: " +
          this.freezing +
          " - Cold: " +
          this.cold +
          " - Nice: " +
          this.nice +
          " - Sunny: " +
          this.sunny
      );
    },
  },
  template: /*html*/ `
  <sun-component v-if="sunny"></sun-component>
  <sun-clouds-component v-if="nice"></sun-clouds-component>
  <rain-component v-if="rain"></rain-component>
  <snow-component v-if="snow"></snow-component>
  <freezing-component v-if="freezing"></freezing-component>
  
  <!-- Only shown if debug state is true -->
  <mood-test-buttons v-if="debug" :snow="snow" :rain="rain" :freezing="freezing" :cold="cold" :nice="nice" :sunny="sunny" @toggleSnow="toggleSnow" @toggleRain="toggleRain" @toggleFreezing="toggleFreezing" @toggleCold="toggleCold" @toggleNice="toggleNice" @toggleSunny="toggleSunny"></mood-test-buttons>

  <weather-information-box v-if="weather" v-bind:weather=weather v-bind:mood=mood></weather-information-box>
  <mood-button @getMood="setMood"> </mood-button>
  <br/>
  `,
});

app.component("mood-button", {
  methods: {
    async getMood() {
      var url = baseUrl + "GetLatest";
      var response = (await axios.get(url)).data;
      this.$emit("getMood", response);
    },
  },
  emits: ["getMood"],
  template: /*html*/ `
  <button class="btn btn-primary" @click="getMood">
    Get Mood
  </button>
  `,
});

app.component("weather-information-box", {
  props: {
    weather: "",
    mood: "",
  },
  template: /*html*/ `
    <div class="info-box">
      <div class="info-box-content text-light text-center">
        <h3>Current Weather: {{mood}}</h3>
        <p>Temperature: {{weather.temperature}}</p>
        <p>Humidity: {{weather.humidity}}</p>
      </div>
    </div>
    `,
});

app.component("mood-test-buttons", {
  props: {
    snow: false,
    rain: false,
    freezing: false,
    cold: false,
    nice: false,
    sunny: false,
  },

  template: /*html*/ `
  <div class="buttons-bottom-right justify-content-center align-items-center text-center">
  <p class="text-light">Toggle animations</p>
  <div class="btn-group-vertical text-light flex-wrap w-100">
    <button v-if="snow" class="btn btn-light w-100" @click="toggleSnow">Snow</button>
    <button v-else="snow" class="btn btn-dark w-100" @click="toggleSnow">Snow</button>
    <button v-if="rain" class="btn btn-light w-100" @click="toggleRain">Rain</button>
    <button v-else="rain" class="btn btn-dark w-100" @click="toggleRain">Rain</button>
    <button v-if="freezing" class="btn btn-light w-100" @click="toggleFreezing">Freezing</button>
    <button v-else="freezing" class="btn btn-dark w-100" @click="toggleFreezing">Freezing</button>
    <button v-if="cold" class="btn btn-light w-100" @click="toggleCold">Cold</button>
    <button v-else="cold" class="btn btn-dark w-100" @click="toggleCold">Cold</button>
    <button v-if="nice" class="btn btn-light w-100" @click="toggleNice">Nice</button>
    <button v-else="nice" class="btn btn-dark w-100" @click="toggleNice">Nice</button>
    <button v-if="sunny" class="btn btn-light w-100" @click="toggleSunny">Sunny</button>
    <button v-else="sunny" class="btn btn-dark w-100" @click="toggleSunny">Sunny</button>    
  </div>
</div>
  `,
  methods: {
    toggleSnow() {
      this.$emit("toggleSnow");
    },
    toggleRain() {
      this.$emit("toggleRain");
    },
    toggleFreezing() {
      this.$emit("toggleFreezing");
    },
    toggleCold() {
      this.$emit("toggleCold");
    },
    toggleNice() {
      this.$emit("toggleNice");
    },
    toggleSunny() {
      this.$emit("toggleSunny");
    },
  },
});
