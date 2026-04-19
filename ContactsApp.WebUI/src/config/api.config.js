// Vite بيخلينا نوصل للـ .env عن طريق import.meta.env
export const API_CONFIG = {
    // لو الـ env مش موجود، هيستخدم localhost كاحتياطي (Fallback)
    BASE_URL: import.meta.env.VITE_API_BASE_URL || "http://localhost:5071",
    RETRY_DELAY: 5000,
    TIMEOUT: 10000 // ممكن تضيف إعدادات تانية براحتك
};