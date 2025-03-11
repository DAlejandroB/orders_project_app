import Clients from "../components/Clients";
import CreateClientForm from "../components/CreateClientForm";

export default function ClientsPage(){
  return (<div className="content-center">
    <h2 className="content-center"> This is the clients page! What do you want to do?</h2>
    <Clients/>
    <CreateClientForm/>
  </div>);
}