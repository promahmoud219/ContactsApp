export function renderStatusFeedback(type, message) {
  const container = document.createElement("div");
  container.className = `status status--${type}`;

  // icon container
  const iconWrapper = document.createElement("div");
  iconWrapper.className = "status__icon";

  // message
  const msg = document.createElement("p");
  msg.className = "status__message";
  msg.textContent = message;

  // icons
  if (type === "loading") {
    const spinner = document.createElement("div");
    spinner.className = "status__spinner";
    iconWrapper.appendChild(spinner);
  }

  if (type === "error") {
    iconWrapper.textContent = "⚠️";
  }

  if (type === "empty") {
    iconWrapper.textContent = "🔍";
  }

  container.appendChild(iconWrapper);
  container.appendChild(msg);

  return container;
}