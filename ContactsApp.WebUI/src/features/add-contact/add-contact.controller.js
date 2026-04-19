import { openModal, closeModal } from "../modal/modal.js";
import { createAddContactView } from "./add-contact.view.js";
import { createContact } from "./add-contact.service.js";

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
  const governorateId = Number(formData.get("governorateId"));
  if (!Number.isInteger(governorateId) || governorateId <= 0) {
    alert("Please select a valid governorate.");
    return;
  }
  const contact = {
    firstName: formData.get("firstName"),
    lastName: formData.get("lastName"),
    phone: formData.get("phone"),
    email: formData.get("email"),
    address: formData.get("address"),
    governorateId
  };

  
  try {
    const result = await createContact(contact);
    console.log("SUCCESS:", result);
    
    alert("Contact created successfully ✅");
    closeModal();
    e.target.reset();

    // update state + re-render -> later when we have state management

  } catch (err) {
    console.error("ERROR:", err);
    alert("Something went wrong ❌");
  }
}