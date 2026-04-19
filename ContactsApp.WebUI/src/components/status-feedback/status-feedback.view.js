/**
 * @param {string} type - 'loading' | 'error' | 'empty'
 * @param {string} message - النص اللي هيظهر
 */
export function renderStatusFeedback(type, message) {
  const container = document.createElement("div");
  container.className = `status-feedback status--${type}`;

  // بنجهز أيقونة لكل حالة (ممكن تستخدم الـ SVGs اللي عندك)
  const icons = {
    loading: '<div class="spinner"></div>',
    error: '⚠️',
    empty: '🔍'
  };

  container.innerHTML = `
    <div class="status-icon">${icons[type]}</div>
    <p class="status-message">${message}</p>
  `;

  return container;
}
 