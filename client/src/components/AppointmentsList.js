import { useEffect, useState } from "react"
import { getAppointments } from "../data/appointmentData"
import { Table } from "reactstrap"

export const AppointmentList = () => {

    const [appointments, setAppointments] = useState([])

    useEffect(() => {
        getAppointments().then(setAppointments)
    },[])

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
                    </tr>
                </thead>
                <tbody>
                {appointments.map(a => <tr key={`appointments-${a.id}`}>
                <th scope="row">{a.id}</th>
                <th>{a.customer.name}</th>
                <th>{a.stylist.name}</th>
                <th>{a.date}</th>
                </tr>
                )}
                </tbody>
            </Table>
        
        </div>
    )
}