import { useState } from "react";
import classes from "./Form.module.css";

const Form = (props) => {
  const [clientData, setClientData] = useState({
    firstName: "",
    lastName: "",
    phoneNumber: "",
    email: ""
  })

  const handleInputChange = (event) => {
    const value = event.target.value;
    setClientData({
      ...clientData,
      [event.target.name]: value
    })
  }

  const checkPropsForNull = () => {
    return Object.values(clientData).some(x => x === "");
  }

  return (
    <div className={classes.formBox}>
      <button onClick={props.onGoBack} className={classes.backButton}>
        x
      </button>
      <div className={classes.label}>Please enter your personal data</div>
      <div className={classes.formContainer}>
        <div className={classes.formSubContainer}>
          <div className={classes.inputLabel}>First Name</div>
          <input type="text" name="firstName" value={clientData.firstName} onChange={handleInputChange}></input>
        </div>
        <div className={classes.formSubContainer}>
        <div className={classes.inputLabel}>Last Name</div>
        <input type="text" name="lastName" value={clientData.lastName} onChange={handleInputChange}></input>
        </div>
      </div>
      <div className={classes.formContainer}>
      <div className={classes.formSubContainer}>
        <div className={classes.inputLabel}>Phone Number</div>
        <input type="text" name="phoneNumber" value={clientData.phoneNumber} onChange={handleInputChange}></input>
        </div>
        <div className={classes.formSubContainer}>
        <div className={classes.inputLabel}>Email</div>
        <input type="text" name="email" value={clientData.email} onChange={handleInputChange}></input>
        </div>
      </div>
      <button disabled={checkPropsForNull()} onClick={() => props.onFormSubmit(clientData)} className={classes.submitButton}>Submit</button>
    </div>
  );
};

export default Form;
