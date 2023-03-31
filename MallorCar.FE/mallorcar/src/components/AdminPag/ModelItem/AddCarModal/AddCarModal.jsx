import classes from "./AddCarModal.module.css";
import LocationList from "../../../MainBox/LocationSelection/LocationList/LocationList";
import { useState } from "react";
import axios from "axios";

const AddCarModal = (props) => {
  const [selectedStartLocation, setSelectedStartLocation] = useState(null);
  const [carRegNumber, setCarRegNumber] = useState(null);

  const onChooseLocationHandler = (location) => {
    console.log(location)
    setSelectedStartLocation(location)
  }

  const onInputChangeHanlder = (event) => {
    setCarRegNumber(event.target.value)
  }

  const addNewCar = async () => {
    console.log(props.model)
    try {
      const response = await axios.post('https://localhost:7214/api/cars', {
        modelId: props.model.modelId,
        carRegNumber: carRegNumber,
        locationId: selectedStartLocation.locationId
      })
    } catch(err) {
      console.log(err)
    }

    props.onCloseModal();
  }

  return (
    <div className={classes.modalBackground}>
      <div className={classes.modal}><div className={classes.label}>Choose Start Location For New Car</div>
      <LocationList onChoose={onChooseLocationHandler} style={{width:"300px", position:"static"}}/>
      {selectedStartLocation !== null ? <div style={{textAlign:"center"}}>
        <div className={classes.locationName}>Start Location: {selectedStartLocation.locationName}</div>
        <input onChange={onInputChangeHanlder} value={carRegNumber} type="text" placeholder="Enter Car Reg Number"></input>
      </div> : null}
      <button style={{marginLeft:"0px"}} disabled={selectedStartLocation === null && carRegNumber === null} onClick={addNewCar}>Add</button></div>
    </div>
  );
};

export default AddCarModal;
