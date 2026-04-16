import { getInitials, stringToColor } from "./contact_avatar.utils.js";


export function renderAvatar(contact) {
  const container = document.createElement("div");
  container.classList.add("avatar--initials", "avatar");

  /*   img is not going to be used for now, but we can add it later if needed "it's not easy"
  if (contact.imageUrl) {
    const img = document.createElement("img");
    img.src = contact.imageUrl;
    img.alt = "avatar";
    container.appendChild(img);
  } else {
    */
    
    const [firstName = "", lastName = ""] = contact.fullName
      ? contact.fullName.trim().split(/\s+/, 2)
      : [contact.firstName, contact.lastName];
    const initials = getInitials(firstName, lastName) || "?";
    const color = stringToColor(Number(contact.id) || 0);

    container.style.backgroundColor = color;
    container.textContent = initials;

  return container;
}
