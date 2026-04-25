import { renderAvatar } from "../../components/contact-avatar/contact_avatar.view.js";
import { renderDropdownMenu } from "../../components/dropdown-menu/dropdown-menu.view.js";

function getSafeText(value, fallback = "-") {
  return value ?? fallback;
}

export function renderContacts(contacts) {
  const tbody = document.querySelector(".contacts__body");
  if (!tbody) return;

  tbody.innerHTML = "";

  contacts.forEach(contact => {
    const tr = document.createElement("tr");
    tr.className = "contacts__row";

    const checkTd = document.createElement("td");
    checkTd.className = "contacts__cell contacts__cell--select";

    const checkbox = document.createElement("input");
    checkbox.type = "checkbox";
    checkbox.className = "contacts__checkbox";

    checkTd.appendChild(checkbox);
    tr.appendChild(checkTd);

    const infoTd = document.createElement("td");
    infoTd.className = "contacts__cell contacts__cell--info";

    const avatarElement = renderAvatar(contact);

    const detailsDiv = document.createElement("div");
    detailsDiv.className = "contacts__details";

    const nameDiv = document.createElement("div");
    nameDiv.className = "contacts__name";
    nameDiv.textContent = getSafeText(contact.fullName, "Unknown");

    detailsDiv.appendChild(nameDiv);

    infoTd.appendChild(avatarElement);
    infoTd.appendChild(detailsDiv);

    tr.appendChild(infoTd);

    [contact.phone, contact.email, contact.address, contact.governorateName].forEach(text => {
      const td = document.createElement("td");
      td.className = "contacts__cell";
      td.textContent = getSafeText(text);
      tr.appendChild(td);
    });

    const actionsTd = document.createElement("td");
    actionsTd.className = "contacts__cell contacts__cell--actions";

    const menuOptions = [
      { label: "Update", className: "dropdown__item--update", data: { id: contact.id } },
      { label: "Delete", className: "dropdown__item--delete", data: { id: contact.id } },
      { label: "Cancel", className: "dropdown__item--cancel" }
    ];

    const dropdown = renderDropdownMenu(menuOptions);
    actionsTd.appendChild(dropdown);

    tr.appendChild(actionsTd);
    tbody.appendChild(tr);
  });
}
