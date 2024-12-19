import { useState, useEffect } from "react"
import styles from "./BigImage.module.css"

function Image({style, propertyId, alt, propertyName}) {

    const [mainImage, setMainImage] = useState("")
    
    const getCurImage = async() => {
        try{
            const res = await fetch(`http://127.0.0.1:29180/api/${propertyName}image/${propertyName}images/${propertyId}`, {
                method : "GET",
                credentials : "include"
            })
    
            const data = await res.json()
            setMainImage(new URL(`../../assets/pictures/${propertyName}/${propertyId}/MainPicture/${data.bigImageName}`, import.meta.url).href)

        }
        catch(error){
            setMainImage(new URL("../../assets/pictures/KCD.jpg", import.meta.url).href)
        }
        
    }
    
    useEffect(() => {
        if (propertyId) {
            getCurImage();
        }
    }, [propertyId]);
    
    return (
        <img
            src = {mainImage} 
            alt = {alt}
            className={styles[style]}
        />
    )
}
export default Image