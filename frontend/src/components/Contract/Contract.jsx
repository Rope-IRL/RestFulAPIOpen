import styles from "./Contract.module.css"

function Contract({contract, property, landlord, lessee}) {
    return (
        <div className = {styles["contract-container"]}>
            <div className = {styles["contract-header"]}>
                {property.header}
            </div>
            <div className={styles["dates-container"]}>
                <div>
                    Starts {contract.startDate}
                </div>
                <div>
                    Ends {contract.endDate}
                </div>
            </div>
            <div className = {styles["lessee-container"]} >
                <div className= {styles["lessee-container-header"]}>
                    Lessee
                </div>
                <div>
                    {contract.lessee.additionalInfo.name}
                </div>
                <div>
                    {contract.lessee.additionalInfo.surname}
                </div>
            </div>
            <div className = {styles["landlord-container"]}>
                <div className= {styles["landlord-container-header"]}>
                    Landlord
                </div>
                <div>
                    {landlord.name}
                </div>
                <div>
                    {landlord.surname}
                </div>
            </div>
            <div className = {styles["contract-container-cost"]}>
                Total: {contract.cost}
            </div>
        </div>
    )
}
export default Contract