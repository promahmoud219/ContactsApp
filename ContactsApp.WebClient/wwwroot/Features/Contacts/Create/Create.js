const form = document.getElementById("create-form");
const message = document.getElementById("message");

form.addEventListener("submit", async (e) => {
    e.preventDefault();

    const contact = {
        firstName: document.getElementById("firstName").value,
        email: document.getElementById("email").value
    };

    try {
        const res = await fetch("https://localhost:5001/api/contacts", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(contact)
        });

        if (!res.ok) throw new Error();

        message.innerText = "Created!";
        form.reset();

    } catch {
        message.innerText = "Error!";
    }
});