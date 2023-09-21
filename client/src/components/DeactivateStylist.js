export const DeactivateStylist = ({ onDeactivate, stylist, stylistId}) => {
    
    const handleDeactivateButton = (e) => {
        e.preventDefault();
        fetch(`/api/stylists/${stylistId}`, {
        method: "DELETE",
        headers: {'Content-Type' : 'application/json'}
         })
         .then(res => res.json())
         .then(() => {
             onDeactivate(stylistId)
         })
    }
    

    return (
        <button onClick={handleDeactivateButton} className="btn btn-danger">Deactivate</button>
    )
}