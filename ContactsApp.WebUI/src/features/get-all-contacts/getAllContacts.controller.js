import { getAllContacts } from "./getAllContacts.service.js";
import { renderContacts } from "./getAllContacts.view.js";

export async function initGetAllContacts() {
  try {
    const contacts = await getAllContacts();

    renderContacts(contacts);
    console.log("✅ البيانات وصلت والسيرفر زي الفل");

  } catch (err) {
    console.error("❌ فشل الاتصال: السيرفر لسه مقمش.. هحاول تاني كمان 5 ثواني");
    
    // showLoadingStatus("مشكلة في الاتصال.. جاري إعادة المحاولة...");

    setTimeout(initGetAllContacts, 5000);
  }
}
