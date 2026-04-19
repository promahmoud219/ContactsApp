import { get } from "../../shared/api/http-client";

export async function getAllContacts() {
  return get("/api/contacts");
}
