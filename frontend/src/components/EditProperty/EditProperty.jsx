import { useState } from "react"
import { useAuthUser } from "../../hooks/useAuthUser"
import Error from "../Error/Error"
import styles from "./EditProperty.module.css"

function EditProperty({ property, title, propertyTitle, handleClick, error }) {
    const {id} = useAuthUser()

    const [propertyId, setPropertyId] = property == null ? 
        useState(0) : useState(property.id)
    const [header, setHeader] = property == null ? 
        useState("") : useState(property.header)
    const [description, setDescription] = property == null ? 
        useState("") : useState(property.description)
    const [city, setCity] = property == null ? 
        useState("") : useState(property.city)
    const [address, setAddress] = property == null ? 
        useState("") : useState(property.address)
    const [numberOfRooms, setNumberOfRooms] = property == null ? 
        useState(1) : useState(property.numberOfRooms)
    const [numberOfFloors, setNumberOfFloors] = property == null ? 
        useState(1) : useState(property.numberOfFloors)
    const [isBathroomAvailable, setIsBathroomAvailable] = property == null ? 
        useState(false) : useState(property.isBathroomAvailable)
    const [isWiFiAvailable, setIsWiFiAvailable] = property == null ? 
        useState(false) : useState(property.isWiFiAvailable)
    const [costPerDay, setCostPerDay] = property == null ? 
    useState(0) : useState(property.costPerDay)
    
    return (
        <div className={styles["edit-property-container"]}>
            <div
                className = {styles["edit-property-header"]}
            >
                {title} {propertyTitle}
            </div>
            <Error error = {error} />
            <form className = {styles["input-container"]}>
                <div className = {styles["input-wrapper"]}>
                    <div className = {styles["input-wrapper--header"]}>
                        Header
                    </div>
                    <input
                        className = {styles["input-wrapper--input"]}
                        type="text"
                        value = {header}
                        onChange={(e) => {
                            setHeader(e.target.value)
                        }} 
                        placeholder="Header"
                    />
                </div>
                <div className = {styles["input-wrapper"]}>
                    <div className = {styles["input-wrapper--header"]}>
                        Description
                    </div>
                    <input
                        className = {styles["input-wrapper--input"]}
                        type="text"
                        value = {description}
                        onChange={(e) => {
                            setDescription(e.target.value)
                        }} 
                        placeholder="Description"
                    />
                </div>
                <div className = {styles["input-wrapper"]}>
                    <div className = {styles["input-wrapper--header"]}>
                        City
                    </div>
                    <input
                        className = {styles["input-wrapper--input"]}
                        type="text"
                        value = {city}
                        onChange={(e) => {
                            setCity(e.target.value)
                        }} 
                        placeholder="City"
                    />
                </div>
                <div className = {styles["input-wrapper"]}>
                    <div className = {styles["input-wrapper--header"]}>
                        Address
                    </div>
                    <input
                        className = {styles["input-wrapper--input"]}
                        type="text"
                        value = {address}
                        onChange={(e) => {
                            setAddress(e.target.value)
                        }} 
                        placeholder="Address"
                    />
                </div>
                <div className = {styles["input-wrapper"]}>
                    <div className = {styles["input-wrapper--header"]}>
                        Number of rooms
                    </div>
                    <input
                        className = {styles["input-wrapper--input"]}
                        type="text"
                        value = {numberOfRooms}
                        onChange={(e) => {
                            setNumberOfRooms(e.target.value)
                        }} 
                        placeholder="Number of rooms"
                    />
                </div>
                <div className = {styles["input-wrapper"]}>
                    <div className = {styles["input-wrapper--header"]}>
                        Number of floors
                    </div>
                    <input
                        className = {styles["input-wrapper--input"]}
                        type="text"
                        value = {numberOfFloors}
                        onChange={(e) => {
                            setNumberOfFloors(e.target.value)
                        }} 
                        placeholder="Number of floors"
                    />
                </div>
                <div className = {styles["available-facilities"]}>
                    <div className = {styles["facility-container"]}>
                        <div className = {styles["facility-container-header"]}>
                            Bathroom available ?
                        </div>
                        <input
                            // className = {styles["facility-container-input"]}
                            type="checkbox"
                            checked = {isBathroomAvailable == true ? "checked" : ""}
                            onChange={(e) => {
                                setIsBathroomAvailable(e.target.checked)
                            }} 
                        />
                    </div>
                    <div className = {styles["facility-container"]}>
                        <div className = {styles["facility-container-header"]}>
                            WiFi available ?
                        </div>
                        <input
                            // className = {styles["auth-form__input"]}
                            type="checkbox"
                            checked = {isWiFiAvailable == true ? "checked" : ""}
                            onChange={(e) => {
                                setIsWiFiAvailable(e.target.checked)
                            }} 
                        />
                    </div>
                </div>
                <div className = {styles["input-wrapper"]}>
                    <div className = {styles["input-wrapper--header"]}>
                        Cost per day
                    </div>
                    <input
                        className = {styles["input-wrapper--input"]}
                        type="text"
                        value = {costPerDay}
                        onChange={(e) => {
                            setCostPerDay(e.target.value)
                        }} 
                        placeholder="Cost per day"
                    />
                </div>
                <button
                    className = {styles["handle-button"]}
                    onClick = {(e) => {
                        e.preventDefault();
                        handleClick(propertyId, header, description, city,
                        address, numberOfRooms, numberOfFloors,
                        isBathroomAvailable, isWiFiAvailable, costPerDay, id)
                    }
                    }
                >
                    {title}
                </button>
            </form>
        </div>
    )
}
export default EditProperty