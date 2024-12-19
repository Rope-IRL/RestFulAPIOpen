import { Link } from "react-router-dom";
import { useState, useEffect } from "react"
import styles from "./HotelRentPage.module.css"
import SearchForm from "../../components/SearchForm/SearchForm";
import image from "../../assets/pictures/KCD.jpg"
import Image from "../../components/BigImage/BigImage";


function HotelRentPage(){
    const [data, setData] = useState([])
    const [curNumber, setNumber] = useState(1)

    function numberConverter(number){
        const numbers = {
            1 : "One",
            2 : "Two",
            3 : "Three",
            4 : "Four",
            5 : "Five",
        }

        if (number in numbers) {
            return numbers[number];
        }

        return number
    }

    const fetchData = async () => {
        try {
            let res = await fetch(`http://127.0.0.1:29180/api/room/${curNumber}/20`);
            if(!res.ok){
                throw new Error("Failed first fetch")
            }
            let items = await res.json()
            setData(items)
        }
        catch(error){
            console.error("Fetch failed, trying to back up")
            try{
                let res = await fetch(`http://127.0.0.1:29181/api/room/${curNumber}/20`);
                if(!res.ok){
                    throw new Error("Failed first fetch")
                }
                let items = await res.json()
                setData(items)
            }
            catch(error){
                console.error("Fetch failed, trying to back up")  
            }
        };
    }

    const handleSearchClick = async(startDate, endDate, city) => {
        if((city != "") && (startDate != null && endDate != null))
        {
            const res = await fetch(`http://127.0.0.1:29180/api/room/filter/${city}/${startDate}/${endDate}`,{
                method: "GET",
                credentials: "include",
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                },
            })
    
            const data = await res.json()
    
            setData(data)
        }
        else if(startDate != null && endDate != null){
            const res = await fetch(`http://127.0.0.1:29180/api/room/filter/${startDate}/${endDate}`,{
                method: "GET",
                credentials: "include",
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                },
            })
    
            const data = await res.json()
    
            setData(data)
        }
        else if((startDate == null && endDate == null) && (city!="")){
            const res = await fetch(`http://127.0.0.1:29180/api/room/filter/${city}`,{
                method: "GET",
                credentials: "include",
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                },
            })
    
            const data = await res.json()
    
            setData(data)
        }
    }

    useEffect(() =>{
        fetchData()
    }, [curNumber]);

    function seeNextrooms() {
        setNumber(prevNumber => {
            if (prevNumber < 1) {
                prevNumber = 1;
            }
            return prevNumber + 1;
        });
    }

    function seePreviosrooms(){ 
        setNumber(prevNumber => {
            if(prevNumber > 1){
                return prevNumber - 1;
            }
            else{
                return 1
            }
        });
    }
    return(
        <div>
            <SearchForm handleSearchClick = {handleSearchClick} />
            <div className = {styles["rooms_list"]}>
                {
                    data.map(item => (
                        <div key = {item.id} className = {styles["room-container"]}>
                            <div className={styles["room-container-image_container"]}>
                                {/* <img src={image} alt="image" className={styles["room-container-image_container-image"]}/> */}
                                <Image 
                                    alt = {`Room${item.id}`} 
                                    style = {"flat-container-image_container-image"}
                                    propertyId={item.id}
                                    propertyName={"room"}
                                />
                            </div>
                            <div className={styles["room-container-main_text"]}>
                                <div className = {styles["room-container-main_text-header"]}>
                                    <Link className = {styles["room-container-main_text-header-text"]} to={`/room/${item.id}`}>
                                        {item.header}
                                    </Link>
                                    <div className = {styles["room-container-main_text-header-mark"]}>
                                        {item.averageMark}
                                    </div>
                                </div>
                                <div className = {styles["room-container-main_text-location"]}>
                                    <div className={styles["room-container-main_text-location--city"]}>
                                        {item.city}
                                    </div>
                                    <div>
                                        {item.address}
                                    </div>
                                </div>
                                <div className={styles["room-container-room_info"]}>
                                    <div className={styles["room-container-room_params"]}>
                                        <div className={styles["room-container-room_params-header"]}>
                                            {item.numberOfRooms != 1 ? `${numberConverter(item.numberOfRooms)} rooms` : `${numberConverter(item.numberOfRooms)} room`} 
                                        </div>
                                        <div>
                                            <div>
                                                {item.numberOfFloors != 1 ? `${item.numberOfFloors} floors` : `${item.numberOfFloors} floor`}
                                            </div>
                                            <div>
                                                {item.isWiFiAvailable == true ? "WiFi Available" : "WiFi not available"}
                                            </div>
                                            <div>
                                                {item.isBathroomAvailable == true ? "Bathroom Available" : "Bathroom not available"} 
                                            </div>
                                        </div>
                                    </div>
                                    <div className={styles["room-container-room_info-cost"]}>
                                        {item.costPerDay} &euro;
                                    </div>
                                </div>
                                <div className={styles["room-container-main_text-availability_container"]}>
                                    <Link className={styles["room-container-main_text-availability_container-availability_button"]} to={`/room/${item.id}`}>See availability</Link>
                                </div>
                            </div>
                        </div>
                    ))
                }
            <div className = {styles["rooms_list-display_buttons"]}>
                <button className = {styles["rooms_list-display_buttons-previous"]} onClick={seePreviosrooms}>Previous</button>
                <button className = {styles["rooms_list-display_buttons-next"]} onClick={seeNextrooms}>Next</button>
            </div>
            </div>
        </div>
    )
}
export default HotelRentPage