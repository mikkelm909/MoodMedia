app.component("rain-component", {
  template: /*html*/ `
  <div class="back-row-toggle splat-toggle">
    <div class="rain front-row"></div>
    <div class="rain back-row"></div>
  </div>
    `,
  mounted() {
    makeItRain();
  }
});
