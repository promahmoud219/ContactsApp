const state = {
  contacts: []
};

const listeners = [];

export function getState() {
  return state;
}

export function setContacts(contacts) {
  state.contacts = contacts;
  notify();
}

export function addContact(contact) {
  state.contacts.push(contact);
  notify();
}

function notify() {
  listeners.forEach(fn => fn(state));
}

export function subscribe(fn) {
  listeners.push(fn);
}