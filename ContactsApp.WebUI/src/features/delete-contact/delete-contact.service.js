import { del } from "../../shared/api/http-client.js";

export async function deleteContact(id) {
  return del(`/api/contacts/${id}`);
}