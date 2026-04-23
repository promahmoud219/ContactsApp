let modal;
let isModalOpen = false;

export function initModal(selector) {
  modal = document.querySelector(selector);
  if (!modal) return;

  modal.setAttribute("hidden", "");
  isModalOpen = false;

  modal
    .querySelector(".modal__overlay")
    ?.addEventListener("click", closeModal);

  document.addEventListener("keydown", (e) => {
    if (e.key === "Escape") closeModal();
  });
}

export function openModal(content) {
  if (!modal || isModalOpen) return;

  document.body.style.overflow = "hidden";

  const container = modal.querySelector(".modal__content");
  if (!container) return;

  container.replaceChildren(content);

  content.querySelector("input")?.focus();

  modal.removeAttribute("hidden");
  isModalOpen = true;
}

export function closeModal() {
  if (!modal || (!isModalOpen && modal.hasAttribute("hidden"))) return;

  modal.setAttribute("hidden", "");
  document.body.style.overflow = "";

  const container = modal.querySelector(".modal__content");
  container?.replaceChildren();

  isModalOpen = false;
}