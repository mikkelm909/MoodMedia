app.component("button-component", {
    data() {
      return {
        
      };
    },
    props: {
      buttonText: "",
      icon: ""
    },
    template: /*html*/`
      <button class="btn-fix card custom-card" @click="toggle">
        <div class="card p-2 w-100">
          <div class="d-flex justify-content-between align-items-center p-2">
            <span class="flex-column 1h-1 imagename">{{buttonText}}</span>
            <img class="flex-column" :src="icon" height="100" width="100"/>
          </div>
        </div>
      </button>
    `,
    methods: {
      toggle() {
        this.$emit("clicked")
      }
    },
    emits: ["clicked"]

  });