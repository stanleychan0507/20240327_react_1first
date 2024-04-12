import './Get.css';
import { useMemo, useEffect, useState } from "react";
import axios from "axios";
import Report from "./Report";

const Get = () => {
    const showUserApi = "https://localhost:7051/BikeStores/GetCustomersByRange?id=10";
    const genReportApi = "https://localhost:7051/BikeStores/Report/";
    const genReportApi_new = "";

    const [customers, setCustomers] = useState(null);
    const [mode, setMode] = useState();
    const [selectedCustomerId, setSelectedCustomerId] = useState();
    const [selectedMode, setSelectedMode] = useState();
    const [isSubmitted, setIsSubmitted] = useState(false);

    const [result, setResult] = useState();

    const handleChange = (e) => {
        console.log(e.target.value)
    }

    useEffect(() => {
        async function fetchData() {

            const response = await axios.get(showUserApi);
            setCustomers(response.data);
        }
        fetchData();
    }, []);

    const handleSubmit = (e) => {
        e.preventDefault();
        let genReportApi_new = genReportApi + selectedCustomerId + '?mode=' + selectedMode;
   
        generateReport(genReportApi_new);
    }

    async function generateReport(genReportApi_new) {

        const response = await axios.get(genReportApi_new);
        setResult(response.data);

        setIsSubmitted(true);

    }

        return (
            <div className="Get_genReport">

                <h2>Get Report</h2>
                <form>
                    <label>Customer</label>

                    <div className="dropdown">

                        <select 
                        onChange={(e) => { setSelectedCustomerId(e.target.value) }}>

                            {customers?.map((customer) => (
                                <option key={customer.customerId} value={customer.customerId}>{customer.email}</option>
                            ))}

                        </select>
                    </div>

                    <label>Mode</label>
                    <select
                        value={mode}
                        onChange={(e) => { setSelectedMode(e.target.value) }}>

                        <option value="product">product</option>
                        <option value="brand">brand</option>
                        <option value="category">category</option>
                    </select>

                    <button onClick={handleSubmit}>Submit</button>
                </form>
                
                {!isSubmitted?<></>:<Report report={result}/>}


            </div>
        );



    }

    export default Get;