import "./dropdown-menu.css";

export function renderDropdownMenu(options) {
  const container = document.createElement("div");
  container.className = "dropdown";

  // trigger
  const triggerBtn = document.createElement("button");
  triggerBtn.className = "dropdown__trigger btn";
  triggerBtn.type = "button";

  const icon = document.createElement("span");
  icon.className = "dropdown__icon";
  icon.innerHTML = `
    <svg class="dropdown__icon-svg" viewBox="0 0 640 640">
      <path d="M96 320C96 289.1 121.1 264 152 264C182.9 264 208 289.1 208 320C208 350.9 182.9 376 152 376C121.1 376 96 350.9 96 320zM264 320C264 289.1 289.1 264 320 264C350.9 264 376 289.1 376 320C376 350.9 350.9 376 320 376C289.1 376 264 350.9 264 320zM488 264C518.9 264 544 289.1 544 320C544 350.9 518.9 376 488 376C457.1 376 432 350.9 432 320C432 289.1 457.1 264 488 264z"/>
    </svg>
  `;

  triggerBtn.appendChild(icon);

  // menu
  const menu = document.createElement("div");
  menu.className = "dropdown__menu";
  menu.setAttribute("hidden", "true");

  // items
  options.forEach(opt => {
    const btn = document.createElement("button");
    btn.className = `dropdown__item ${opt.className || ""}`;
    btn.textContent = opt.label;

    if (opt.data) {
      Object.entries(opt.data).forEach(([key, value]) => {
        btn.dataset[key] = value;
      });
    }

    menu.appendChild(btn);
  });

  container.appendChild(triggerBtn);
  container.appendChild(menu);

  return container;
}

export function toggleMenu(menu) {
  if (!menu) return;

  const isHidden = menu.hasAttribute("hidden");

  closeAllMenus();

  if (isHidden) menu.removeAttribute("hidden");
  else menu.setAttribute("hidden", "true");
}

export function closeAllMenus() {
  document.querySelectorAll(".dropdown__menu").forEach(m => {
    m.setAttribute("hidden", "true");
  });
}