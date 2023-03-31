import { useState } from 'react';
import classes from './BookingPage.module.css'
import axios from 'axios';
import RentalDetails from './RentalDetails/RentalDetails';

const BookingPage = () => {
  const [rentalCode, setRentalCode] = useState("");
  const [rentalDetails, setRentalDetails] = useState(null);

  const onChangeInputHandler = (event) => {
    setRentalCode(event.target.value)
  }

  const getRentalDetails = async () => {
    try {
      const response = await axios.get(`https://localhost:7214/rentalCode/rental?RentalCode=${rentalCode}`);
      setRentalDetails(response.data);
    } catch (err) {
      console.log(err);
    }
  }

  return (
    <div className={classes.modal}>
      {rentalDetails === null ? <div className={classes.container}>
        <div className={classes.label}>
      Please Enter Your Rental Code
      </div>
      <input type='text' placeholder='Rental code' onChange={onChangeInputHandler} value={rentalCode}></input>
      <button disabled={rentalCode.length !== 8} onClick={getRentalDetails}>Confirm</button>
      </div> : <RentalDetails details={rentalDetails}/>}
    </div>
  )
}

export default BookingPage;