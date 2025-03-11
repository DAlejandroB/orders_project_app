"use client";
import { useEffect, useState } from "react"
import { Client } from "../types/client";

function ClientsFetch(){
  const [data, setData] = useState<Array<Client> | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() =>{
    fetch('https://localhost:7249/api/Client')
    .then((response) => {
      if(!response.ok)
        return new Error("Network response was not ok");
      return response.json()
    })
    .then((data :Array<Client>) => {
      setData(data);
      setLoading(false);
    })
    .catch((error) =>{
      console.error("Error fetching data", error);
      setLoading(false);
    });
  }, []);

  if(loading) return <p>Loading...</p>

  return (
    <div>
      <table>
        <thead>
          <tr>
            <th scope="col">Name</th>
            <th scope="col">Address</th>
            <th scope="col">Contact Email</th>
            <th scope="col">Contact Phone</th>
          </tr>
        </thead>
        <tbody>
          {data?.map((row) => (
            <tr key={row.id}>
              <th scope="row">{row.name}</th>
              <td>{row.address}</td>
              <td>{row.contactEmail}</td>
              <td>{row.contactPhone}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default function Clients(){
  return <ClientsFetch/>;
}