import "./dropdown-menu.css";

/**
 * دالة جينيريك لرسم القائمة المنبثقة
 * @param {Array} options - مصفوفة الخيارات [{label, className, data}]
 */
export function renderDropdownMenu(options) {
  const container = document.createElement("div");
  container.className = "actions-wrapper";

  // 1. الزرار الأساسي (الثلاث نقاط)
  const triggerBtn = document.createElement("button");
  triggerBtn.className = "actions-btn";
  triggerBtn.setAttribute("type", "button");
  triggerBtn.innerHTML = `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 640 640"><!--!Font Awesome Free v7.2.0 by @fontawesome - https://fontawesome.com License - https://fontawesome.com/license/free Copyright 2026 Fonticons, Inc.--><path d="M96 320C96 289.1 121.1 264 152 264C182.9 264 208 289.1 208 320C208 350.9 182.9 376 152 376C121.1 376 96 350.9 96 320zM264 320C264 289.1 289.1 264 320 264C350.9 264 376 289.1 376 320C376 350.9 350.9 376 320 376C289.1 376 264 350.9 264 320zM488 264C518.9 264 544 289.1 544 320C544 350.9 518.9 376 488 376C457.1 376 432 350.9 432 320C432 289.1 457.1 264 488 264z"/></svg>`;
  


  // 2. القائمة (المنيو)
  const menu = document.createElement("div");
  menu.className = "actions-menu";
  menu.setAttribute("hidden", "true"); // مخفية في البداية

  // 3. رسم الخيارات جوه المنيو
  options.forEach(opt => {
    const btn = document.createElement("button");
    btn.textContent = opt.label;
    btn.className = opt.className || "";

    // "الزتونة": إضافة البيانات (ID مثلاً) كـ Dataset
    if (opt.data) {
      Object.keys(opt.data).forEach(key => {
        btn.dataset[key] = opt.data[key];
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

  // بنشوف هل المنيو مخفية ولا لأ
  const isHidden = menu.hasAttribute("hidden");

  // أولاً: نقفل أي منيو تانية مفتوحة في الصفحة (عشان ميبقاش فيه زحمة)
  closeAllMenus();

  // ثانياً: لو كانت مخفية، نفتحها
  if (isHidden) 
    menu.removeAttribute("hidden");
  else 
    menu.setAttribute("hidden", "true");
}

export function closeAllMenus() {
  // بنقفل أي "dropdown-content" أو "actions-menu" موجودة في الـ DOM
  // نصيحة: استخدم كلاس عام للكومبوننت بتاعك عشان ميحصلش تداخل
  document.querySelectorAll(".dropdown-content, .actions-menu").forEach(m => {
    m.setAttribute("hidden", "true");
  });
}
