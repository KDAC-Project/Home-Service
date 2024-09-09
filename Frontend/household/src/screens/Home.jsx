import Navbar from "../components/Navbar";
import img from "../images/background_img.png"
import '../styles/Home.css';

export function Home() {
    return (
        <>
        <Navbar/>
        

        <div className="home-container">
            <img src={img} alt="full screen Background"
            className="fullscreen-image" />
            <div className="overlay">
                <h1>Welcome to  HouseHold Services</h1>
                <p>Your one-stop solution for all household needs</p>
            </div>
        </div>
        </>
       
    );
}

export default Home