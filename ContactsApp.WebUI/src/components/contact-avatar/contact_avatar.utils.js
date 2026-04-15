export function getInitials(firstName, lastName) {
  return `${firstName?.[0] ?? ""}${lastName?.[0] ?? ""}`.toUpperCase();
}

export function stringToColor(id) {
  let hash = id;

  return `hsl(${hash % 360}, 60%, 50%)`;
}