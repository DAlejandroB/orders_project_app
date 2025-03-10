import Clients from './components/Clients';
import Header from './components/Header';
import Orders from './components/Orders';

export default function Page() {
  return <div>
    <Header/>
    <h1>Hello, Next.js!</h1>
    <Clients/>
    <Orders/>
  </div>
}