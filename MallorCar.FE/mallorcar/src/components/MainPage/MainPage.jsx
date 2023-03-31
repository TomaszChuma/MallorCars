import { useState } from 'react';
import MainBox from '../MainBox/MainBox';
import classes from './MainPage.module.css'
import axios from 'axios';
import CarSelection from "../CarSelection/CarSelection";
import Form from "../Form/Form";

const MainPage = () => {
  const [availableCars, setAvailableCars] = useState(null);
  const [rentalDetails, setRentalDetails] = useState(null);
  const [modelId, setModelId] = useState(null);

  const onSearchSubmitHandler = async (rentalDetails) => {
    if(rentalDetails === null) {
      setAvailableCars(null);
    }
    setRentalDetails(rentalDetails);
    try {
      const response = await axios.get(
        `https://localhost:7214/api/locations/locationId/rentals/dateRange/availableCars?locationId=${
          rentalDetails.pickUpLocation.locationId
        }&RentalStartDate=${rentalDetails.pickUpDateTime.toJSON()}&RentalEndDate=${rentalDetails.returnDateTime.toJSON()}`
      );
      setAvailableCars(response.data);
    } catch (err) {
      console.log(err);
    }
  };

  const onChooseCarHandler = (modelId) => {
    setModelId(modelId)
  }

  const onFormSubmitHandler = async (client) => {
    try {
      const response = await axios.post("https://localhost:7214/api/clients", {
        clientFirstName: client.firstName,
        clientLastName: client.lastName,
        clientEmail: client.email,
        clientPhoneNumber: client.phoneNumber
      })
      postTickets(response.data)
    } catch (err) {
      console.log(err);
    }
  }

  const postTickets = async (clientId) => {
    const pickUpDateTime = rentalDetails.pickUpDateTime;
    const returnDateTime = rentalDetails.returnDateTime;
    pickUpDateTime.setHours(pickUpDateTime.getHours() + 2)
    returnDateTime.setHours(returnDateTime.getHours() + 2)
    try {
      console.log({
        modelId: modelId,
        rentalStartLocationId: rentalDetails.pickUpLocation.locationId,
        rentalEndLocationId: rentalDetails.returnLocation.locationId,
        rentalStartDate: pickUpDateTime.toJSON(),
        rentalEndDate: returnDateTime.toJSON(),
        clientId: clientId
      })
      const response = await axios.post("https://localhost:7214/api/rentals", {
        modelId: modelId,
        rentalStartLocationId: rentalDetails.pickUpLocation.locationId,
        rentalEndLocationId: rentalDetails.returnLocation.locationId,
        rentalStartDate: pickUpDateTime.toJSON(),
        rentalEndDate: returnDateTime.toJSON(),
        clientId: clientId
      })
    } catch (err) {
      console.log(err);
    }
    window.location.reload();
  }

  return (
    <div className={classes.mainBox}>
      <MainBox isHiding={modelId !== null}
        onSearchSubmit={(rentalDetails) => onSearchSubmitHandler(rentalDetails)}
      />
      {modelId !== null ? <Form onFormSubmit={onFormSubmitHandler} onGoBack={() => {setModelId(null)}}/> : null}
      {availableCars !== null ? <CarSelection availableCars={availableCars} onCarSelect={onChooseCarHandler}
      selectedCar={modelId}/> : null}
    </div>
  )
}

export default MainPage;