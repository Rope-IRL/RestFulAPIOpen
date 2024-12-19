import { useState } from "react";
import { NavLink, Link, useNavigate } from "react-router-dom";
import styles from "./Header.module.css";
import { useAuthUser } from "../../hooks/useAuthUser";
import { removeUser } from "../../store/slices/userSlice";
import { useDispatch } from "react-redux";
import userIcon from "../../assets/pictures/UserIcon.png";

function Header() {
  const navigate = useNavigate()
  let dispatch = useDispatch()
  const { isAuth, name, role, loading } = useAuthUser();
  const headerPosition = isAuth == true ? styles["header-navigation-center"] : styles["header-navigation"]
  const setActive = ({ isActive }) =>
    isActive
      ? styles["header-links-navigation-active-link"]
      : styles["header-links-navigation-link"];

  if (loading) {
    return <div>Loading...</div>;
  }

  const exitUser = async () => 
  {
    try{

      const res = await fetch(`http://127.0.0.1:29180/api/${role}/logout`, {
        method:"GET",
        credentials:"include"
      })
      navigate(0)
      dispatch(removeUser())
    }
    catch(error)
    {

    }
  }

  return (
    <header>
      <nav className={headerPosition}>
        <div className={styles["header-navigation-links"]}>
          <div className={styles["header-navigation-links-element"]}>
            <NavLink to="/" className={setActive}>
              Main
            </NavLink>
          </div>
          <div className={styles["header-navigation-links-element"]}>
            <NavLink to="/flats" className={setActive}>
              Flats
            </NavLink>
          </div>
          <div className={styles["header-navigation-links-element"]}>
            <NavLink to="/houses" className={setActive}>
              Houses
            </NavLink>
          </div>
          <div className={styles["header-navigation-links-element"]}>
            <NavLink to="/hotels" className={setActive}>
              Hotels
            </NavLink>
          </div>
        </div>
      </nav>
      {!isAuth ? (
        <div className={styles["header-auth_buttons"]}>
          <div>
            <Link
              to="/login/landlord"
              className={styles["header-auth_buttons-landlord-link"]}
            >
              Add your property or Sign in ?
            </Link>
          </div>
          <div className={styles["header-auth_buttons-lessee"]}>
            <div>
              <Link
                to="/register/lessee"
                className={styles["header-auth_buttons-lessee-link"]}
              >
                Register
              </Link>
            </div>
            <div>
              <Link
                to="login/lessee"
                className={styles["header-auth_buttons-lessee-link"]}
              >
                Sign in
              </Link>
            </div>
          </div>
        </div>
      ) : (
        <div className = {styles["user-container"]}>
          <Link to={`/profile/${role}`} className={styles["user-link"]}>
            <img className={styles["user-icon"]} src={userIcon} alt="" />
          </Link>
          <button className = {styles["exit-button"]} onClick = {exitUser}>Exit</button>
        </div>
      )}
    </header>
  );
}

export default Header;
