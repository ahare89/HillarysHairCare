export const DeleteAppointment = ({ onDelete, appointmentId }) => {

console.log(appointmentId)

const CancelAppointmentButtonHandler = (e) => {
    e.preventDefault();
    fetch(`/api/appointments/${appointmentId}`, {
    method: "DELETE",
    headers: {'Content-Type' : 'application/json'}
    })
    .then(response => {
        if (response.status === 204)
        {
            onDelete(appointmentId)
        }
        onDelete();
    })
}

return (
<button className="btn btn-danger" onClick={CancelAppointmentButtonHandler}>Cancel Appointment</button>    
)

}