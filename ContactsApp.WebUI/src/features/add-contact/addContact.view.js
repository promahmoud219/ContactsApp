

export function createAddContactView() {
    const form = document.createElement("form");
    form.id = "contact-form";

    form.innerHTML = `
    <h2>Add Contact</h2>
        <div class="form-group">
          <label>First Name</label>
          <input type="text" name="firstName" required />
        </div>
        <div class="form-group">
          <label>Last Name</label>
          <input type="text" name="lastName" required />
        </div>
        <div class="form-group">
          <label>Phone</label>
          <input type="tel" name="phone" />
        </div>
        <div class="form-group">
          <label>Email</label>
          <input type="email" name="email" />
        </div>
        <div class="form-group">
          <label>Address</label>
          <input type="text" name="address" />
        </div>
        <div class="form-group">
          <label>Governorate</label>
          <select name="country" required>                                                                                       
            <option value="" disabled selected>Select governorate</option>
            <option value="alexandria">Alexandria</option>
            <option value="aswan">Aswan</option>
            <option value="assiut">Assiut</option>
            <option value="beheira">Beheira</option>
            <option value="beni_suef">Beni Suef</option>
            <option value="cairo" selected>Cairo</option>
            <option value="dakahlia">Dakahlia</option>
            <option value="damietta">Damietta</option>
            <option value="fayoum">Fayoum</option>
            <option value="gharbia">Gharbia</option>
            <option value="giza">Giza</option>
            <option value="ismailia">Ismailia</option>
            <option value="kafr_el_sheikh">Kafr El Sheikh</option>
            <option value="luxor">Luxor</option>
            <option value="matrouh">Matrouh</option>
            <option value="minya">Minya</option>
            <option value="monufia">Monufia</option>
            <option value="new_valley">New Valley</option>
            <option value="north_sinai">North Sinai</option>
            <option value="port_said">Port Said</option>
            <option value="qalyubia">Qalyubia</option>
            <option value="qena">Qena</option>
            <option value="red_sea">Red Sea</option>
            <option value="sharqia">Sharqia</option>
            <option value="sohag">Sohag</option>
            <option value="south_sinai">South Sinai</option>
            <option value="suez">Suez</option>
          </select>
        </div>
        <div class="modal__actions">
          <button type="button" id="btn-cancel">Cancel</button>
          <button type="submit" id="btn-primary">Save</button>
        </div>
      `;

    return form;

}
