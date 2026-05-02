export function renderDeleteConfirmView() {
  const container = document.createElement("div");

  container.innerHTML = `
    <div class="form">
      <h2 class="form__title">Delete Contact</h2>

      <p class="text--muted">
        Are you sure you want to delete this contact?
      </p>

      <div class="form__actions">
        <button class="btn btn--secondary btn--cancel">Cancel</button>
        <button class="btn btn--primary btn--danger btn--confirm">Delete</button>
      </div>
    </div>
  `;

  return container;
}