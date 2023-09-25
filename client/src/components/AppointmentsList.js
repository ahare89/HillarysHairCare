import { useEffect, useState } from "react"
import { getAppointments } from "../data/appointmentData"
import { Table } from "reactstrap"
import { AddAppointment } from "./AddAppointment"
import { DeleteAppointment } from "./DeleteAppointment"

export const AppointmentList = () => {

    const [appointments, setAppointments] = useState([])
    const [addAppointmentButton, setAddAppointmentButton] = useState(false)

    useEffect(() => {
        getAppointments().then(setAppointments)
    },[])

    const addAppointmentButtonHandler = (e) => {
        e.preventDefault();
        setAddAppointmentButton(true)
    }

    const cancelButtonHandler = (e) => {
        e.preventDefault();
        setAddAppointmentButton(false)
    }

    const handleAppointmentAdd = (newAppointment) => {
        setAppointments(prevAppointments => [...prevAppointments, newAppointment])
    }

    const handleAppointmentDelete = (deletedAppointmentId) => {
        setAppointments(prevAppointments => prevAppointments.filter(appointment => appointment.id !== deletedAppointmentId))    
    }

    return (
        <div className="container">
            <div className="sub-menu bg-light">
                <h4>Appointments</h4>
            </div>
            <Table>
                <thead>
                    <tr>
                        <th>Id</th>
                        <th>Customer Name</th>
                        <th>Stylist Name</th>
                        <th>Date</th>
                        <th>Services</th>
                    </tr>
                </thead>
                <tbody>
                {appointments.map(a => <tr key={`appointments-${a.id}`}>
                <th scope="row">{a.id}</th>
                <th>{a.customer.name}</th>
                <th>{a.stylist.name}</th>
                <th>{a.date}</th>
                <th>{a.services.map(service => service.name).join(', ')}</th>
                <th><DeleteAppointment onDelete = {handleAppointmentDelete} appointmentId = {a.id}/></th>
                </tr>
                )}
                </tbody>
            </Table>
            {addAppointmentButton ? (
  <>
     <AddAppointment handleAppointmentAdd = {handleAppointmentAdd}/>
     <button onClick={cancelButtonHandler} className="btn btn-danger">Cancel</button>
  </> 
) : (
  <button onClick={addAppointmentButtonHandler} className="btn btn-primary">Add Appointment</button>
)}

        </div>
    )
}