import { getInitials, stringToColor } from "./contact_avatar.utils.js";

export function renderAvatar(contact) {
  const container = document.createElement("div");
  container.className = "avatar";

  if (contact.imageUrl) {
    const img = document.createElement("img");
    img.src = contact.imageUrl;
    img.alt = "avatar";
    container.appendChild(img);
  } else {
    const initials = getInitials(contact.firstName, contact.lastName);
    const color = stringToColor(contact.id);
    
    container.style.background = color;
    container.textContent = initials; 
    container.classList.add("avatar--initials");
  }

  return container;
}