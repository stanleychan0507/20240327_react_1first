export default function Report({ report }) {

    const renderProperty = (value, key) => {
        if (typeof key == "object") {
            if (report.mode == "product") {
                return (
                    <table title="Product Details">
                        <thead>
                            <tr>
                                <th>Product ID</th>
                                <th>Product Name</th>
                                <th>Model Year</th>
                                <th>List Price</th>
                                <th>Quantity</th>
                            </tr>
                        </thead>
                        <tbody>
                            {productDetailsByProduct(key)}
                        </tbody>
                    </table>
                );
            }

            else if (report.mode == "brand") {
                return (
                    <table title="Brand Details">
                        <thead>
                            <tr>
                                <th>Brand ID</th>
                                <th>Brand Name</th>
                            </tr>
                        </thead>
                        <tbody>
                            {productDetailsByBrand(key)}
                        </tbody>
                    </table>
                );
            }
            else if (report.mode == "category") {
                return (
                    <table title="Category Details">
                        <thead>
                            <tr>
                                <th>Category ID</th>
                                <th>Category Name</th>
                            </tr>
                        </thead>
                        <tbody>
                            {productDetailsByCategory(key)}
                        </tbody>
                    </table>
                );
            }

        }
        else {
            return (
                <div>
                    <p>{value} : {key}</p>
                </div>);
        }
    };
    return (
        <div>
            {Object.entries(report)?.map(([key, value]) => renderProperty(key, value))}
        </div>)
};

function productDetailsByProduct(key) {
    return (
        key?.map((item, index) => {
            return (
                <tr>
                    <td>{item.productId}</td>
                    <td>{item.productName}</td>
                    <td>{item.modelYear}</td>
                    <td>{item.listPrice}</td>
                    <td>{item.quantity}</td>
                </tr>
            );
        })
    );
}

function productDetailsByBrand(key) {
    return (
        key?.map((item, index) => {
            console.log("Item here : ")
            return (
                <tr>
                    <td>{item.brandId}</td>
                    <td>{item.brandName}</td>

                </tr>
            );
        })
    );
}

function productDetailsByCategory(key) {
    return (
        key?.map((item, index) => {
            console.log("Item here : ")
            console.log(item)
            return (
                <tr>
                    <td>{item.categoryId}</td>
                    <td>{item.categoryName}</td>

                </tr>
            );
        })
    );
}

