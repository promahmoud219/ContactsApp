// بنستخدم SCREAMING_SNAKE_CASE لاتفاقية تسمية الثوابت
export const UI_MESSAGES = {
    LOADING_CONTACTS: "Fetching contacts, please wait...",
    ERROR_CONNECTION: "Server connection failed. Retrying automatically...",
    EMPTY_STATE: "No contacts found. Start by adding a new one!",
    RETRY_BTN: "Retry Now"
};

export const API_CONFIG = {
    BASE_URL: "https://localhost:7001/api",
    RETRY_DELAY: 5000 // الـ 5 ثواني بتوعنا
};