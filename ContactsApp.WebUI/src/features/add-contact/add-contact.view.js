

export function createAddContactView() {
    const form = document.createElement("form");
    form.id = "contact-form";

    form.innerHTML = `
    <h2>Add Contact</h2>
        <div class="form-group">
          <label>First Name</label>
          <input type="text" name="firstName" required />
        </div>
        <div class="form-group">
          <label>Last Name</label>
          <input type="text" name="lastName" required />
        </div>
        <div class="form-group">
          <label>Phone</label>
          <input type="tel" name="phone" />
        </div>
        <div class="form-group">
          <label>Email</label>
          <input type="email" name="email" />
        </div>
        <div class="form-group">
          <label>Address</label>
          <input type="text" name="address" />
        </div>
        <div class="form-group">
          <label>Governorate</label>
          <select name="governorateId" required>
            <option value="" disabled selected>Select governorate</option>
            <option value="1">Cairo</option>
            <option value="2">Giza</option>
            <option value="3">Alexandria</option>
            <option value="4">Kafr El Sheikh</option>
            <option value="5">Sohag</option>
          </select>
        </div>
        <div class="modal__actions">
          <button type="button" id="btn-cancel">Cancel</button>
          <button type="submit" id="btn-primary">Save</button>
        </div>
      `;

    return form;

}
