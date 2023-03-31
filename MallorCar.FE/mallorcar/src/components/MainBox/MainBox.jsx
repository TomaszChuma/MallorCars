import classes from './MainBox.module.css'
import image from '../../assets/map.jpg'
import LocationSelection from './LocationSelection/LocationSelection';
import DateSelection from './DateSelection/DateSelection';
import SearchButton from './SearchButton/SearchButton';
import { useState } from 'react';

const MainBox = (props) => {
  const [rentalDetails, setRentalDetails] = useState({
    pickUpLocation: null,
    returnLocation: null,
    pickUpDateTime: null,
    returnDateTime: null
  })

  const onChooseLocationHandler = (pickUpLocation, returnLocation) => {
    setRentalDetails({
      ...rentalDetails,
      pickUpLocation: pickUpLocation,
      returnLocation: returnLocation
    })
  }

  const onChooseDateHandler = (pickUpDateTime, returnDateTime) => {
    setRentalDetails({
      ...rentalDetails,
      pickUpDateTime: pickUpDateTime,
      returnDateTime: returnDateTime
    })
  }

  const checkPropsForNull = () => {
    return Object.values(rentalDetails).some(x => x === null);
  }

  const onClickSearchButtonHandler = () => {
    if(checkPropsForNull()) {
      props.onSearchSubmit(null)
    } else if (rentalDetails.pickUpDateTime.getTime() > rentalDetails.returnDateTime.getTime())
    {
      props.onSearchSubmit(null)
    }
    else {
      props.onSearchSubmit(rentalDetails)
    }
  }

  return (
    <div className={classes.mainBox} style={props.isHiding ? {display:"none"} : null}>
      <LocationSelection onChooseLocation={onChooseLocationHandler}/>
      <DateSelection onChooseDate={onChooseDateHandler}/>
      <SearchButton onClick={onClickSearchButtonHandler}/>
    </div>
  )
}

export default MainBox;