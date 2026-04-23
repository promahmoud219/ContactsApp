import { getInitials, stringToColor } from "./contact_avatar.utils.js";

export function renderAvatar(contact) {
  const container = document.createElement("div");
  container.className = "avatar";

  const [firstName = "", lastName = ""] = contact.fullName
    ? contact.fullName.trim().split(/\s+/, 2)
    : [contact.firstName, contact.lastName];

  const initials = getInitials(firstName, lastName) || "?";
  const color = stringToColor(Number(contact.id) || 0);

  const initialsEl = document.createElement("div");
  initialsEl.className = "avatar__initials";
  initialsEl.style.backgroundColor = color;
  initialsEl.textContent = initials;

  container.appendChild(initialsEl);

  return container;
}