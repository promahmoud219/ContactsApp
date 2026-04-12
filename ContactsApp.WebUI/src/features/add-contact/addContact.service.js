export async function createContact(contact) {
  return post("/contacts", contact);
}