import { getAllContacts } from "./get-all-contacts.service.js";
import { renderContacts } from "./get-all-contacts.view.js";
import { renderStatusFeedback } from "../../components/status-feedback/status-feedback.view.js";
import { UI_MESSAGES } from "../../utils/uiMessages.js";

export async function initGetAllContacts() {
  const tbody = document.querySelector(".contacts__body");

  if (!tbody) {
    console.error("Could not find contacts table body.");
    return;
  }

  tbody.replaceChildren();

  const loading = renderStatusFeedback("loading", UI_MESSAGES.LOADING_CONTACTS);
  tbody.appendChild(wrapInRow(loading));

  try {
    const contacts = await getAllContacts();
    renderContacts(contacts);
    console.log(UI_MESSAGES.GetContactsSUCCESSMsg);
  } catch (err) {
    console.error(UI_MESSAGES.GetContactsFAILUREMsg, err);

    tbody.replaceChildren();

    const error = renderStatusFeedback(
      "error",
      UI_MESSAGES.GetContactsFAILUREMsg
    );

    tbody.appendChild(wrapInRow(error));

    setTimeout(initGetAllContacts, 2000);
  }
}

function wrapInRow(element) {
  const tr = document.createElement("tr");
  tr.className = "contacts__row";

  const td = document.createElement("td");
  td.className = "contacts__cell contacts__cell--status";
  td.colSpan = 7;

  td.appendChild(element);
  tr.appendChild(td);

  return tr;
}