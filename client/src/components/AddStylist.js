import { useState } from "react";
import { useNavigate } from "react-router-dom";

export const AddStylist = ({handleStylistAdd}) => {
  const [addStylistButton, setAddStylistButton] = useState(false);

  const [stylistName, setStylistName] = useState("");

  const navigate = useNavigate();

  const handleAddStylistButton = (e) => {
    e.preventDefault();
    setAddStylistButton(true);
  };

  const handleSubmitButton = (e) => {
    e.preventDefault();
    fetch("/api/stylists", {
    method: "POST",
    headers: { 'Content-Type': 'application/json'},
    body: JSON.stringify({
        Name: stylistName,
    })
  })
    .then((res) => res.json())
    .then((newStylist) => {
        handleStylistAdd(newStylist)
        setAddStylistButton(false)
        navigate("/stylists")
    })
}

  return (
    <div className="container">
      {!addStylistButton && (
        <button onClick={handleAddStylistButton} className="btn btn-primary">
          Add Stylist
        </button>
      )}
      {addStylistButton ? (
        <div>
          <form onSubmit={handleSubmitButton}>
            <input
              type="text"
              name="name"
              placeholder="Stylist Name"
              value={stylistName}
              onChange={(e) => setStylistName(e.target.value)}
            />
            <div>
              <button
                onClick={() => setAddStylistButton(false)}
                className="btn btn-danger"
              >
                Cancel
              </button>
              <button className="btn btn-success">Submit</button>
            </div>
          </form>
        </div>
      ) : (
        ""
      )}
    </div>
  );
};
