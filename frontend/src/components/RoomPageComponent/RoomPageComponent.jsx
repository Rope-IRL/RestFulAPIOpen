import image from "../../assets/pictures/KCD.jpg";
import styles from "./RoomPageComponent.module.css";
import { Link } from "react-router-dom";

function RoomPageComponent({ property, propertyName, handleEditClick, handleDeleteClick }) {

  function numberConverter(number) {
      const numbers = {
        1: "One",
        2: "Two",
        3: "Three",
        4: "Four",
        5: "Five",
      };
  
      if (number in numbers) {
        return numbers[number];
      }
  
      return number;
    }
  
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
                  <Link
                    className={styles["property-container-main_text-header-text"]}
                    to={`/${propertyName}/${item.id}`}
                  >
                    {item.header}
                  </Link>
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
                    <div
                      className={
                        styles["property-container-property_params-header"]
                      }
                    >
                      {item.numberOfRooms != 1
                        ? `${numberConverter(item.numberOfRooms)} rooms`
                        : `${numberConverter(item.numberOfRooms)} room`}
                    </div>
                    <div>
                      <div>
                        {item.numberOfFloors != 1
                          ? `${item.numberOfFloors} floors`
                          : `${item.numberOfFloors} floor`}
                      </div>
                      <div>
                        {item.isWiFiAvailable == true
                          ? "WiFi Available"
                          : "WiFi not available"}
                      </div>
                      <div>
                        {item.isBathroomAvailable == true
                          ? "Bathroom Available"
                          : "Bathroom not available"}
                      </div>
                    </div>
                  </div>
                  <div className={styles["property-container-property_info-cost"]}>
                    {item.costPerDay} &euro;
                  </div>
                </div>
                <div
                  className={
                    styles["property-container-main_text-availability_container"]
                  }
                >
                  <Link
                    className={
                      styles[
                        "property-container-main_text-availability_container-availability_button"
                      ]
                    }
                    to={`/${propertyName}/${item.id}`}
                  >
                    See availability
                  </Link>
                </div>
              </div>
            </div>
              <div className = {styles["property-buttons-container"]}>
                <button
                  className = {styles["property-buttons-container-edit"]}
                  onClick = {() => {
                    handleEditClick(item, propertyName)
                  }} 
                >
                  Edit</button>
                <button
                  className = {styles["property-buttons-container-delete"]}
                  onClick = {() => {
                      handleDeleteClick(item, propertyName)
                    }
                  }
                >
                  Delete</button>
              </div>
          </div>
        ))}
      </div>
    );
}

export default RoomPageComponent;
