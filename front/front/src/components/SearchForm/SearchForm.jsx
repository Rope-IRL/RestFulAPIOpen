import styles from "./SearchForm.module.css"
import Calendar from "./Calendar/Calendar"

function SearchForm(){
    return(
        <div className={styles["form-wrapper"]}>
            <form className = {styles["form_container"]}>
                <input type="text" placeholder = "Where are you going ?" autoComplete="off" className={styles["form_container-city_input"]}/>
                <div className={styles["form_container-calendar_container"]}>
                    <button className={styles["form_container-calendar_container-start_date"]} type="button">Check-in Date</button>
                    <div className={styles.dash}>&mdash;</div>
                    <button className={styles["form_container-calendar_container-end_date"]} type="button">Check-out Date</button>
                </div>
                <button type="Submit" className = {styles["form_container-search_button"]}>Search</button>
            </form>
            <Calendar />
        </div>
    )
}
export default SearchForm