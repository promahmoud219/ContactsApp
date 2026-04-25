import { put } from "../../shared/api/http-client.js";

export async function updateContact(contact) {
  return put(`/api/contacts/${contact.id}`, contact);
}
