import { renderAvatar } from "../../components/contact-avatar/contact_avatar.view.js";
import { renderDropdownMenu } from "../../components/dropdown-menu/dropdown-menu.view.js";

function getSafeText(value, fallback = "-") {
  if (value === null || value === undefined || value === "") {
    return fallback;
  }

  return value;
}


export function renderContacts(contacts) {
  const tbody = document.querySelector(".contacts-table tbody");
  if (!tbody) return; 
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
    
   

    [contact.email, contact.address, contact.governorateName].forEach(text => {
      const td = document.createElement("td");
      td.textContent = getSafeText(text);
      tr.appendChild(td);
    });
    
    // جوه الـ Loop بتاع contacts.forEach
    const actionsTd = document.createElement("td");
    actionsTd.className = "actions-cell";

     // بنجهز "الداتا" اللي الزرار هيشيلها
    const menuOptions = [
      { label: "Update", className: "action-update", data: { id: contact.id } },
      { label: "Delete", className: "action-delete", data: { id: contact.id } },
      { label: "Cancel", className: "action-cancel" }
    ]; 

    // ننادي الكومبوننت
    const dropdown = renderDropdownMenu(menuOptions);
    actionsTd.appendChild(dropdown);

    tr.appendChild(actionsTd);
    tbody.appendChild(tr);
  });
}
