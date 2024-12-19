import {useParams} from "react-router-dom"
import { useState, useEffect } from "react";
import styles from "./SingleHousePage.module.css"
import RentProperty from "../../../components/RentProperty/RentProperty";
import BigPicture from "../../../assets/pictures/Hotel1.jpg"
import SmallPicture1 from "../../../assets/pictures/Hotel2.jpg"
import SmallPicture2 from "../../../assets/pictures/Hotel3.jpg"
import SmallImages from "../../../components/SmallImages/SmallImages";
import Image from "../../../components/BigImage/BigImage";

function SingleHousePage() {
    const {id} = useParams();
    const [contracts, setContracts] = useState([])
    const [house, sethouse] = useState(null)

    const fetchData = async () => {
        try {
            let res = await fetch(`http://127.0.0.1:29180/api/house/${id}`);
            if(!res.ok){
                throw new Error("Failed first fetch")
            }
            let item = await res.json()
            sethouse(item)
        }
        catch(error){
            console.error("Fetch failed, trying to back up")
            try{
                let res = await fetch(`http://127.0.0.1:29181/api/house/${id}`);
                if(!res.ok){
                    throw new Error("Failed second fetch")
                }
                let item = await res.json()
                sethouse(item)
                console.log(item)
            }
            catch(error){
                console.error("Fetch failed, trying to back up")  
            }
        };
    }

    useEffect(() =>{
        fetchData()
    }, [id]);


    return (
        <div className = {styles["house-info"]}>
            {
                house && (
                    <div key = {house.id} className = {styles["property-wrapper"]}>
                        <div className = {styles["house-container"]}>
                            <div className = {styles["house-container--upper-information"]}>
                                <div className = {styles["house-container--upper-information--header"]}>
                                    {house.header}
                                    <div className = {styles["house-container--upper-information--mark"]}>
                                        {house.averageMark}
                                    </div>
                                </div>
                                <div className = {styles["house-container--upper-information--location"]}>
                                    <div>
                                        {house.address}
                                    </div>
                                    <div>
                                        {house.city}
                                    </div>
                                </div>
                            </div>
                            <div className={styles["house-container-pictures"]}>
                                {/* <div>
                                    <div className={styles["house-container-small"]}>
                                        <img className={styles["house-container-small--small-picture"]} src={SmallPicture1} alt="Small picture 1" />
                                    </div>
                                    <div className={styles["house-container-small"]}>
                                        <img className={styles["house-container-small--small-picture"]} src={SmallPicture2} alt="Small picture 2" />
                                    </div>
                                </div> */}
                                 <SmallImages 
                                    alt = {`small images of rooms ${house.id}`}
                                    style = {"flat-container-small--small-picture"}
                                    propertyId={house.id}
                                    propertyName = "house"
                                />
                                <div className={styles["house-container-pictures-big"]}>
                                    {/* <img className= {styles["big--picture"]} src={BigPicture} alt="Big picture of hotel" /> */}
                                    <Image 
                                        alt = {`House${house.id}`} 
                                        style = {"big--picture"}
                                        propertyId={house.id}
                                        propertyName={"house"}
                                    />
                                </div>
                            </div>
                            <div className = {styles["house-container-description"]}>
                                {
                                    house.description.split(".").map(paragraph =>
                                        <div>
                                            {paragraph}
                                        </div>
                                    )
                                }
                            </div>
                            <div className = {styles["facilities-container"]}>
                                <div className = {styles["facilities-container--header"]}>Facilities</div>
                                <div className = {styles["facilities-container--body"]}>
                                    {house.isWiFiAvailable == true ? <div>WiFi <span className={styles["blue-text"]}>available</span></div> : <div>WiFi <span className={styles["blue-text"]}>not available</span></div>}
                                    {house.isBathroomAvailable == true ?  <div>Bathroom <span className={styles["blue-text"]}>available</span></div> : <div>Bathroom <span className={styles["blue-text"]}>not available</span></div>} 
                                </div>
                            </div>
                        </div>
                        <div>
                            <RentProperty property={house} propertyName={"house"}/>
                        </div>
                    </div>
                )
            }
        </div>
    )
}
export default SingleHousePage  