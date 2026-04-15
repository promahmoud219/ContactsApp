import { getAllContacts } from "./getAllContacts.service.js";
import { renderContacts } from "./getAllContacts.view.js";

export async function initGetAllContacts() {
  try {
    const contacts = await getAllContacts();
    renderContacts(contacts);
  } catch (err) {
    console.error(err);
  }
}
