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


import { initModal } from "./features/modal/modal.js";
import { initAddContact } from "./features/add-contact/addContact.controller.js";

initModal(".modal");
initAddContact();

