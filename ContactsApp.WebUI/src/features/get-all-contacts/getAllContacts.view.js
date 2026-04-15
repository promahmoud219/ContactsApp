import { renderAvatar } from "../../../src/components/contact-avatar/contact_avatar.view.js";


function getInitials(fullName) {
  if (!fullName) return "?";

  return fullName
    .trim()
    .split(/\s+/)
    .slice(0, 2)
    .map(part => part[0]?.toUpperCase() ?? "")
    .join("");
}

function getSafeText(value, fallback = "-") {
  if (value === null || value === undefined || value === "") {
    return fallback;
  }

  return value;
}
 
export function renderContacts(contacts) {
  const tbody = document.querySelector(".contacts-table tbody");
  tbody.innerHTML = ""; 

  contacts.forEach(contact => {
    const tr = document.createElement("tr");

    const checkTd = document.createElement("td");
    checkTd.className = "select-row";
    checkTd.innerHTML = `<input type="checkbox" class="row-checkbox">`;
    tr.appendChild(checkTd);

    const infoTd = document.createElement("td");
    infoTd.className = "contact-info";

    const avatarDiv = document.createElement("div");
    avatarDiv.className = "avatar avatar--initials";
    avatarDiv.textContent = getInitials(contact.fullName);
    
    const detailsDiv = document.createElement("div");
    detailsDiv.className = "name-and-email";

    const nameDiv = document.createElement("div");
    nameDiv.className = "name";
    nameDiv.textContent = getSafeText(contact.fullName, "Unknown");

    const emailDiv = document.createElement("div");
    emailDiv.className = "email";
    emailDiv.textContent = getSafeText(contact.email);

    detailsDiv.appendChild(nameDiv);
    detailsDiv.appendChild(emailDiv);
    infoTd.appendChild(avatarDiv);
    infoTd.appendChild(detailsDiv);
    tr.appendChild(infoTd);
 
    [contact.phone, contact.address, contact.governorateName].forEach(text => {
        const td = document.createElement("td");
        td.textContent = getSafeText(text);
        tr.appendChild(td);
    });

    tbody.appendChild(tr);
  });
} 