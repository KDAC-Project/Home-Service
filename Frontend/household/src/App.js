
import {Route, Routes} from 'react-router-dom'
import  { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'
import Register from './screens/Register'
import Login from './screens/Login'
import Home from './screens/Home'
import Services from './screens/Services'
import BookingForm from './screens/BookingForm'
import OptionPage from './screens/OptionPage'
import AdminLogin from './screens/AdminLogin'
import WorkerRegister from './screens/WorkerRegister'
import WorkerLogin from './screens/WorkerLogin'
import WorkerDetails from './screens/WorkerDetails'
import BookingDetails from './screens/BookingDetails'
import FAQ from './screens/FAQ'
import AboutUs from './screens/AboutUs'






function App() {
  return (
    <div>
      
      <Routes>
      <Route path='' element={<Home/>}></Route>
      
      <Route path='/OptionPage' element={<OptionPage/>}></Route>
      <Route path='/AdminLogin' element={<AdminLogin/>}></Route>
      <Route path='/WorkerRegister' element={<WorkerRegister/>}></Route>
      <Route path='/WorkerLogin' element={<WorkerLogin/>}></Route>
       <Route path='/register' element={<Register/>}></Route> 
      <Route path='/Login' element={<Login/>}></Route>
      <Route path='/Home' element={<Home/>}></Route>
      <Route path='/Services' element={<Services/>}></Route>
      <Route path='/BookingForm' element={<BookingForm/>}></Route>
      <Route path='/WorkerDetails' element={<WorkerDetails/>}></Route>
      <Route path='/AboutUs' element={<AboutUs/>}></Route>
      
     
     {/* <Route path="/BookingDetails" element={<BookingDetails />} />*/}
     <Route path="/BookingDetails/:bookingId" element={<BookingDetails />} />
     <Route path='FAQ' element={<FAQ/>}></Route>
     
      
      </Routes>
      <ToastContainer/>
      {/* <h1 className="page-header" style={{background:"blue",height:50}}>Designed by PASS Group
    </h1> */}
      </div>
  )
}

export default App;

