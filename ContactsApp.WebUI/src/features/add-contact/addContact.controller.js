import { openModal, closeModal } from "../modal/modal.js";
import { createAddContactView } from "./addContact.view.js";
import { createContact } from "./addContact.service.js";

export function initAddContact() {
  const btn = document.getElementById("btn-add-contact");
  btn.addEventListener("click", handleOpen);
}

function handleOpen() {
  const form = createAddContactView();

  form.addEventListener("submit", handleSubmit);
  form.querySelector("#btn-cancel")
      .addEventListener("click", closeModal);

  openModal(form);
}

async function handleSubmit(e) {
  e.preventDefault();

  const formData = new FormData(e.target);

  const contact = {
    firstName: formData.get("firstName"),
    lastName: formData.get("lastName"),
    email: formData.get("email"),
    phone: formData.get("phone"),
    address: formData.get("address"),
    governorate: formData.get("country")
  };

  try {
    await createContact(contact);

    closeModal();

    // update state + re-render -> later when we have state management

  } catch (err) {
    console.error(err);
  }
}