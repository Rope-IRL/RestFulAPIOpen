import { useState } from "react";
import Error from "../Error/Error";
import styles from "./EditSelfInformation.module.css"

function EditSelfInformation({ title, handleClick, user }) {
  const [error, setError] = useState("");

  const [name, setName] = useState(user.name == null ? "" : user.name);
  const [surname, setSurname] = useState(
    user.surname == null ? "" : user.surname,
  );
  const [telephone, setTelephone] = useState(
    user.telephone == null ? "" : user.telephone,
  );
  const [passport, setPassport] = useState(
    user.passportId == null ? "" : user.passportId,
  );
  const [birthday, setBirthday] = useState(
    user.birthDate == null ? "" : user.birthDate,
  );

  const usersDay = birthday.split("-")[2] == null ? 1 : birthday.split("-")[2];
  const usersMonth =
    birthday.split("-")[1] == null ? 1 : birthday.split("-")[1];
  const usersYear =
    birthday.split("-")[0] == null
      ? new Date().getFullYear()
      : birthday.split("-")[0];

  const [day, setDay] = useState(usersDay);
  const [month, setMonth] = useState(usersMonth);
  const [year, setYear] = useState(usersYear);

  const handleDateSubmit = () => {
    const minDay = 1;
    if (Number(month) < 1 || Number(month) > 12) {
      return "Wrong month number";
    }
    const maxDay = new Date(year, month, 0).getDate();
    if (Number(day) < minDay || Number(day) > maxDay) {
      return "Wrong day number";
    }

    return "";
  };

  const handleSubmit = () => {
    const error = handleDateSubmit();
    setError(error);
    if (error == "") {
      if(user.surname == null){
        handleClick(
          name,
          surname,
          telephone,
          passport,
          new Date(`${month}-${Number(day) + 1}-${year}`)
            .toISOString()
            .split("T")[0],
          true
        );
      }
      handleClick(
        name,
        surname,
        telephone,
        passport,
        new Date(`${month}-${Number(day) + 1}-${year}`)
          .toISOString()
          .split("T")[0],
        false
      );
    }
  };

  return (
    <div className = {styles["edit-self-info"]}>
      <Error error={error} />
      <form className = {styles["user-inputs"]}>
        <div className = {styles["user-inputs--container"]}>
          <div className = {styles["container--header"]}>
            Edit name
          </div>
          <input
            className = {styles["container--input"]}
            type="text"
            value={name}
            onChange={(e) => {
              setName(e.target.value);
            }}
            placeholder="Name"
          />
        </div>

        <div className = {styles["user-inputs--container"]}>
          <div className = {styles["container--header"]}>
            Edit Surname
          </div>
          <input
          className = {styles["container--input"]}
            type="text"
            value={surname}
            onChange={(e) => {
              setSurname(e.target.value);
            }}
            placeholder="Surname"
          />
        </div>

        <div className = {styles["user-inputs--container"]}>
          <div className = {styles["container--header"]}>
              Edit Telephone
          </div>
          <input
            className = {styles["container--input"]}
            type="text"
            value={telephone}
            onChange={(e) => {
              setTelephone(e.target.value);
            }}
            placeholder="Telephone"
          />
        </div>

        <div className = {styles["user-inputs--container"]}>
          <div className = {styles["container--header"]}>
            Edit Passport
          </div>
          <input
            className = {styles["container--input"]}
            type="text"
            value={passport}
            onChange={(e) => {
              setPassport(e.target.value);
            }}
            placeholder="Passport"
          />
        </div>

        <div className = {styles["user-inputs--container"]}>
          <div className = {styles["container--header"]}>
            Edit BirthDay
          </div>
          <input
            className = {styles["container--input"]}
            type="text"
            value={day}
            onChange={(e) => {
              setDay(e.target.value);
            }}
            placeholder="Birth day"
          />
        </div>
        
        <div className = {styles["user-inputs--container"]}>
          <div className = {styles["container--header"]}> 
            Edit month
          </div>
          <input
            className = {styles["container--input"]}
            type="text"
            value={month}
            onChange={(e) => {
              setMonth(e.target.value);
            }}
            placeholder="Birth month"
          />
        </div>

        <div className = {styles["user-inputs--container"]}>
          <div className = {styles["container--header"]}>
            Edit Year
          </div>
          <input
            className = {styles["container--input"]}
            type="text"
            value={year}
            onChange={(e) => {
              setYear(e.target.value);
            }}
            placeholder="Birth year"
          />
        </div>

        <button
          className = {styles["edit-button"]}
          onClick={(e) => {
            e.preventDefault();
            handleSubmit();
          }}
        >
          {title}
        </button>
      </form>
    </div>
  );
}

export default EditSelfInformation;
