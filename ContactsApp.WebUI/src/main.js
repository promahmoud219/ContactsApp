import "./styles/base/reset.css";
import "./styles/base/variables.css";

import "./styles/layout/app-shell.css";
import "./styles/layout/sidebar.css";
import "./styles/layout/topbar.css";
import "./styles/layout/app-main.css";
import "./styles/layout/page.css";


import "./styles/features/contacts/contacts-table.css";
import "./styles/features/modal/modal.css";



import "./styles/base/reset.css";
import "./styles/base/variables.css";

import "./styles/layout/app-shell.css";
import "./styles/layout/sidebar.css";
import "./styles/layout/topbar.css";
import "./styles/layout/app-main.css";
import "./styles/layout/page.css";


import "./styles/features/contacts/contacts-table.css";
import "./styles/features/add-contact/add-contact-form.css";
import "./styles/features/modal/modal.css";

import "./components/contact-avatar/contact_avatar.css";


import { initModal } from "./features/modal/modal.js";
import { initAddContact } from "./features/add-contact/add-contact.controller.js";
import { initGetAllContacts } from "./features/get-all-contacts/get-all-contacts.controller.js";

import { toggleMenu, closeAllMenus } from "./components/dropdown-menu/dropdown-menu.view.js";

initGetAllContacts();

initModal(".modal");
initAddContact();




document.addEventListener("click", (e) => {

    if (e.target.closest(".actions-btn") || e.target.closest(".dropdown-trigger")) {
        const btn = e.target.closest("button");
        const container = btn.parentElement;
        const menu = container.querySelector(".actions-menu, .dropdown-content");

        toggleMenu(menu);
        return;
    }

    if (!e.target.closest(".actions-menu") || e.target.classList.contains("action-cancel")) {
        closeAllMenus();
    }
});