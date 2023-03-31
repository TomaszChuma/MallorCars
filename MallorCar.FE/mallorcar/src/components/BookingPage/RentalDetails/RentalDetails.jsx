import classes from './RentalDetails.module.css'

const RentalDetails = (props) => {
  const details = props.details;

  const image = require(`../../../assets/${details.rentalCarPhotoUrl}.png`);

  const convertDateString = (dateToConvert) => {
    let date = new Date(dateToConvert);
    let minutes = date.getMinutes() === 0 ? "00" : date.getMinutes()
    return (
      date.toLocaleDateString("en-us", { weekday: "short" }) +
      " " +
      date.getDate() +
      " " +
      date.toLocaleString("en-US", { month: "short" }) +
      " " +
      date.getHours() +
      ":" +
      minutes
    );
  };

  return (
    <div className={classes.rentalDetails}>
      <img src={image} className={classes.carImg}></img>
      <div className={classes.modelName}>Model {details.rentalCarModelName}</div>
      <div className={classes.modelSubName}>{details.rentalCarModelSubName}</div>  
      <div className={classes.label}>From: {details.rentalStartLocationName} <span>{convertDateString(details.rentalStartDate)}</span></div>
      <div className={classes.label}>To: {details.rentalEndLocationName} <span>{convertDateString(details.rentalEndDate)}</span></div>
      <img></img>
    </div>
  )
}

export default RentalDetails;