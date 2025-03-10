"use client";
import { useEffect, useState } from "react"

interface Order{
  id: number,
  orderDateTime: string,
  totalPrice: string,
  clientId: string,
  status: string,
  orderItems: []
}

function OrdersFetch(){
  const [data, setData] = useState<Array<Order> | null>(null);
  const [loading, setLoading] = useState(true);

  useEffect(() =>{
    fetch('https://localhost:7249/api/Order')
    .then((response) => {
      if(!response.ok)
        return new Error("Network response was not ok");
      return response.json()
    })
    .then((data :Array<Order>) => {
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
    <div className="relative overflow-x-auto shadow-md sm:rounded-lg">
      <table className="w-full text-sm text-left rtl:text-right text-gray-500 dark:text-gray-400">
        <thead className="text-xs text-gray-700 uppercase bg-gray-50 dark:bg-gray-700 dark:text-gray-400">
          <tr>
            <th scope="col" className="py-4 px-4">Id</th>
            <th scope="col" className="py-4 px-4">Date</th>
            <th scope="col" className="py-4 px-4">Final Price</th>
            <th scope="col" className="py-4 px-4">Status</th>
          </tr>
        </thead>
        <tbody>
          {data?.map((row) => (
            <tr key={row.id} className="odd:bg-white odd:dark:bg-gray-900 even:bg-gray-50 even:dark:bg-gray-800 border-b dark:border-gray-700 border-gray-200">
              <th scope="row" className="px-6 py-4 font-medium text-gray-900 whitespace-nowrap dark:text-white">{row.id}</th>
              <td className="px-4 py-4">{row.orderDateTime}</td>
              <td className="py-4 px-4">{row.totalPrice}</td>
              <td className="py-4 px-4">{row.status}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default function Orders(){
  return <OrdersFetch/>;
}