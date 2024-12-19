import {useState} from "react"
import styles from "./SearchForm.module.css"
import Calendar from "../Calendar/Calendar"

function SearchForm({handleSearchClick}){

    
    const [curMonth, setCurMonth] = useState(new Date().getMonth())
    const[curYear, setCurYear] = useState(new Date().getFullYear())
    const [nextMonth, setNextMonth] = useState(new Date().getMonth() + 1 > 11 ? 0 : new Date().getMonth() + 1)
    const[nextYear, setNextYear] = useState(new Date().getMonth() + 1 > 11 ? new Date().getFullYear() + 1 : new Date().getFullYear())
    
    const [visibility, setVisibility] = useState(false)
    const isVisible = visibility == true ? "calendar-wrapper" : "invisible"
    
    const [clickedDatesNumber, setClickedDateNumber] = useState(0)
    const [startDate, setStartDate] = useState(null)
    const [endDate, setEndDate] = useState(null)
    const [city, setCity] = useState("")

    const handleDateClick = (clickedDate) => {
        if(startDate == null)
        {
          setStartDate(clickedDate)
        }
        else{
          if(startDate > clickedDate)
          {
            let temp = clickedDate
            setEndDate(startDate)
            setStartDate(temp)
          }
          else{
            setEndDate(clickedDate)
          }
        }
    
        setClickedDateNumber(prevState => {
            if(prevState + 1 > 2)
            {
                return 1
            }
            return prevState + 1
        })
    }

    const changeVisibility = () => {
        setVisibility(prevState => {
            return !prevState
        })
    }

    // const handleSearchClick = async() => {
    //     const res = await fetch(`http://127.0.0.1:29180/api/flat/filter/${startDate}/${endDate}`,{
    //         method: "GET",
    //         credentials: "include",
    //         headers: {
    //             Accept: "application/json",
    //             "Content-Type": "application/json",
    //         },
    //     })

    //     const data = await res.json()
    // }

    return(
        <div className={styles["form-wrapper"]}>
            <form className = {styles["form_container"]}>
                <input 
                    type="text" 
                    placeholder = "Where are you going ?" 
                    autoComplete="off" 
                    className={styles["form_container-city_input"]}
                    onChange={(e) => [
                        setCity(e.target.value)
                    ]}
                />
                <div className={styles["form_container-calendar_container"]}>
                    <button 
                        className={styles["form_container-calendar_container-start_date"]} 
                        type="button"
                        onClick = {() => {
                            changeVisibility()
                        }}
                        >Check-in Date</button>
                    <div className={styles.dash}>&mdash;</div>
                    <button 
                        className={styles["form_container-calendar_container-end_date"]}
                        type="button"
                        onClick = {() => {
                            changeVisibility()
                        }}
                        >Check-out Date</button>
                </div>
                <button 
                    type="button" 
                    className = {styles["form_container-search_button"]}
                    onClick={() => {
                        handleSearchClick(startDate, endDate, city)
                    }}
                >Search</button>
            </form>
            <div className = {styles[isVisible]}>
                <div className= {styles["calendar-wrapper-container"]}>
                    <Calendar month = {curMonth} year ={curYear} clickedDatesNumber={clickedDatesNumber} handleDateClick = {handleDateClick} />
                    <Calendar month = {nextMonth} year ={nextYear} clickedDatesNumber={clickedDatesNumber} handleDateClick = {handleDateClick} />
                </div>
            </div>
        </div>
    )
}
export default SearchForm