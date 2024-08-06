import { Link } from "react-router-dom"
import '@fortawesome/fontawesome-free/css/all.min.css';

export function Navbar() {

    return <nav className="navbar navbar-expand-lg bg-body-tertiary bg-dark" data-bs-theme="dark">
    <div className="container-fluid">
      
      <a className="navbar-brand">HouseHold Services</a>
      
      <div className="collapse navbar-collapse" id="navbarSupportedContent">
        <ul className="navbar-nav ms-auto mb-2 mb-lg-0">
          <li className="nav-item">
          <Link className="nav-link" aria-current="page" to="/home">
                Home
         </Link>
          </li>
          <li>
          <Link className="nav-link" aria-current="page" to="/Our Services">
            Our Services
            </Link>
          </li>

          {/* <li>
          <Link className="nav-link" aria-current="page" to="Register as Professional">
            Register as Professional
            </Link>
          </li> */}

          <li>
          <Link className="nav-link" aria-current="page" to="F.A.Q">
            F.A.Q
            </Link>
          </li>

         <li>
         <Link className="nav-link" aria-current="page" to="About">
            About
            </Link>
         </li>  
            <li className="nav-item">
              <Link className="nav-link" to="/cart">
                <i className="fas fa-shopping-cart"></i>
              </Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/profile">
                <i className="fas fa-user"></i>
              </Link>
            </li>
          </ul>
         
        
      </div>
    </div>
  </nav>
}

export default Navbar