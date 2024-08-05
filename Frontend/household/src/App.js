
import {Route, Routes} from 'react-router-dom'
import  { ToastContainer } from 'react-toastify'
import 'react-toastify/dist/ReactToastify.css'
import Register from './screens/Register'
import Login from './screens/Login'
import Home from './screens/Home'


function App() {
  return (
    <div>
      
      <Routes>
      <Route path='' element={<Login/>}></Route>
     
      <Route path='/register' element={<Register/>}></Route>
      <Route path='/Login' element={<Login/>}></Route>
      <Route path='/Home' element={<Home/>}></Route>
      
      </Routes>
      <ToastContainer/>
      {/* <h1 className="page-header" style={{background:"blue",height:50}}>Designed by PASS Group
    </h1> */}
      </div>
  )
}

export default App;

