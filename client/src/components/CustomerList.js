import { useEffect, useState } from "react";
import { getCustomers } from "../data/customerData";
import { Table } from "reactstrap";
import { AddCustomer } from "./AddCustomer";

export const CustomerList = () => {

    const [customers, setCustomers] = useState([]);

    useEffect(() => {
        getCustomers().then(setCustomers)
    },[])

    const handleCustomerAdd = (newCustomer) => {
        setCustomers(prevCustomers => [...prevCustomers, newCustomer]);
    }

    return (
        <div className="container">
            <div className="sub-menu bg-light">
                <h4>Customers</h4>
                </div>
                <Table>
                    <thead>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {customers.map((c) => <tr key={`customers-${c.id}`}>
                        <th scope="row">{c.id}</th>
                        <td>{c.name}</td>
                        </tr>
                        )}
                    </tbody>
                </Table>
                <AddCustomer handleCustomerAdd = {handleCustomerAdd}/>
            
        </div>
    )
}