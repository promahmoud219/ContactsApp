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
  triggerBtn.textContent = "⋯"; // الرمز
  
  // 2. القائمة (المنيو)
  const menu = document.createElement("div");
  menu.className = "actions-menu";
  menu.setAttribute("hidden", "true"); // مخفية في البداية

  // 3. رسم الخيارات جوه المنيو
  options.forEach(opt => {
    const btn = document.createElement("button");
    btn.textContent = opt.label;
    
    // إضافة الكلاسات (عشان اللون والشكل والكنترولر يعرف يمسكه)
    if (opt.className) btn.className = opt.className;

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
  // بنشوف هل المنيو مخفية ولا لأ
  const isHidden = menu.hasAttribute("hidden");

  // أولاً: نقفل أي منيو تانية مفتوحة في الصفحة (عشان ميبقاش فيه زحمة)
  closeAllMenus();

  // ثانياً: لو كانت مخفية، نفتحها
  if (isHidden) {
    menu.removeAttribute("hidden");
  }
}

export function closeAllMenus() {
  // بنقفل أي "dropdown-content" أو "actions-menu" موجودة في الـ DOM
  // نصيحة: استخدم كلاس عام للكومبوننت بتاعك عشان ميحصلش تداخل
  document.querySelectorAll(".dropdown-content, .actions-menu").forEach(m => {
    m.setAttribute("hidden", "true");
  });
}