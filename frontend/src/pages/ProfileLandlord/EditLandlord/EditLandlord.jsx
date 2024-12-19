import EditSelfInformation from "../../../components/EditSelfInformation/EditSelfInformation";
import { useNavigate } from "react-router-dom";

function EditLandlord({ landlord }) {
  let navigate = useNavigate();

  async function changeSelfInformation(
    name,
    surname,
    telephone,
    passport,
    birthday,
    isNew
  ) {
    const res = await fetch(
      "http://127.0.0.1:29180/api/LandlordAdditionalInfo",
      {
        method: isNew == false ? "POST" : "PUT",
        body: JSON.stringify({
          id: landlord.id,
          name: name,
          surname: surname,
          telephone: telephone,
          passportId: passport,
          birthDate: birthday,
          averageMark: landlord.averageMark,
          landlordId: landlord.landlordId,
        }),
        headers: {
          Accept: "application/json",
          "Content-Type": "application/json",
        },
        credentials: "include",
      },
    );
    navigate(0);
  }
  return (
    <EditSelfInformation
      title={"Edit"}
      handleClick={changeSelfInformation}
      user={landlord}
    />
  );
}

export default EditLandlord;
