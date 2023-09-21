import { useEffect, useState } from "react"
import { Table } from "reactstrap";
import { getStylists } from "../data/stylistData";
import { AddStylist } from "./AddStylist";

export const StylistList = () => {

    const [stylists, setStylists] = useState([]);

    const handleStylistAdd = (newStylist) => {
        setStylists(prevStylists => [...prevStylists, newStylist])
    }

    useEffect(() => {
        getStylists().then(setStylists);
    },[])

    return (
        <div className="container">
            <div className="sub-menu bg-light">
                <h4>Stylists</h4>
            </div>
            <Table>
                <thead>
                    <tr>
                    <th>Id</th>
                    <th>Stylist Name</th>
                    <th>Employment Status</th>
                    </tr>
                </thead>
                <tbody>
                    {stylists.map(s => <tr key={`stylists-${s.id}`}>
                        <td>{s.id}</td>
                        <td>{s.name}</td>
                        <td>{s.isEmployed ? "Active" : "Not Active"}</td>
                    </tr>)}
                </tbody>
            </Table>
                    <AddStylist handleStylistAdd={handleStylistAdd}/>
        </div>
    )

}