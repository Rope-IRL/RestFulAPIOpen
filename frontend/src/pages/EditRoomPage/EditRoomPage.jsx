import { useState } from "react"
import { useNavigate } from "react-router-dom"
import EditRoom from "../../components/EditRoom/EditRoom"

function EditRoomPage({property, propertyName}) {
    const [error, setError] = useState("")
    const navigate = useNavigate()
    const handleClick = async(id, header, description, numberOfRooms, numberOfFloors,
        isBathroomAvailable, isWiFiAvailable, costPerDay) => {

        try{
            const res = await fetch(`http://127.0.0.1:29180/api/${propertyName}`, {
                method: "POST",
                headers: {
                    Accept:  "application/json",
                    "Content-type": "application/json"
                },
                credentials: "include",
                body: JSON.stringify({
                    id: id,
                    header: header,
                    description: description,
                    averageMark: property.averageMark,
                    numberOfRooms: numberOfRooms,
                    numberOfFloors: numberOfFloors,
                    isBathroomAvailable: isBathroomAvailable,
                    isWiFiAvailable: isWiFiAvailable,
                    costPerDay: costPerDay,
                    hotelId: property.hotelId
                })
            })

            let datares = await res;
            navigate(0)
        }
        catch(error){
            setError("Something went wrong please try again")
        }

    }

    return (
        <div>
            <EditRoom title = {"Edit"} propertyTitle={propertyName} handleClick = {handleClick}
                error = {error} property = {property}/>
        </div>
    )
}
export default EditRoomPage