import { renderAvatar } from "../../../src/components/contact-avatar/contact_avatar.view.js";

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

    const avatarElement = renderAvatar(contact);

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

    infoTd.appendChild(avatarElement);
    infoTd.appendChild(detailsDiv);

    tr.appendChild(infoTd);

    const actionsCell = document.createElement("td");
    actionsCell.className = "actions-cell";
    actionsCell.innerHTML = `
      <button class="actions-btn">⋯</button>

      <div class="actions-menu" hidden>
        <button class="action-update">Update</button>
        <button class="action-delete">Delete</button>
        <button class="action-cancel">Cancel</button>
      </div>
    </td>`;
    [contact.email, contact.address, contact.governorateName].forEach(text => {
      const td = document.createElement("td");
      td.textContent = getSafeText(text);
      tr.appendChild(td);
      tr.appendChild(actionsCell);
    });

    tbody.appendChild(tr);
  });
}
