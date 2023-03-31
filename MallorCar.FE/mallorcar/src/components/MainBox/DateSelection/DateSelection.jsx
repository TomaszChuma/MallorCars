import { useEffect, useState } from "react";
import classes from "./DateSelection.module.css";
import DateSelectionItem from "./DateSelectionItem/DateSelectionItem";

const DateSelection = (props) => {
  const [pickUpDate, setPickUpDate] = useState(new Date());
  const [isPickUpDateSet, setIsPickUpDateSet] = useState(false);
  const [returnDate, setReturnDate] = useState(new Date());
  const [isReturnDateSet, setIsReturnDateSet] = useState(false);
  const [pickUpTime, setPickUpTime] = useState(null);
  const [returnTime, setReturnTime] = useState(null);
  const [returnMinTime, setReturnMinTime] = useState();

  const onPickUpDateChangeHandler = (date) => {
    setPickUpDate(date);
    setIsPickUpDateSet(true);
  };

  const onReturnDateChangeHandler = (date) => {
    setReturnDate(date);
    setIsReturnDateSet(true);
  };

  const onPickUpTimeChangeHandler = (time) => {
    setPickUpTime(time);
    setReturnTime(null);
  };

  const onReturnTimeChangeHandler = (time) => {
    setReturnTime(time);
  };

  const returnCalendarMinDate = () => {
    return pickUpDate !== null ? pickUpDate : new Date()
  }

  useEffect(() => {
    if(pickUpDate > returnDate) {
      setReturnDate(pickUpDate)
    }
  }, [pickUpDate])

  useEffect(() => {
    setReturnMinTime(pickUpDate.getDay() === returnDate.getDay() ? (pickUpTime !== null ? {hour: pickUpTime.hour + 1, minute: pickUpTime.minute } : {hour: 7, minute: 0}) : {hour: 7, minute: 0})
  }, [pickUpDate, returnDate, pickUpTime]);

  useEffect(() => {
    if (isPickUpDateSet === true && isReturnDateSet === true && pickUpTime !== null && returnTime !== null)
    {
      let pickUpDateTime = new Date(pickUpDate);
      let returnDateTime = new Date(returnDate);
      pickUpDateTime.setHours(pickUpTime.hour);
      pickUpDateTime.setMinutes(pickUpTime.minute);
      returnDateTime.setHours(returnTime.hour);
      returnDateTime.setMinutes(returnTime.minute);
      props.onChooseDate(pickUpDateTime, returnDateTime);
    }
    if(pickUpTime === null || returnTime === null) {
      props.onChooseDate(null, null);
    }
  }, [pickUpDate, returnDate, pickUpTime, returnTime])


  return (
    <div className={classes.dateSelection}>
      <DateSelectionItem
        onDateChange={onPickUpDateChangeHandler}
        onTimeChange={onPickUpTimeChangeHandler}
        label="Pick up"
        minDate={new Date()}
        defaultValue={pickUpDate}
        minTime={{hour: 7, minute: 0}}
        defaultTime={pickUpTime}
      />
      <DateSelectionItem
        onDateChange={onReturnDateChangeHandler}
        onTimeChange={onReturnTimeChangeHandler}
        label="Return"
        minDate={returnCalendarMinDate()}
        defaultValue={pickUpDate > returnDate ? pickUpDate : returnDate}
        minTime={returnMinTime}
        defaultTime={returnTime}
      />
    </div>
  );
};

export default DateSelection;
