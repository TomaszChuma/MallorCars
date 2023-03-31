import classes from "./DateSelectionItem.module.css";
import image from "../../../../assets/calendar.jpg";
import { useEffect, useRef, useState } from "react";
import TimePicker from "./TimePicker/TimePicker";
import Calendar from "react-calendar";
import "../../DateSelection/Calendar.css";

const DateSelectionItem = (props) => {
  const [time, setTime] = useState(null);
  const [isTimeModalOpen, setIsTimeModalOpen] = useState(false);
  const [isCalendarOpen, setIsCalendarOpen] = useState(false);
  const [date, setDate] = useState(null);

  const hideTimeModal = () => {
    setIsTimeModalOpen(false);
  };

  const hideCalendar = () => {
    setIsCalendarOpen(false);
  };

  const timeRef = useRef(null);
  const calendarRef = useRef(null);

  const convertDateToString = (date) => {
    return (
      date.toLocaleString("en-US", { weekday: "short" }) +
      " " +
      date.getDate() +
      " " +
      date.toLocaleString("en-US", { month: "short" })
    );
  };

  const onDateChangeHandler = (date) => {
    setDate(date);
    props.onDateChange(date);
    setIsCalendarOpen(false);
  };

  const onTimeChangeHandler = (time) => {
    setTime(time);
    props.onTimeChange(time);
    setIsTimeModalOpen(false);
  };

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (timeRef.current && !timeRef.current.contains(event.target)) {
        hideTimeModal && hideTimeModal();
      }
    };
    document.addEventListener("click", handleClickOutside, true);
    return () => {
      document.removeEventListener("click", handleClickOutside, true);
    };
  }, [hideTimeModal]);

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (calendarRef.current && !calendarRef.current.contains(event.target)) {
        hideCalendar && hideCalendar();
      }
    };
    document.addEventListener("click", handleClickOutside, true);
    return () => {
      document.removeEventListener("click", handleClickOutside, true);
    };
  }, [hideCalendar]);

  useEffect(() => {
    props.onTimeChange(null);
    setTime(null);
  }, [props.defaultValue])

  useEffect(() => {
    setTime(props.defaultTime);
  }, [props.defaultTime])

  return (
    <div>
      <div className={classes.label}>{props.label} Date & Time</div>
      <div className={classes.timeSelection}>
        <div
          className={classes.dateSelection}
          onClick={() => {
            setIsCalendarOpen(!isCalendarOpen);
          }}
        >
          <img src={image} className={classes.calendarImg}></img>
          <div
            className={
              classes[`datePlaceholder${date !== null ? "-active" : ""}`]
            }
          >
            {date === null ? `${props.label} Date` : convertDateToString(props.defaultValue)}
          </div>
        </div>
        <div
          onClick={() => setIsTimeModalOpen(!isTimeModalOpen)}
          className={
            classes[`timePlaceholder${time !== null ? "-active" : ""}`]
          }
        >
          {time === null
            ? "Time"
            : time.minute === 0
            ? `${time.hour}:${time.minute}0`
            : `${time.hour}:${time.minute}`}
        </div>
      </div>
      <div ref={timeRef}>
        {isTimeModalOpen ? (
          <TimePicker
            onTimeChange={(choosedTime) => onTimeChangeHandler(choosedTime)}
            minTime={props.minTime}
          />
        ) : null}
      </div>
      <div ref={calendarRef}>
        {isCalendarOpen ? (
          <Calendar
            onChange={(date) => onDateChangeHandler(date)}
            className={classes.calendar}
            minDate={props.minDate}
          />
        ) : null}
      </div>
    </div>
  );
};

export default DateSelectionItem;
