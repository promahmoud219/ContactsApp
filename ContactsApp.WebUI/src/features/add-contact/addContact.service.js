import { post } from "../../shared/api/httpClient";

export async function createContact(contact) {
  return post("/api/contacts", contact);
}