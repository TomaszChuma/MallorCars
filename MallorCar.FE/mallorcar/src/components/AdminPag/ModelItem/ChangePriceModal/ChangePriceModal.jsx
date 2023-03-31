import { useState } from "react";
import classes from "./ChangePriceModal.module.css";
import { NumberPicker } from "react-widgets";
import axios from "axios";

const ChangePriceModal = (props) => {
  const [dailyBasePrice, setDailyBasePrice] = useState(props.model.modelDailyPrice);

  const updateDailyPrice = async () => {
    try {
      const response = await axios.patch('https://localhost:7214/api/models', {
        modelId: props.model.modelId,
        modelDailyBasePrice: dailyBasePrice
      })
    } catch(err) {
      console.log(err)
    }

    props.onCloseModal();
    window.location.reload();
  }



  return (
    <div className={classes.modalBackground}>
      <div className={classes.modal}>
        <div className={classes.label}>Enter New Daily Base Price</div>
        <div className={classes.picker}>
        <NumberPicker
          precision={1}
          defaultValue={props.model.modelDailyPrice}
          step={2}
          min={1}
          onChange={(price) => setDailyBasePrice(price)}
        ></NumberPicker>
        </div>
        <button style={{marginLeft:"0px"}} className={classes.confirmButton} onClick={updateDailyPrice}>Confirm</button>
      </div>
    </div>
  );
};

export default ChangePriceModal;
