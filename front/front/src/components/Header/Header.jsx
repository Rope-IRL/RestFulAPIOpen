import { useState } from "react"
import {NavLink, Link} from "react-router-dom"
import styles from "./Header.module.css"

function Header(){
    const setActive = ({isActive}) => isActive ? styles["header-links-navigation-active-link"] : styles["header-links-navigation-link"]
    return(
        <header>
            <nav className={styles["header-navigation"]}>
                <div className={styles["header-navigation-links"]}>
                    <div className={styles["header-navigation-links-element"]}>
                        <NavLink to = "/" className={setActive}>Main</NavLink>
                    </div>
                    <div className={styles["header-navigation-links-element"]}>
                        <NavLink to = "/flats" className={setActive}>Flats</NavLink>
                    </div>
                    <div className={styles["header-navigation-links-element"]}>
                        <NavLink to = "/houses" className={setActive}>Houses</NavLink>
                    </div>
                    <div className={styles["header-navigation-links-element"]}>
                        <NavLink to = "/hotels" className={setActive}>Hotels</NavLink>
                    </div>
                </div>
            </nav>
            <div className={styles["header-auth_buttons"]}>
                <div>
                    <Link to = "#" className={styles["header-auth_buttons-landlord-link"]}>
                        Add your property
                    </Link>
                </div>
                <div className={styles["header-auth_buttons-lessee"]}>
                    <div>
                        <Link to = "#" className={styles["header-auth_buttons-lessee-link"]}>
                            Register
                        </Link>
                    </div>
                    <div>
                        <Link to = "#" className={styles["header-auth_buttons-lessee-link"]}>
                            Sign in
                        </Link>
                    </div>
                </div>
            </div>
        </header>
    )
}

export default Header
