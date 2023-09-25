import { useEffect, useState } from "react";
import { getCustomers } from "../data/customerData";
import { getStylists } from "../data/stylistData";
import { getServices } from "../data/servicesData";

export const AddAppointment = ({handleAppointmentAdd}) => {

    const [customers, setCustomers] = useState([]);

    const [customerId, setCustomerId] = useState(null)

    const [stylists, setStylists] = useState([])

    const [stylistId, setStylistId] = useState(null)

    const [services, setServices] = useState([]);

    const [newAppointmentDate, setNewAppointmentDate] = useState("");

    useEffect(() => {
        getCustomers().then(setCustomers)
    },[])

    useEffect(() => {
        getStylists().then(setStylists)
    },[])

    useEffect(() => {
        getServices().then(services => {
            const updatedServices = services.map(service => ({
                ...service, isChecked: false
        }));
        setServices(updatedServices)
    });
    },[]);

    const handleCustomerSelect = (e) => {
        e.preventDefault();
        const value = e.target.value
        console.log(value)
        setCustomerId(value)
    }

    const handleStylistSelect = (e) => {
        e.preventDefault();
        const value = e.target.value
        console.log(value)
        setStylistId(value)
    }
    
    const handleDateSelect = (e) => {
        e.preventDefault();
        const value = e.target.value
        console.log(value)
        setNewAppointmentDate(value)
    }

    const handleCheck = (serviceId) => {
        setServices(prevServices => 
            prevServices.map(service => 
                service.id === serviceId ? { ...service, isChecked: !service.isChecked } : service
            )
        );
    };

    const checkedServices = services.filter(service => service.isChecked === true)
    const checkedServicesIds = checkedServices.map(cs => cs.id)
    console.log(checkedServices)
    

    const handleFormSubmit = (e) => {
        e.preventDefault();
        fetch("/api/appointments", {
            method: "POST",
            headers: {'Content-Type' : 'application/json'},
            body: JSON.stringify({
                "customerId": customerId,
                "stylistId": stylistId,
                "Date": newAppointmentDate,
                "services": checkedServices
            })             
        }).then(res => res.json())
        .then((newAppointment) => {
            handleAppointmentAdd(newAppointment)
        })
    }

return (
    
    <div>
    <form onSubmit={handleFormSubmit}> 
        <select onChange={handleCustomerSelect} name="customerName">
            <option value="">Please choose a customer</option>
        {customers.map(c => <option value={c.id} key={c.id}>{c.name}</option>)}
        </select>
        <select onChange={handleStylistSelect} name="stylistName">
            <option value="">Please choose a stylist</option>
            {stylists.map(s => <option value={s.id} key={s.id}>{s.name}</option>)}
        </select>
        <input type="date"
        placeholder=""
        onChange={handleDateSelect}
            />
            {services.map(s => <div><input
            key={s.id}
            type="checkbox"
            id="service"
            name="service"
            value={s.id}
            checked={s.isChecked}
            onChange={() => handleCheck(s.id)}    
            />{s.name}</div>)
            
            }
        <div>
    </div>
    <button className="btn btn-success">Submit</button>
    </form>
    </div>
)

}