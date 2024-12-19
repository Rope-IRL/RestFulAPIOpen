import {useParams} from "react-router-dom"
import { useState, useEffect } from "react";
import styles from "./SingleRoomPage.module.css"
import RentProperty from "../../../components/RentProperty/RentProperty";
import BigPicture from "../../../assets/pictures/Hotel1.jpg"
import SmallPicture1 from "../../../assets/pictures/Hotel2.jpg"
import SmallPicture2 from "../../../assets/pictures/Hotel3.jpg"
import SmallImages from "../../../components/SmallImages/SmallImages";
import Image from "../../../components/BigImage/BigImage";

function SingleroomPage() {
    const {id} = useParams();
    const [room, setroom] = useState(null)

    const fetchData = async () => {
        try {
            let res = await fetch(`http://127.0.0.1:29180/api/room/${id}`);
            if(!res.ok){
                throw new Error("Failed first fetch")
            }
            let item = await res.json()
            setroom(item)
            getLandlord()
        }
        catch(error){
            console.error("Fetch failed, trying to back up")
            try{
                let res = await fetch(`http://127.0.0.1:29181/api/room/${id}`);
                if(!res.ok){
                    throw new Error("Failed second fetch")
                }
                let item = await res.json()
                setroom(item)
            }
            catch(error){
                console.error("Fetch failed, trying to back up")  
            }
        };
    }

    const getLandlord = async () => {
        const res = await fetch(`http://127.0.0.1:29180/api/roomContract/${id}`, {
            method:"GET",
            credentials:"include"
        });
        const data = await res.json()
        console.log(data)
        setroom((prevroom) => ({
            ...prevroom,
            llId: data.landlordId
        }))
    }

    useEffect(() =>{
        fetchData()
    }, [id]);


    return (
        <div className = {styles["room-info"]}>
            {
                room && (
                    <div key = {room.id} className = {styles["property-wrapper"]}>
                        <div className = {styles["room-container"]}>
                            <div className = {styles["room-container--upper-information"]}>
                                <div className = {styles["room-container--upper-information--header"]}>
                                    {room.header}
                                    <div className = {styles["room-container--upper-information--mark"]}>
                                        {room.averageMark}
                                    </div>
                                </div>
                                <div className = {styles["room-container--upper-information--location"]}>
                                    <div>
                                        {room.address}
                                    </div>
                                    <div>
                                        {room.city}
                                    </div>
                                </div>
                            </div>
                            <div className={styles["room-container-pictures"]}>
                                {/* <div>
                                    <div className={styles["room-container-small"]}>
                                        <img className={styles["room-container-small--small-picture"]} src={SmallPicture1} alt="Small picture 1" />
                                    </div>
                                    <div className={styles["room-container-small"]}>
                                        <img className={styles["room-container-small--small-picture"]} src={SmallPicture2} alt="Small picture 2" />
                                    </div>
                                </div> */}
                                <SmallImages 
                                    alt = {`small images of rooms ${room.id}`}
                                    style = {"flat-container-small--small-picture"}
                                    propertyId={room.id}
                                    propertyName = "room"
                                />
                                <div className={styles["room-container-pictures-big"]}>
                                    {/* <img className= {styles["big--picture"]} src={BigPicture} alt="Big picture of hotel" /> */}
                                     <Image 
                                        alt = {`Room${room.id}`} 
                                        style = {"big--picture"}
                                        propertyId={room.id}
                                        propertyName={"room"}
                                    />
                                </div>
                            </div>
                            <div className = {styles["room-container-description"]}>
                                {
                                    room.description.split(".").map(paragraph =>
                                        <div>
                                            {paragraph}
                                        </div>
                                    )
                                }
                            </div>
                            <div className = {styles["facilities-container"]}>
                                <div className = {styles["facilities-container--header"]}>Facilities</div>
                                <div className = {styles["facilities-container--body"]}>
                                    {room.isWiFiAvailable == true ? <div>WiFi <span className={styles["blue-text"]}>available</span></div> : <div>WiFi <span className={styles["blue-text"]}>not available</span></div>}
                                    {room.isBathroomAvailable == true ?  <div>Bathroom <span className={styles["blue-text"]}>available</span></div> : <div>Bathroom <span className={styles["blue-text"]}>not available</span></div>} 
                                </div>
                            </div>
                        </div>
                        <div>
                            <RentProperty property={room} propertyName={"room"}/>
                        </div>
                    </div>
                )
            }
        </div>
    )
}
export default SingleroomPage  