import { get } from "../../shared/api/httpClient";

export async function getAllContacts() {
  return get("/api/contacts");
}
