import EditProperty from "../../components/EditProperty/EditProperty"
import { useState } from "react"
import { useNavigate } from "react-router-dom"

function AddProperty({propertyName}) {
    const [error, setError] = useState("")
    const navigate = useNavigate()
    const handleClick = async(id, header, description, city,
        address, numberOfRooms, numberOfFloors,
        isBathroomAvailable, isWiFiAvailable, costPerDay, llId) => {

        try{
            if(llId != null){
                const res = await fetch(`http://127.0.0.1:29180/api/${propertyName}`, {
                    method: "PUT",
                    headers: {
                        Accept:  "application/json",
                        "Content-type": "application/json"
                    },
                    credentials: "include",
                    body: JSON.stringify({
                        header: header,
                        description: description,
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
                navigate(-1)
            }
        }
        catch(error){
            setError("Something went wrong please try again")
        }

    }

    return (
        <div>
            <EditProperty title = {"Add"} propertyTitle={propertyName} handleClick = {handleClick}
                error = {error}/>
        </div>
    )
}
export default AddProperty