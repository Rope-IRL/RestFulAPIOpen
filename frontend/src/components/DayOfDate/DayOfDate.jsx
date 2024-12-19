import { useState } from "react";
import styles from "./DayOfDate.module.css";

function DayOfDate({ currentDay, curState, clickedDays, handleDateClick, curMonth, curYear }) {

  const [isClicked, setIsClicked] = useState(false);

  const handleClick = () => {
    if(clickedDays < 2 )
    {
        setIsClicked((prevState) => !prevState);
        // const clickedDate = `${curMonth+1}-${Number(currentDay)}-${curYear}`
        let clickedDate = new Date(curYear, curMonth, currentDay)
        const offset = clickedDate.getTimezoneOffset()
        clickedDate = new Date(clickedDate.getTime() - (offset*60*1000))
        .toISOString()
        .split("T")[0]
        handleDateClick(clickedDate)
    }
  };

  const finalStyle = isClicked && curState === "available-date" ? "clicked-date" : curState;

  return (
    <div
      className={styles[finalStyle]}
      onClick={handleClick}
    >
      {currentDay}
    </div>
  );
}

export default DayOfDate;
