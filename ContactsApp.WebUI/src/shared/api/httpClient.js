const BASE_URL = import.meta.env.VITE_API_BASE_URL;
export async function post(url, data) {
  console.log("BASE_URL:", import.meta.env.VITE_API_BASE_URL);
  const response = await fetch(`${BASE_URL}${url}`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(data)
  });

  if (!response.ok) {
    const text = await response.text(); 
    console.error("SERVER ERROR:", text);
    throw new Error(text || "Request failed");
  }

  return response.json();
}