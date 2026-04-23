export function createAddContactView() {
  const form = document.createElement("form");
  form.className = "modal__form";

  form.innerHTML = `
    <h2 class="modal__title">Add Contact</h2>

    <div class="modal__field">
      <label class="modal__label">First Name</label>
      <input class="modal__input" type="text" name="firstName" required />
    </div>

    <div class="modal__field">
      <label class="modal__label">Last Name</label>
      <input class="modal__input" type="text" name="lastName" required />
    </div>

    <div class="modal__field">
      <label class="modal__label">Phone</label>
      <input class="modal__input" type="tel" name="phone" />
    </div>

    <div class="modal__field">
      <label class="modal__label">Email</label>
      <input class="modal__input" type="email" name="email" />
    </div>

    <div class="modal__field">
      <label class="modal__label">Address</label>
      <input class="modal__input" type="text" name="address" />
    </div>

    <div class="modal__field">
      <label class="modal__label">Governorate</label>
      <select class="modal__select" name="governorateId" required>
        <option value="" disabled selected>Select governorate</option>
        <option value="1">Cairo</option>
        <option value="2">Giza</option>
        <option value="3">Alexandria</option>
        <option value="4">Kafr El Sheikh</option>
        <option value="5">Sohag</option>
      </select>
    </div>

    <div class="modal__actions">
      <button type="button" class="btn btn--secondary modal__cancel-btn">Cancel</button>
      <button type="submit" class="btn btn--primary">Save</button>
    </div>
  `;

  return form;
}