import { openModal, closeModal } from "../../components/modal/modal.controller.js";
import { renderDeleteConfirmView } from "./delete-contact.view.js";
import { deleteContact } from "./delete-contact.service.js";
import { initGetAllContacts } from "../get-all-contacts/get-all-contacts.controller.js";


let isBound = false;

export function initDeleteContact() {
  if (isBound) return;

  document.addEventListener("click", async (event) => {
    const button = event.target.closest(".dropdown__item--delete");
    if (!button) return;

    const contactId = Number(button.dataset.id);
    if (!Number.isInteger(contactId) || contactId <= 0) return;

    await handleDeleteClick(contactId);
  });

  isBound = true;
}


async function handleDeleteClick(contactId) {
  const view = renderDeleteConfirmView();

  view.querySelector(".btn--cancel")
    ?.addEventListener("click", closeModal);

  view.querySelector(".btn--confirm")
    ?.addEventListener("click", async () => {
      await handleConfirm(contactId);
    });

  openModal(view);
}


async function handleConfirm(contactId) {
  try {
    await deleteContact(contactId);
    await initGetAllContacts();
    closeModal();

    alert("Contact deleted successfully.");
  } catch (error) {
    console.error("Delete failed", error);
    alert("Something went wrong.");
  }
}