import EditSelfInformation from "../../../components/EditSelfInformation/EditSelfInformation";
import { useNavigate } from "react-router-dom";
import { useAuthUser } from "../../../hooks/useAuthUser";

function EditLessee({ lessee }) {

  const {id} = useAuthUser()

  let navigate = useNavigate();
  async function changeSelfInformation(
    name,
    surname,
    telephone,
    passport,
    birthday,
    isNew
  ) {

    if(lessee.id != undefined){
      const res = await fetch(
        "http://127.0.0.1:29180/api/LesseeAdditionalInfo",
        {
          method: isNew == false ? "POST" : "PUT",
          body: JSON.stringify({
            id: lessee.id,
            name: name,
            surname: surname,
            telephone: telephone,
            passportId: passport,
            birthDate: birthday,
            averageMark: lessee.averageMark,
            lesseeId: id,
          }),
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
          },
          credentials: "include",
        },
      );
    }
    else{
      const res = await fetch(
        "http://127.0.0.1:29180/api/LesseeAdditionalInfo",
        {
          method: isNew == false ? "POST" : "PUT",
          body: JSON.stringify({
            name: name,
            surname: surname,
            telephone: telephone,
            passportId: passport,
            birthDate: birthday,
            averageMark: lessee.averageMark,
            lesseeId: id,
          }),
          headers: {
            Accept: "application/json",
            "Content-Type": "application/json",
          },
          credentials: "include",
        },
      );
    }
    navigate(0);
  }
  return (
    <EditSelfInformation
      title={"Edit"}
      handleClick={changeSelfInformation}
      user={lessee}
    />
  );
}

export default EditLessee;
