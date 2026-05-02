import "./styles/base/reset.css";
import "./styles/base/variables.css";
import "./styles/base/buttons.css";
import "./styles/base/icons.css";
import "./styles/base/inputs.css";
import "./styles/base/text.css";

import "./styles/layout/app-shell.css";
import "./styles/layout/sidebar.css";
import "./styles/layout/topbar.css";
import "./styles/layout/app-main.css";
import "./styles/layout/page.css";

import "./features/get-all-contacts/get-all-contacts.css";
import "./components/modal/modal.css";
import "./components/form/form.css";

import "./components/contact-avatar/contact_avatar.css";

import { initModal } from "./components/modal/modal.controller.js";
import {
  toggleMenu,
  closeAllMenus
} from "./components/dropdown-menu/dropdown-menu.view.js";

import { initAddContact } from "./features/add-contact/add-contact.controller.js";
import { initGetAllContacts } from "./features/get-all-contacts/get-all-contacts.controller.js";
import { initUpdateContact } from "./features/update-contact/update-contact.controller.js";
import { initDeleteContact } from "./features/delete-contact/delete-contact.controller.js";

initGetAllContacts();
initModal(".modal");
initAddContact();
initUpdateContact();
initDeleteContact();

document.addEventListener("click", e => {
  const trigger = e.target.closest(".dropdown__trigger");

  if (trigger) {
    const menu = trigger.nextElementSibling;
    toggleMenu(menu);
    return;
  }

  if (
    !e.target.closest(".dropdown__menu") ||
    e.target.classList.contains("dropdown__item--cancel")
  ) {
    closeAllMenus();
  }
});
