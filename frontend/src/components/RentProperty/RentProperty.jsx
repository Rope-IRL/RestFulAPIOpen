import {useState, useEffect} from "react"
import styles from "./RentProperty.module.css"
import Calendar from "../Calendar/Calendar"
import {useNavigate} from "react-router-dom"
import {useAuthUser} from "../../hooks/useAuthUser"

function RentProperty({property, propertyName}) {
  const {isAuth, id} = useAuthUser()
  const navigate = useNavigate()

  const [startDate, setStartDate] = useState(null)
  const [endDate, setEndDate] = useState(null)

  const [curMonth, setCurMonth] = useState(new Date().getMonth())
  const[curYear, setCurYear] = useState(new Date().getFullYear())
  const [nextMonth, setNextMonth] = useState(new Date().getMonth() + 1 > 11 ? 0 : new Date().getMonth() + 1)
  const[nextYear, setNextYear] = useState(new Date().getMonth() + 1 > 11 ? new Date().getFullYear() + 1 : new Date().getFullYear())
  const [availableCurDates, setAvailableCurDates] = useState(new Set())
  const [availableNextDates, setAvailableNextDates] = useState(new Set())

  const [clickedDatesNumber, setClickedDateNumber] = useState(0)

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

    const makeContract = async() => {
      if(isAuth)
      {
        let body = {}
        if(propertyName == "flat")
        {
          body = JSON.stringify({
            startDate: startDate,
            endDate: endDate,
            cost: property.costPerDay,
            flatId: property.id,
            landlordId: property.llId,
            lesseeId: id
          })
        }
        else if(propertyName == "house")
          {
            body = JSON.stringify({
              startDate: startDate,
              endDate: endDate,
              cost: property.costPerDay,
              houseId: property.id,
              landlordId: property.llId,
              lesseeId: id
            })
          }
          else if(propertyName == "room")
            {
              body = JSON.stringify({
                startDate: startDate,
                endDate: endDate,
                cost: property.costPerDay,
                roomId: property.id,
                landlordId: property.llId,
                lesseeId: id
              })
            }
        try{
          console.log(property)
          const res = await fetch(`http://127.0.0.1:29180/api/${propertyName}Contract`, {
            method: "PUT",
            headers: {
              Accept: "application/json",
              "Content-Type": "application/json",
            },
            body: body,
            credentials: "include",
          })
          const data = await res.json()
          navigate(0)
  
        }
        catch(error)
        {
          console.log(error)
        }
      }
      else{
        navigate("/login/lessee")
      }

    }

  const getAvailableDates = async(curYear, curMonth) =>{
    if(property != undefined && propertyName != undefined){
      try{
        const res = await fetch(`http://127.0.0.1:29180/api/${propertyName}Contract/dates/${property.id}/${curYear}/${curMonth+1}`, {
          method:"GET",
          credentials: "include",
        })
  
        const data = await res.json()
        setAvailableCurDates(new Set(data))
      }
      catch(error)
      {

      }
    }
  }
  const getAvailableNextDates = async(curYear, curMonth) =>{
    if(property != undefined && propertyName != undefined){
      try{
        const res = await fetch(`http://127.0.0.1:29180/api/${propertyName}Contract/dates/${property.id}/${curYear}/${curMonth+1}`, {
          method:"GET",
          credentials: "include",
        })
  
        const data = await res.json()
        setAvailableNextDates(new Set(data))
      }
      catch(error)
      {

      }
    }
  }

  useEffect(() => {
    getAvailableDates(curYear, curMonth)
    getAvailableNextDates(nextYear, nextMonth)

  }, [])

    return (
      <div className = {styles["calendar-container"]}>
        <div className = {styles["calendar-container-header"]}>
          Available days
        </div>
        <div className= {styles["calendars-wrapper"]}>
          <Calendar month = {curMonth} year={curYear} curAvailableDates = {availableCurDates}
            clickedDatesNumber = {clickedDatesNumber} handleDateClick = {handleDateClick} />
          <Calendar month = {nextMonth} year={nextYear}
            curAvailableDates={availableNextDates}
            clickedDatesNumber = {clickedDatesNumber} handleDateClick = {handleDateClick}
          />
        </div>
        <div className={styles["rent-wrapper"]}>
        <button
          className = {styles["rent-button"]}
          onClick = {() => {
            makeContract()
          }}
        >
          Rent
        </button>
        </div>
      </div>
    )
}
export default RentProperty