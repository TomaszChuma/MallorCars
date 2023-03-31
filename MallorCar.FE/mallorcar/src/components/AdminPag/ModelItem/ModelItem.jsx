import { useState } from "react";
import classes from "./ModelItem.module.css";
import ChangePriceModal from "./ChangePriceModal/ChangePriceModal";
import AddCarModal from "./AddCarModal/AddCarModal";

const ModelItem = (props) => {
  const [isPriceModalOpen, setIsPriceModalOpen] = useState(false);
  const [isAddCarModalOpen, setIsCarModalOpen] = useState(false);

  const model = props.model;
  const image = require(`../../../assets/${model.modelPhotoUrl}.png`);


  return (
    <div key={model.modelId} className={classes.modelItem}>
      <img src={image} className={classes.carImg}></img>
      <div>
      <div className={classes.modelName}>Model: <span style={{fontFamily:"Tesla", fontSize:"46px"}}>
      {model.modelName}</span></div>
      <div className={classes.modelSubName}>{model.modelSubName}</div>
      <div className={classes.dailyPrice}>Base Daily Price: {model.modelDailyPrice}</div>
      </div>
      <button onClick={() => setIsPriceModalOpen(true)}>Change Price</button>
      {isPriceModalOpen ? <ChangePriceModal model={model} onCloseModal={() => setIsPriceModalOpen(false)}/> : null}
      <button onClick={() => setIsCarModalOpen(true)}> Add Car</button>
      {isAddCarModalOpen ? <AddCarModal model={model} onCloseModal={() => setIsCarModalOpen(false)}/> : null}
    </div>
  );
};

export default ModelItem;
