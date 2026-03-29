const routes = {
    create: "/Features/Contacts/Create/Create.html"
};

async function loadRoute(route) {
    const path = routes[route];

    if (!path) {
        console.error("Route not found");
        return;
    }

    const response = await fetch(path);
    const html = await response.text();

    document.getElementById("content").innerHTML = html;

    if (route === "create")  
        await import("/Features/Contacts/Create/Create.js");
     
}

// navigation
document.querySelector(".sidebar").addEventListener("click", (e) => {
    const route = e.target.dataset.route;
    if (!route) return;

    loadRoute(route);
});

loadRoute("create");