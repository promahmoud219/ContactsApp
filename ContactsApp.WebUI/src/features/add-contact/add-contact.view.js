export function renderAddContactForm() {
  const form = document.createElement("form");
  form.className = "form";

  form.innerHTML = `
    <h2 class="form__title">Add Contact</h2>

    <div class="form__field">
      <label class="form__label">First Name</label>
      <input class="form__input" type="text" name="firstName" required />
    </div>

    <div class="form__field">
      <label class="form__label">Last Name</label>
      <input class="form__input" type="text" name="lastName" required />
    </div>

    <div class="form__field">
      <label class="form__label">Phone</label>
      <input class="form__input" type="tel" name="phone" />
    </div>

    <div class="form__field">
      <label class="form__label">Email</label>
      <input class="form__input" type="email" name="email" />
    </div>

    <div class="form__field">
      <label class="form__label">Address</label>
      <input class="form__input" type="text" name="address" />
    </div>

    <div class="form__field">
      <label class="form__label">Governorate</label>
      <select class="form__select" name="governorateId" required>
        <option value="" disabled selected>Select governorate</option>
        <option value="1">Cairo</option>
        <option value="2">Giza</option>
        <option value="3">Alexandria</option>
        <option value="4">Kafr El Sheikh</option>
        <option value="5">Sohag</option>
      </select>
    </div>

    <div class="form__actions">
      <button type="button" class="btn btn--secondary btn--cancel">Cancel</button>
      <button type="submit" class="btn btn--primary">Save</button>
    </div>
  `;

  return form;
}