import { openModal, closeModal } from "../../components/modal/modal.controller.js";
import { renderUpdateForm } from "./update-contact.view.js";
import { updateContact } from "./update-contact.service.js";
import { contactsCommonService } from "../../shared/services/contacts.common.service.js";
import { initGetAllContacts } from "../get-all-contacts/get-all-contacts.controller.js";

let isBound = false;

export function initUpdateContact() {
  if (isBound) return;

  document.addEventListener("click", async event => {
    const button = event.target.closest(".dropdown__item--update");
    if (!button) return;

    const contactId = Number(button.dataset.id);
    if (!Number.isInteger(contactId) || contactId <= 0) return;

    await handleOpen(contactId);
  });

  isBound = true;
}

async function handleOpen(contactId) {
  try {
    const contact = await contactsCommonService.getById(contactId);
    const form = renderUpdateForm(normalizeContact(contact));

    form.addEventListener("submit", handleSubmit);
    form.querySelector(".btn--cancel")?.addEventListener("click", closeModal);

    openModal(form);
  } catch (error) {
    console.error("Failed to load contact for update.", error);
    alert("Failed to load contact details.");
  }
}

async function handleSubmit(event) {
  event.preventDefault();

  const form = event.target;
  const formData = new FormData(form);
  const id = Number(form.dataset.id);
  const governorateId = Number(formData.get("governorateId"));

  if (!Number.isInteger(id) || id <= 0) {
    alert("Invalid contact id.");
    return;
  }

  if (!Number.isInteger(governorateId) || governorateId <= 0) {
    alert("Please select a valid governorate.");
    return;
  }

  const contact = {
    id,
    firstName: formData.get("firstName"),
    lastName: formData.get("lastName"),
    phone: formData.get("phone"),
    email: formData.get("email"),
    address: formData.get("address"),
    governorateId
  };

  try {
    await updateContact(contact);
    await initGetAllContacts();
    alert("Contact updated successfully.");
    closeModal();
  } catch (error) {
    console.error("Failed to update contact.", error);
    alert("Something went wrong.");
  }
}

function normalizeContact(contact) {
  const fullName = String(contact?.fullName ?? "").trim();
  const nameParts = fullName.split(/\s+/).filter(Boolean);
  const firstName = nameParts.shift() ?? "";
  const lastName = nameParts.join(" ");

  return {
    id: contact?.id ?? "",
    firstName,
    lastName,
    phone: contact?.phone ?? "",
    email: contact?.email ?? "",
    address: contact?.address ?? "",
    governorateId: mapGovernorateNameToId(contact?.governorateName)
  };
}

function mapGovernorateNameToId(governorateName) {
  const normalizedName = String(governorateName ?? "").trim().toLowerCase();

  const governorateIds = {
    cairo: 1,
    giza: 2,
    alexandria: 3,
    "kafr el sheikh": 4,
    sohag: 5
  };

  return governorateIds[normalizedName] ?? null;
}
