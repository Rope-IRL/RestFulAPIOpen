import { useState, useEffect } from "react";
import { Link, Navigate, useNavigate } from "react-router-dom";
import { useAuthUser } from "../../hooks/useAuthUser";
import styles from "./ProfileLessee.module.css";
import UserProfile from "../../components/UserProfile/UserProfile";
import EditLessee from "./EditLessee/EditLessee";
import { useDispatch } from "react-redux";
import { removeUser } from "../../store/slices/userSlice";
import AvailableLesseeContracts from "../AvailableLesseeContracts/AvailableLesseeContracts";

function ProfileLessee() {
  const dispatch = useDispatch()
  const navigate = useNavigate()
  const [lessee, setlessee] = useState({});
  const [curTab, setCurTab] = useState(0);
  const { isAuth, id } = useAuthUser();
  const getlessee = async () => {
    try {
      if (id != null) {
        let res = await fetch(
          `http://127.0.0.1:29180/api/lesseeAdditionalInfo/${id}`,
          {
            headers: {
              Accept: "application/json",
              "Content-Type": "application/json",
            },
            credentials: "include",
          }
        );
    
        if (res.ok) {
          const data = await res.json();
          setlessee(data);
        }
    
      }
    } catch (error) {
      console.error('Error fetching lessee additional info:', error);
    }
    
  };

  const removelessee = async () => {
    try{
      if(id!= null){
        let res = await fetch(`http://127.0.0.1:29180/api/lessee/${id}`, {
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

  function getCurTab(lessee) {
    switch (curTab) {
      case 0:
        return (
          <div className={styles["lessee-container-all-information"]}>
            <UserProfile user={lessee} />
            <div className={styles["lessee-container-editing"]}>
              <button
                onClick={() => setCurTab(2)}
                className={styles["lessee-container-editing-edit"]}
              >
                Edit
              </button>
              <button className={styles["lessee-container-editing-delete"]} onClick = {() => removelessee()}>
                Delete profile
              </button>
            </div>
          </div>
        );
      case 2:
        return <EditLessee lessee={lessee} />;
      case 3:
        return <AvailableLesseeContracts />
    }
  }

  useEffect(() => {
    getlessee();
  }, []);

  if (isAuth == false) {
    return <Navigate to="/login/lessee" />;
  }

  return (
    <div className={styles["lessee-container"]}>
      {lessee && (
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
              onClick={() => setCurTab(3)}
            >
              Your contracts
            </button>
          </div>
          {getCurTab(lessee)}
        </div>
      )}
    </div>
  );
}
export default ProfileLessee;
