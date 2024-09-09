import { Link } from "react-router-dom";

// add link to registerJS for job seeker and register JP for job Provider

function Register() {
  return (
    // <div>
    //   <h2 className="page-header">Register</h2>
    //   <div className="row">
    //     <div className="col"></div>
    //     <div className="col"></div>
    //     <div className="col"></div>
    //   </div>
    // </div>
    <div className="container">
      <div className="row justify-content-center">
        <div className="col-md-6">
          <div className="card mt-5">
            <div className="card-body text-center">
              <h2 className="card-title">Main Page</h2>
              <p className="card-text">Please select your role to register :</p>
              <div className="mt-4">
                <Link to="/AdminLogin" className="btn btn-primary btn-lg mx-2">
                  Admin
                </Link>
                <Link to="/Login" className="btn btn-success btn-lg mx-2">
                  Customer
                </Link>
                <Link to="/WorkerLogin" className="btn btn-success btn-lg mx-2">
                  Worker
                </Link>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Register;
