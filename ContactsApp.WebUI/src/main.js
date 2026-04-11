const modal = document.querySelector(".modal");

let btn_add_contact = document.getElementById("btn-add-contact");
let btn_cancel = document.getElementById("btn-cancel");

btn_add_contact.addEventListener("click", openModal);
btn_cancel.addEventListener("click", closeModal);
document.querySelector(".modal__overlay").addEventListener("click", closeModal);
 
 

document.addEventListener("keydown", (e) => {
  if (e.key === "Escape") {
    closeModal();
  }
});

let isModalOpen = false;

function openModal() {
  if (isModalOpen) return;

  modal.removeAttribute("hidden");
  document.body.style.overflow = "hidden";

  modal.querySelector("input")?.focus();

  isModalOpen = true;
}

function closeModal() {
  if (!isModalOpen) return;

  modal.setAttribute("hidden", true);
  document.body.style.overflow = "";

  isModalOpen = false;
}