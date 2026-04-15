const BASE_URL = import.meta.env.VITE_API_BASE_URL;

function buildUrl(url) {
  return `${BASE_URL}${url}`;
}

async function handleResponse(response) {
  if (!response.ok) {
    const text = await response.text();
    console.error("SERVER ERROR:", text);
    throw new Error(text || "Request failed");
  }

 
  if (response.status === 204) return null;

  return response.json();
}

export async function get(url) {
  const response = await fetch(buildUrl(url), {
    method: "GET",
    headers: {
      "Content-Type": "application/json"
    }
  });

  return handleResponse(response);
}

export async function post(url, data) {
  const response = await fetch(buildUrl(url), {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(data)
  });

  return handleResponse(response);
}