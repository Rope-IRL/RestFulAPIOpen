import EditProperty from "../../components/EditProperty/EditProperty"
import { useState } from "react"
import { useNavigate } from "react-router-dom"


function EditPropertyPage({property, propertyName}) {
    const [error, setError] = useState("")
    const navigate = useNavigate()
    const handleClick = async(id, header, description, city,
        address, numberOfRooms, numberOfFloors,
        isBathroomAvailable, isWiFiAvailable, costPerDay, llId) => {

        try{
            if(llId != null){
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
                        city:city,
                        address: address,
                        numberOfRooms: numberOfRooms,
                        numberOfFloors: numberOfFloors,
                        isBathroomAvailable: isBathroomAvailable,
                        isWiFiAvailable: isWiFiAvailable,
                        costPerDay: costPerDay,
                        llId: llId
                    })
                })
    
                let datares = await res;
                navigate(0)
            }
        }
        catch(error){
            setError("Something went wrong please try again")
        }

    }

    return (
        <div>
            <EditProperty title = {"Edit"} propertyTitle={propertyName} handleClick = {handleClick}
                error = {error} property = {property}/>
        </div>
    )
}
export default EditPropertyPage