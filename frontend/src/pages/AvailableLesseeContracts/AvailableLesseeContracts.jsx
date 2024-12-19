import {useState, useEffect} from "react"
import Contract from "../../components/Contract/Contract"
import { useAuthUser } from "../../hooks/useAuthUser"
import styles from "./AvailableLesseeContracts.module.css"

function AvailableLesseeContracts() {

    const {id, role} = useAuthUser()
    const [flatsContract, setFlatsContract] = useState([])
    const [housesContract, setHousesContract] = useState([])
    const [roomsContract, setRoomsContract] = useState([])



    const getProperty = async() => {
        const flatsRes = await fetch(`http://127.0.0.1:29180/api/flatcontract/lessee/filter`, {
            method: "GET",
            credentials: "include"
        })
        const housesRes = await fetch(`http://127.0.0.1:29180/api/housecontract/lessee/filter`, {
            method: "GET",
            credentials: "include"
        })
        const roomsRes = await fetch(`http://127.0.0.1:29180/api/roomcontract/lessee/filter`, {
            method: "GET",
            credentials: "include"
        })

        let flatsData = await flatsRes.json();
        let houseData = await housesRes.json();
        let roomData = await roomsRes.json();
        setFlatsContract(flatsData);
        setHousesContract(houseData);
        setRoomsContract(roomData);
    }
    
    useEffect(() => {
        getProperty()
    }, [])

    return (
        <div className = {styles["contracts-wrapper"]}>
            <div className = {styles["property-container"]}>
            <div className = {styles["property-container-header"]}>
                Flats contract
            </div>
            <div className={styles["propertycontracts-body"]}>
                {
                    flatsContract.map((item) => {
                        return <Contract key = {item.id} contract={item} property={item.flat}
                            landlord = {item.landlord.additionalInfo} lessee={item.lessee.additionalInfo}
                        />
                    })
                }
            </div>
            </div>
            <div className = {styles["property-container"]}>
            <div className = {styles["property-container-header"]}>
                Houses contract
            </div>
            <div className={styles["propertycontracts-body"]}>
                {
                    housesContract.map((item) => {
                        return <Contract key = {item.id} contract={item} property={item.house}
                            landlord = {item.landlord.additionalInfo} lessee={item.lessee.additionalInfo}
                        />
                    })
                }
            </div>
            </div>
            <div className = {styles["property-container"]}>
            <div className = {styles["property-container-header"]}>
                Rooms contract
            </div>
            <div className={styles["propertycontracts-body"]}>
                {
                    roomsContract.map((item) => {
                        return <Contract  key = {item.id} contract={item} property={item.room}
                            landlord = {item.landlord.additionalInfo} lessee={item.lessee.additionalInfo}
                        />
                    })
                }
            </div>
            </div>
        </div>
    )
}
export default AvailableLesseeContracts