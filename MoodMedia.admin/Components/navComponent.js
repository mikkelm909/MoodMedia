app.component("nav-component", {
  template: /* html */ `<nav class="navbar navbar-expand-md bg-dark navbar-dark w-100 py-4">
    <div class="container-fluid">
      <a class="navbar-brand" href="#"
        ><h1 class="display-6 text-light">
          <span class="text-success">M</span>ood<span class="text-success"
            >M</span
          >edia
        </h1></a
      >
      <button
        class="navbar-toggler"
        type="button"
        data-bs-toggle="collapse"
        data-bs-target="#navmenu"
      >
        <span class="navbar-toggler-icon"></span>
      </button>

      <div class="collapse navbar-collapse" id="navmenu">
        <ul class="navbar-nav me-auto">
          <li class="nav-item">
            <a
              type="button"
              data-bs-toggle="modal"
              data-bs-target="#informationModal"
            >
              <i class="bi bi-question-circle text-white"></i>
            </a>
          </li>
        </ul>
        <div v-if="login">
          <ul class="navbar-nav ms-auto">
            <li class="nav-item">
              <div class="dropstart">
                <button
                  class="btn dropdown-toggle"
                  id="profileSettings"
                  data-bs-toggle="dropdown"
                  aria-expanded="false"
                >
                  <img src="./images/profile_pic.svg" class="avatar" />
                  <img
                    src="images/caret-down-fill.svg"
                    style="width: 15px; height: 15px"
                  />
                </button>
                <ul class="dropdown-menu" aria-labelledby="profileSettings">
                  <li>
                    <a @click="logout()" class="dropdown-item" href="#"
                      >Logout</a
                    >
                  </li>
                </ul>
              </div>
            </li>
          </ul>
        </div>
      </div>
    </div>
  </nav>`,
  props: ["login"],
});
