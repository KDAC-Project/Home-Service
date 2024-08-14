import { Link } from "react-router-dom";
import '@fortawesome/fontawesome-free/css/all.min.css';

export function Navbar() {
  return (
    <nav className="navbar navbar-expand-lg bg-body-tertiary bg-dark" data-bs-theme="dark">
      <div className="container-fluid">
        <a className="navbar-brand">HouseHold Services</a>

        <div className="collapse navbar-collapse" id="navbarSupportedContent">
          <ul className="navbar-nav ms-auto mb-2 mb-lg-0">
            <li className="nav-item">
              <Link className="nav-link" aria-current="page" to="/home">Home</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/Services">Our Services</Link>
            </li>
            {/* <li className="nav-item">
              <Link className="nav-link" to="/Register">Register</Link>
            </li> */}
            <li className="nav-item">
              <Link className="nav-link" to="/FAQ">F.A.Q</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/AboutUs">AboutUs</Link>
            </li>
            <li className="nav-item">
              <Link className="nav-link" to="/cart">
                <i className="fas fa-shopping-cart"></i>
              </Link>
            </li>
            <li className="nav-item dropdown">
              <a className="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                <i className="fas fa-user"></i>
              </a>
              <ul className="dropdown-menu dropdown-menu-end" aria-labelledby="navbarDropdown">
                <li><Link className="dropdown-item" to="/OptionPage">Main Page</Link></li>
               
              </ul>
            </li>
          </ul>
        </div>
      </div>
    </nav>
  );
}

export default Navbar;
