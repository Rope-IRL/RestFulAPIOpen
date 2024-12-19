import {useParams} from "react-router-dom"
import { useState, useEffect } from "react";
import styles from "./SingleFlatPage.module.css"
import RentProperty from "../../../components/RentProperty/RentProperty";
import BigPicture from "../../../assets/pictures/Hotel1.jpg"
import SmallPicture1 from "../../../assets/pictures/Hotel2.jpg"
import SmallPicture2 from "../../../assets/pictures/Hotel3.jpg"
import SmallImages from "../../../components/SmallImages/SmallImages";
import Image from "../../../components/BigImage/BigImage";

function SingleFlatPage() {
    const {id} = useParams();
    const [contracts, setContracts] = useState([])
    const [flat, setFlat] = useState(null)

    const fetchData = async () => {
        try {
            let res = await fetch(`http://127.0.0.1:29180/api/flat/${id}`);
            if(!res.ok){
                throw new Error("Failed first fetch")
            }
            let item = await res.json()
            setFlat(item)
        }
        catch(error){
            console.error("Fetch failed, trying to back up")
            try{
                let res = await fetch(`http://127.0.0.1:29181/api/flat/${id}`);
                if(!res.ok){
                    throw new Error("Failed second fetch")
                }
                let item = await res.json()
                setFlat(item)
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
        <div className = {styles["flat-info"]}>
            {
                flat && (
                    <div key = {flat.id} className = {styles["property-wrapper"]}>
                        <div className = {styles["flat-container"]}>
                            <div className = {styles["flat-container--upper-information"]}>
                                <div className = {styles["flat-container--upper-information--header"]}>
                                    {flat.header}
                                    <div className = {styles["flat-container--upper-information--mark"]}>
                                        {flat.averageMark}
                                    </div>
                                </div>
                                <div className = {styles["flat-container--upper-information--location"]}>
                                    <div>
                                        {flat.address}
                                    </div>
                                    <div>
                                        {flat.city}
                                    </div>
                                </div>
                            </div>
                            <div className={styles["flat-container-pictures"]}>
                                {/* <div>
                                    <div className={styles["flat-container-small"]}>
                                        <img className={styles["flat-container-small--small-picture"]} src={SmallPicture1} alt="Small picture 1" />
                                    </div>
                                    <div className={styles["flat-container-small"]}>
                                        <img className={styles["flat-container-small--small-picture"]} src={SmallPicture2} alt="Small picture 2" />
                                    </div>
                                </div> */}
                                <SmallImages 
                                    alt = {`small images of flat ${flat.id}`}
                                    style = {"flat-container-small--small-picture"}
                                    propertyId={flat.id}
                                    propertyName = "flat"
                                />
                                <div className={styles["flat-container-pictures-big"]}>
                                    {/* <img className= {styles["big--picture"]} src={BigPicture} alt="Big picture of room" /> */}
                                    <Image 
                                        alt = {`Flat${flat.id}`} 
                                        style = {"big--picture"}
                                        propertyId={flat.id}
                                        propertyName={"flat"}
                                    />
                                </div>
                            </div>
                            <div className = {styles["flat-container-description"]}>
                                {
                                    flat.description.split(".").map(paragraph =>
                                        <div>
                                            {paragraph}
                                        </div>
                                    )
                                }
                            </div>
                            <div className = {styles["facilities-container"]}>
                                <div className = {styles["facilities-container--header"]}>Facilities</div>
                                <div className = {styles["facilities-container--body"]}>
                                    {flat.isWiFiAvailable == true ? <div>WiFi <span className={styles["blue-text"]}>available</span></div> : <div>WiFi <span className={styles["blue-text"]}>not available</span></div>}
                                    {flat.isBathroomAvailable == true ?  <div>Bathroom <span className={styles["blue-text"]}>available</span></div> : <div>Bathroom <span className={styles["blue-text"]}>not available</span></div>} 
                                </div>
                            </div>
                        </div>
                        <div>
                            <RentProperty property={flat} propertyName={"flat"}/>
                        </div>
                    </div>
                )
            }
        </div>
    )
}
export default SingleFlatPage  