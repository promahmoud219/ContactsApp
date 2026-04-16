export function getInitials(firstName, lastName) {
  return `${firstName?.[0] ?? ""}${lastName?.[0] ?? ""}`.toUpperCase();
}

export function stringToColor(id) {
  const hue = (id * 137) % 360; 
  return `hsl(${hue}, 70%, 60%)`;
}