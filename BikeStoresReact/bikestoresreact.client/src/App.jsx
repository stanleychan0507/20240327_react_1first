import { BrowserRouter, Routes, Route } from "react-router-dom";
import { Component } from "react";
import Navbar from "./Components/Navbar"
import Get from "./Components/Get";
import Menu from "./Components/Menu";
import 'bootstrap/dist/css/bootstrap.min.css';

class App extends Component {
    render(){
        return ( 
            <div className="App">
            <Navbar />
                <div className="content">
                    <BrowserRouter>
                        <Routes>
                            <Route path="/" element={<Get />} />   
                            <Route path="/menu" element={<Menu />}></Route>
                        </Routes>
                    </BrowserRouter>
                </div>
            </div>);
    };
}

export default App;