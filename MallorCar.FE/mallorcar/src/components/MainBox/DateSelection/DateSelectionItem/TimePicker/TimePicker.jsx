import { useEffect, useRef } from 'react';
import classes from './TimePicker.module.css'

const TimePicker = (props) => {
  let time = new Date("2000-01-01 07:00 AM");
  let timeArr = [{ hour: null, minute: null}];

  let minTime = props.minTime === null ? {hour: 7, minute:0} : props.minTime

  const minTimeIterationStart = () => ((22 - minTime.hour) * 4 - minTime.minute/15);
  time.setHours(minTime.hour);
  time.setMinutes(minTime.minute);

  for(let i = 0; i < minTimeIterationStart(); i++) {
    timeArr[i] = {hour: time.getHours(), minute: time.getMinutes()}
    time.setTime(time.getTime() + 0.25 * 60 * 60 * 1000)
  }

  let timeItems = timeArr.map((item, index) => (
    <div key={index} onClick={() => props.onTimeChange(item)} className={classes.timePickerItem}>
      {item.minute !== 0 ? `${item.hour}:${item.minute}` : `${item.hour}:${item.minute}0`}
    </div>
  ))

  return <div className={classes.timePicker}>
    {(timeArr.length >= 1 && timeArr[0].hour !== null) ? timeItems : "You will have to leave it tommorow"}
  </div>
}

export default TimePicker;