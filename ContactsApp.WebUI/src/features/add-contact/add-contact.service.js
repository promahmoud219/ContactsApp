import { post } from "../../shared/api/http-client";

export async function createContact(contact) {
  return post("/api/contacts", contact);
}