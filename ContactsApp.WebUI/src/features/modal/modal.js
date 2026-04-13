let modal;
let isModalOpen = false;

export function initModal(selector) {
  modal = document.querySelector(selector);

  // Ensure modal starts hidden even if the attribute is missing/removed
  modal.setAttribute("hidden", true);
  isModalOpen = false;

  modal.querySelector(".modal__overlay")
    .addEventListener("click", closeModal);

  document.addEventListener("keydown", (e) => {
    if (e.key === "Escape") {
      closeModal();
    }
  });
}

export function openModal(content) {
  if (isModalOpen) return;

  document.body.style.overflow = "hidden";

  const container = modal.querySelector(".modal__content");
  container.innerHTML = "";
  container.appendChild(content);

  modal.querySelector("input")?.focus();
  modal.removeAttribute("hidden");
  isModalOpen = true;
}

export function closeModal() {
  if (!isModalOpen && modal?.hasAttribute("hidden")) return;

  modal.setAttribute("hidden", true);
  document.body.style.overflow = "";

  const container = modal.querySelector(".modal__content");
  if (container) container.innerHTML = "";

  isModalOpen = false;
}
