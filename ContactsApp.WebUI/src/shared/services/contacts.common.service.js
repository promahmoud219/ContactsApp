import { get } from "../api/http-client.js";

export const contactsCommonService = {
  getById(id) {
    return get(`/api/contacts/${id}`);
  }
};
