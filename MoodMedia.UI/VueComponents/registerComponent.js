app.component("register-component", {
  //   props: {
  //     profileName: {
  //       type: String,
  //     },
  //     profileEmail: {
  //       type: String,
  //     },
  //     profilePicture: {
  //       type: String,
  //     },
  //   },
  template: /*html*/ `
  <div
  class="modal fade"
  id="staticBackdrop"
  data-bs-backdrop="static"
  data-bs-keyboard="false"
  tabindex="-1"
  aria-labelledby="staticBackdropLabel"
>
  <div class="modal-dialog ">
    
    <div class="modal-content bg-dark">
      <div class="modal-header">
        <h5 class="modal-title text-light" id="staticBackdropLabel">
          First time registration
        </h5>
        <button
          type="button"
          class="btn-close btn-close-white"
          data-bs-dismiss="modal"
          aria-label="Close"
        ></button>
      </div>
      <div class="modal-body">
        <form class="row g-3">
        <div class="col-12">
        <input id="profileId" type="hidden" class="form-control" />
          </div>
          <div class="col-12">
            <img
            class="img-fluid w-50 mx-auto d-block rounded-circle"
            src="./images/profile_pic.png"
            alt=""
            srcset=""
            id="profilePicture"
            />
          </div>
          <div class="d-flex justify-content-center align-items-center">
            <button id="spotifyButton" class="btn btn-small">Change Picture</button>
          </div>
          <div class="col-md-6">
            <label for="inputEmail4" class="form-label text-light">Name</label>
            <input id="profileName"  type="text" class="form-control"  placeholder="John Doe..." />
          </div>
          <div class="col-md-6">
            <label for="email" class="form-label text-light">Email</label>
            <input id="profileEmail" type="email" class="form-control"  placeholder="JD@gmail.com" />
          </div>
          <div class="col-12">
            <label for="inputAddress" class="form-label text-light">Address</label>
            <input
              type="text"
              class="form-control"
              
              placeholder="1234 Main St"
            />
          </div>
        </form>
      </div>
      <div class="modal-footer">
        <button
          type="button"
          class="btn btn-secondary"
          data-bs-dismiss="modal"
        >
          Logout
        </button>
        <button type="button" class="btn btn-success">Create</button>
      </div>
    </div>
  </div>
</div>`,
});
