import { useState } from "react";
import styles from "./Calendar.module.css";
import DayOfDate from "../DayOfDate/DayOfDate";

function Calendar({month, year, curAvailableDates, clickedDatesNumber, handleDateClick}) {
    const [curMonth, setCurMonth] = useState(month == undefined ? new Date().getMonth() : month);
    const [curYear, setCurYear] = useState(year == undefined ? new Date().getFullYear() : year);
    // const [availableDates, setAvailableDates] = useState(curAvailableDates == undefined ? new Set() : curAvailableDates)
    
    const [isDateClicked, setIsDateClicked] = useState(false)

    const getMonth = {
        0 : "January",
        1 : "February",
        2 : "March",
        3 : "April",
        4 : "May",
        5 :" June",
        6 : "July",
        7 : "August",
        8 : "September",
        9 : "October",
        10 : "November",
        11 : "December"
    }

    const isDateAvailable = (day) => {
        if(curAvailableDates != undefined)
        {
            if(!curAvailableDates.has(day))
            {
                return false
            }
        }

        return true 
    }

    // const [clickedDatesNumber, setClickedDateNumber] = useState(0)

    // const handleDateClick = () => {
    //     setClickedDateNumber(prevState => {
    //         if(prevState + 1 > 2)
    //         {
    //             return 1
    //         }
    //         return prevState + 1
    //     })
    // }

    const getCalendar = (curYear, curMonth) => {
        const daysInMonth = new Date(curYear, curMonth + 1, 0).getDate();
        const firstDay = new Date(curYear, curMonth, 1).getDay();
        const adjustedFirstDay = firstDay === 0 ? 6 : firstDay - 1; // Adjust for Monday start
        let currentDay = 1;


        const rows = [];
        while (currentDay <= daysInMonth) {
            const cells = [];

            for (let i = 0; i < 7; i++) {
                if ((currentDay === 1 && i < adjustedFirstDay) || currentDay > daysInMonth) {
                    cells.push(<td key={`empty-${rows.length}-${i}`}></td>);
                } else {
                    cells.push(<td key={`day-${currentDay}`} 
                        value = {currentDay}
                    >
                        <DayOfDate currentDay={currentDay} 
                            curState={isDateAvailable(currentDay) ? "available-date" : "not-available-date"}
                            clickedDays={clickedDatesNumber}
                            handleDateClick={handleDateClick}
                            curMonth = {curMonth}
                            curYear = {curYear}
                            />
                        </td>);
                    currentDay++;
                }
            }

            rows.push(<tr key={`row-${rows.length}`}>{cells}</tr>);
        }

        return <div className = {styles["calendar-container"]}> 
            <div
                className = {styles["calendar-container-header"]}
            >
                {`${getMonth[curMonth]} ${curYear}`}
            </div>
            <table>
                <thead>
                    <tr>
                        <th>
                            <div className = {styles["date-item"]} >Mo</div>
                        </th>
                        <th>
                            <div className = {styles["date-item"]} >Tu</div>
                        </th>
                        <th>
                            <div className = {styles["date-item"]} >We</div>
                        </th>
                        <th>
                            <div className = {styles["date-item"]} >Th</div>
                        </th>
                        <th>
                            <div className = {styles["date-item"]} >Fr</div>
                        </th>
                        <th>
                            <div className = {styles["date-item"]} >Sa</div>
                        </th>
                        <th>
                            <div className = {styles["date-item"]} >Su</div>
                        </th>
                    </tr>
                </thead>
                <tbody>
                    {rows}
                </tbody>
            </table>
    </div>
        
    };

    return (
        <div>
            {
                getCalendar(curYear, curMonth)
            }
        </div>
    );
}

export default Calendar;
