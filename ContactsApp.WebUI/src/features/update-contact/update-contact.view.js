const governorates = [
  { id: 1, name: "Cairo" },
  { id: 2, name: "Giza" },
  { id: 3, name: "Alexandria" },
  { id: 4, name: "Kafr El Sheikh" },
  { id: 5, name: "Sohag" }
];

function buildGovernorateOptions(selectedGovernorateId) {
  const placeholderSelected = selectedGovernorateId == null ? " selected" : "";

  return [
    `<option value="" disabled${placeholderSelected}>Select governorate</option>`,
    ...governorates.map(({ id, name }) => {
      const selected = id === selectedGovernorateId ? " selected" : "";
      return `<option value="${id}"${selected}>${name}</option>`;
    })
  ].join("");
}

export function renderUpdateForm(contact = {}) {
  const {
    id = "",
    firstName = "",
    lastName = "",
    email = "",
    phone = "",
    address = "",
    governorateId = null
  } = contact;

  const form = document.createElement("form");
  form.className = "form";
  form.dataset.id = String(id);

  form.innerHTML = `
    <h2 class="form__title">Update Contact</h2>

    <div class="form__field">
      <label class="form__label">First Name</label>
      <input class="form__input" type="text" name="firstName" value="${firstName}" required />
    </div>

    <div class="form__field">
      <label class="form__label">Last Name</label>
      <input class="form__input" type="text" name="lastName" value="${lastName}" required />
    </div>

    <div class="form__field">
      <label class="form__label">Phone</label>
      <input class="form__input" type="tel" name="phone" value="${phone}" />
    </div>

    <div class="form__field">
      <label class="form__label">Email</label>
      <input class="form__input" type="email" name="email" value="${email}" />
    </div>

    <div class="form__field">
      <label class="form__label">Address</label>
      <input class="form__input" type="text" name="address" value="${address}" />
    </div>

    <div class="form__field">
      <label class="form__label">Governorate</label>
      <select class="form__select" name="governorateId" required>
        ${buildGovernorateOptions(governorateId)}
      </select>
    </div>

    <div class="form__actions">
      <button type="button" class="btn btn--secondary btn--cancel">Cancel</button>
      <button type="submit" class="btn btn--primary">Save Changes</button>
    </div>
  `;

  return form;
}
