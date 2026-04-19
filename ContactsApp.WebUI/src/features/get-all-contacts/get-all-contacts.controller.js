import { getAllContacts } from "./get-all-contacts.service.js";
import { renderContacts } from "./get-all-contacts.view.js";
import { renderStatusFeedback } from "../../components/status-feedback/status-feedback.view.js";

import { UI_MESSAGES } from "../../utils/uiMessages.js";




export async function initGetAllContacts() {
  const tbody = document.querySelector(".contacts-table tbody");

  if (!tbody) {
    console.error("Could not find contacts table body.");
    return;
  }

  tbody.innerHTML = "";
  const loading = renderStatusFeedback("loading", UI_MESSAGES.LOADING_CONTACTS);
  tbody.appendChild(wrapInTd(loading));

  try {
    const contacts = await getAllContacts();
    renderContacts(contacts);
    console.log(UI_MESSAGES.GetContactsSUCCESSMsg);
  } catch (err) {
    console.error(UI_MESSAGES.GetContactsFAILUREMsg, err);
    tbody.innerHTML = "";

    const error = renderStatusFeedback(
      "error",
      UI_MESSAGES.GetContactsFAILUREMsg
    );
    tbody.appendChild(wrapInTd(error));

    setTimeout(initGetAllContacts, 5000);
  }
}

function wrapInTd(element) {
  const tr = document.createElement("tr");
  const td = document.createElement("td");
  td.setAttribute("colspan", "6");
  td.appendChild(element);
  tr.appendChild(td);
  return tr;
}
