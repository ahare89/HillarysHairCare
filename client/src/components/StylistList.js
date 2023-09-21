import { useEffect, useState } from "react"
import { Table } from "reactstrap";
import { getStylists } from "../data/stylistData";

export const StylistList = () => {

    const [stylists, setStylists] = useState([]);

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
        </div>
    )

}