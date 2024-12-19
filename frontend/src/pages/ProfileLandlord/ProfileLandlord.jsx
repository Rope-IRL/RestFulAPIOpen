import { useState, useEffect } from "react";
import { Link, Navigate, useNavigate } from "react-router-dom";
import { useAuthUser } from "../../hooks/useAuthUser";
import styles from "./ProfileLandlord.module.css";
import UserProfile from "../../components/UserProfile/UserProfile";
import LandlordProperty from "../../components/LandlordProperty/LandlordProperty";
import EditLandlord from "./EditLandlord/EditLandlord";
import { useDispatch } from "react-redux";
import { removeUser } from "../../store/slices/userSlice";
import AvailableLandlordContracts from "../AvailableLandlordContracts/AvailableLandlordContracts";

function ProfileLandlord() {
  const dispatch = useDispatch()
  const navigate = useNavigate()
  const [landlord, setLandlord] = useState({});
  const [curTab, setCurTab] = useState(0);
  const { isAuth, id } = useAuthUser();
  const getLandlord = async () => {
    try {
      if (id != null) {
        let res = await fetch(
          `http://127.0.0.1:29180/api/LandLordAdditionalInfo/${id}`,
          {
            headers: {
              Accept: "application/json",
              "Content-Type": "application/json",
            },
            credentials: "include",
          },
        );
        const data = await res.json();
        setLandlord(data);
      }
    } catch (error) {
      console.log(error);
    }
  };

  const removeLandlord = async () => {
    try{
      if(id!= null){
        let res = await fetch(`http://127.0.0.1:29180/api/landlord/${id}`, {
          method:"DELETE",
          credentials:"include",
        })
        sessionStorage.removeItem("userRole")
        dispatch(removeUser())
        navigate("/")
      }
    }
    catch(error){

    }
  }

  function getCurTab(landlord) {
    switch (curTab) {
      case 0:
        return (
          <div className={styles["landlord-container-all-information"]}>
            <UserProfile user={landlord} />
            <div className={styles["landlord-container-editing"]}>
              <button
                onClick={() => setCurTab(2)}
                className={styles["landlord-container-editing-edit"]}
              >
                Edit
              </button>
              <button className={styles["landlord-container-editing-delete"]} onClick = {() => removeLandlord()}>
                Delete profile
              </button>
            </div>
          </div>
        );
      case 1:
        return <LandlordProperty />;
      case 2:
        return <EditLandlord landlord={landlord} />;
      case 3:
        return <AvailableLandlordContracts />
    }
  }

  useEffect(() => {
    getLandlord();
  }, []);

  if (isAuth == false) {
    return <Navigate to="/login/landlord" />;
  }

  return (
    <div className={styles["landlord-container"]}>
      {landlord && (
        <div className={styles["user-info"]}>
          <div className={styles["your-choice"]}>
            <div className={styles["choice-header"]}>Tabs</div>
            <button
              className={styles["choice-button"]}
              onClick={() => {
                setCurTab(0);
              }}
            >
              Your information
            </button>
            <button
              className={styles["choice-button"]}
              onClick={() => setCurTab(1)}
            >
              Your property
            </button>
            <button
              className={styles["choice-button"]}
              onClick={() => setCurTab(3)}
            >
              Your contracts
            </button>
          </div>
          {getCurTab(landlord)}
        </div>
      )}
    </div>
  );
}
export default ProfileLandlord;
