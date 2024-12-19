import image from "../../assets/pictures/KCD.jpg";
import styles from "./HotelPageComponent.module.css";
import RoomPageComponent from "../RoomPageComponent/RoomPageComponent";

function HotelPageComponent({ property, propertyName, 
  handleRoomEdit, handleRoomDelete, handleHotelEdit, handleHotelDelete}) {

  return (
    <div className={styles["property-wrapper"]}>
      {property.map((item) => (
         <div key={item.id}>
            <div key={item.id} className={styles["property-container"]}>
              <div className={styles["property-container-image_container"]}>
                <img
                  src={image}
                  alt="image"
                  className={styles["property-container-image_container-image"]}
                />
              </div>
              <div className={styles["property-container-main_text"]}>
                <div className={styles["property-container-main_text-header"]}>
                  <div
                    className={styles["property-container-main_text-header-text"]}
                  >
                    {item.header}
                  </div>
                  <div
                    className={styles["property-container-main_text-header-mark"]}
                  >
                    {item.averageMark}
                  </div>
                </div>
                <div className={styles["property-container-main_text-location"]}>
                  <div
                    className={
                      styles["property-container-main_text-location--city"]
                    }
                  >
                    {item.city}
                  </div>
                  <div>{item.address}</div>
                </div>
                <div className={styles["property-container-property_info"]}>
                  <div className={styles["property-container-property_params"]}>
                    <div>
                      <div>
                        {item.isRestraintAvailable == true
                          ? "Restraint Available"
                          : "Restraint not available"}
                      </div>
                      <div>
                        {item.isElevatorAvailable == true
                          ? "Elevator Available"
                          : "Elevator not available"}
                      </div>
                    </div>
                  </div>
                </div>
              </div>
          </div>
        <div className={styles["rooms-container"]}>
          <div className={styles["rooms-container-header"]}>Rooms</div>
          <RoomPageComponent property={item.hotelRooms} propertyName={"room"} 
            handleEditClick={handleRoomEdit} handleDeleteClick={handleRoomDelete} 
            />
        </div>
        </div>
      ))}
    </div>
  );
}

export default HotelPageComponent;
