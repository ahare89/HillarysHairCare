import { useState } from "react";
import { useNavigate } from "react-router-dom";
import { getCustomers } from "../data/customerData";

export const AddCustomer = ({ handleCustomerAdd }) => {
  const [addCustomerButton, setAddCustomerButton] = useState(false);

  const navigate = useNavigate();

  const [customerName, setCustomerName] = useState("");

  const handleAddCustomerButton = (e) => {
    e.preventDefault();
    setAddCustomerButton(true);
  };

  const handleSubmitButton = (e) => {
    e.preventDefault();
    fetch("/api/customers", {
      method: "POST",
      headers: { "Content-Type": "application/json" },
      body: JSON.stringify({
        Name: customerName,
      })
    })
        .then((res) => res.json())
        .then((newCustomer) => {
          handleCustomerAdd(newCustomer);
        })
        .then(() => navigate("/customers"))
        setAddCustomerButton(false)
  };

  return (
    <div className="container">
      {!addCustomerButton && (
        <button onClick={handleAddCustomerButton} className="btn btn-primary">
          Add Customer
        </button>
      )}
      {addCustomerButton ? (
        <div>
          <form onSubmit={handleSubmitButton}>
            <input
              type="text"
              name="name"
              placeholder="Customer Name"
              value={customerName}
              onChange={(e) => setCustomerName(e.target.value)}
            />
            <div>
              <button
                onClick={() => setAddCustomerButton(false)}
                className="btn btn-danger"
              >
                Cancel
              </button>
              <button type="submit" className="btn btn-success">
                Submit
              </button>
            </div>
          </form>
        </div>
      ) : (
        ""
      )}
    </div>
  );
};
