import { useState, useEffect } from "react"
import styles from "./SmallImages.module.css"

function SmallImages({style, propertyId, alt, propertyName}) {

    const [firstSmallImage, setFirstSmallImage] = useState("")
    const [secondSmallImage, setSecondSmallImage] = useState("")
    
    const getCurImage = async() => {
        try{
            const res = await fetch(`http://127.0.0.1:29180/api/${propertyName}image/${propertyName}images/${propertyId}`, {
                method : "GET",
                credentials : "include"
            })
    
            const data = await res.json()
            setFirstSmallImage(new URL(`../../assets/pictures/${propertyName}/${propertyId}/SmallPictures/${data.firstSmallImageName}`, import.meta.url).href)
            setSecondSmallImage(new URL(`../../assets/pictures/${propertyName}/${propertyId}/SmallPictures/${data.secondSmallImageName}`, import.meta.url).href)

        }
        catch(error){
            setFirstSmallImage(new URL("../../assets/pictures/Hotel2.jpg", import.meta.url).href)
            setSecondSmallImage(new URL("../../assets/pictures/Hotel3.jpg", import.meta.url).href)

        }
        
    }
    
    useEffect(() => {
        if (propertyId) {
            getCurImage();
        }
    }, [propertyId]);
    
    return (
        <div>
            <img
                src = {firstSmallImage} 
                alt = {alt}
                className={styles[style]}
            />
            <img
                src = {secondSmallImage} 
                alt = {alt}
                className={styles[style]}
            />
        </div>
    )
}
export default SmallImages