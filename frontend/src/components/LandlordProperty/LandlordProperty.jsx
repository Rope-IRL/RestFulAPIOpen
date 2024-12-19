import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import styles from "./LandlordProperty.module.css";
import PropertyPageComponent from "../PropertyPageComponent/PropertyPageComponent";
import AddProperty from "../../pages/AddProperty/AddProperty";
import EditPropertyPage from "../../pages/EditProperty/EditPropertyPage";
import HotelPageComponent from "../HotelPageComponent/HotelPageComponent";
import EditRoomPage from "../../pages/EditRoomPage/EditRoomPage";


function LandlordProperty() {
  const navigate = useNavigate()

  const [curTab, setCurTab] = useState(1)
  const [curProperty, setCurProperty] = useState(null)
  const [curPropertyName, setCurPropertyName] = useState(null)

  const [flats, setFlats] = useState([]);
  const [houses, setHouses] = useState([]);
  const [hotels, setHotels] = useState([]);

  const handleEditProperty = (item, propertyName) =>{
    setCurTab(3)
    setCurProperty(item)
    setCurPropertyName(propertyName)
  }

  const handleDeleteProperty = async(item, propertyName) => {
    try{
      const res = await fetch(`http://127.0.0.1:29180/api/${propertyName}/${item.id}`, {
        method: "DELETE",
        credentials: "include"
      })
      navigate(0)
    }
    catch(error){

    }
  }

  const handleEditRoom = (item, propertyName) => {
    setCurTab(4)
    setCurProperty(item)
    setCurPropertyName(propertyName)
  }

  const showCurTab = () => {
    switch(curTab){
      case 1:
        return <div className={styles["property-wrapper"]}>
          <div className={styles["property-container"]}>
            <div className = {styles["header-container"]}>
              <div className={styles["property-container-header"]}>Flats</div>
              <button 
                className = {styles["header-container--add"]}
                onClick = {() => {
                  setCurPropertyName("flat")
                  setCurTab(2)}
                }
              >
                  Add</button>
            </div>
            <div>
              <PropertyPageComponent property={flats} propertyName={"flat"} 
                handleEditClick={handleEditProperty} handleDeleteClick={handleDeleteProperty} />
            </div>
          </div>
          <div className={styles["property-container"]}>
            <div className = {styles["header-container"]}>
              <div className={styles["property-container-header"]}>Houses</div>
              <button 
                className = {styles["header-container--add"]}
                onClick = {() => {
                  setCurPropertyName("house")
                  setCurTab(2)}
                }
              >
                  Add</button>
            </div>
              <PropertyPageComponent property={houses} propertyName={"house"} 
                handleEditClick={handleEditProperty} handleDeleteClick={handleDeleteProperty} />
          </div>
          <div className={styles["property-container"]}>
            <div className = {styles["header-container"]}>
              <div className={styles["property-container-header"]}>Hotels</div>
            </div>
              <HotelPageComponent property={hotels}  propertyName = {"hotel"} handleRoomEdit = {handleEditRoom}
                handleRoomDelete={handleDeleteProperty}
              />

          </div>
      </div>
      case 2:
        return <div>
          <button
            className = {styles["back-button"]}
            onClick = {() => {
              setCurTab(1)
            }}
          >Go back</button>
          <AddProperty propertyName={curPropertyName}/>
        </div> 
      case 3:
        return <div>
        <button
          className = {styles["back-button"]}
          onClick = {() => {
            setCurTab(1)
          }}
        >Go back</button>
        <EditPropertyPage propertyName={curPropertyName} property={curProperty}/>
      </div>
      case 4:
        return <div>
        <button
          className = {styles["back-button"]}
          onClick = {() => {
            setCurTab(1)
          }}
        >Go back</button>
        <EditRoomPage propertyName={curPropertyName} property={curProperty}/>
      </div>
      default:
        return <div>
          <button
          className = {styles["back-button"]}
          onClick = {() => {
            setCurTab(1)
          }}
        >Go back ?</button>
          <div>Loading...</div>
        </div> 
    }
  }

  const getLandlordsProperty = async () => {
    let preFlats = await fetch("http://127.0.0.1:29180/api/flat/landlord", {
      method: "GET",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      credentials: "include",
    });

    let preHouses = await fetch("http://127.0.0.1:29180/api/house/landlord", {
      method: "GET",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      credentials: "include",
    });

    let preHotels = await fetch("http://127.0.0.1:29180/api/hotel/landlord", {
      method: "GET",
      headers: {
        Accept: "application/json",
        "Content-Type": "application/json",
      },
      credentials: "include",
    });

    let flats = await preFlats.json();
    let houses = await preHouses.json();
    let hotels = await preHotels.json();
    setFlats(flats);
    setHotels(hotels);
    setHouses(houses);
  };

  useEffect(() => {
    getLandlordsProperty();
  }, []);

  return (
    <div className={styles["property-wrapper"]}>
      {
        showCurTab()
      }
    </div>

  );
}

export default LandlordProperty;
