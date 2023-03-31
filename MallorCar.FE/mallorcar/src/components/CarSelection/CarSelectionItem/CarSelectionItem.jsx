import classes from "./CarSelectionItem.module.css";
import image from "../../../assets/3performance.png";
import { useState } from "react";

const CarSelectionItem = (props) => {

  const carDetails = props.carDetails;
  const image = require(`../../../assets/${carDetails.modelPhotoUrl}.png`);

 return (
    <div className={props.selectedCar === carDetails.modelId ? classes.selectionBoxSelected : classes.selectionBox} key={carDetails.modelId}>
      <div
        className={classes.selectionItem}
      >
        <div className={classes.imgContainer}>
          <img src={image} className={classes.carPhoto}></img>
        </div>
        <div className={classes.desc}>
          <div className={classes.carName}>
            <div className={classes.modelName}>
              Model:{" "}
              <span style={{ fontFamily: "Tesla", fontSize: "38px" }}>{carDetails.modelName}</span>
            </div>
            <div className={classes.modelSubName}>{carDetails.modelSubName === null ? "\u00A0" : carDetails.modelSubName}</div>
          </div>
          <div onClick={() => props.onCarSelect(carDetails.modelId)} className={classes.totalPrice}>Rent for {carDetails.totalCost}€</div>
          <div className={classes.numLeft}>{carDetails.numOfAvailableCars} Available left</div>
        </div>
      </div>
      <div className={classes.details}>
        <div className={classes.detailsItem}>
          <div className={classes.label}>Range</div>
          <div className={classes.detailDesc}>
            <div className={classes.num}>{carDetails.modelRange}</div>
            <div className={classes.numLabel}>kilometers</div>
          </div>
        </div>
        <div className={classes.detailsItem}>
          <div className={classes.label}>Seating up to</div>
          <div className={classes.detailDesc}>
            <div className={classes.num}>{carDetails.modelNumOfSeats}</div>
            <div className={classes.numLabel}>seats</div>
          </div>
        </div>
        <div className={classes.detailsItem}>
          <div className={classes.label}>Acceleration</div>
          <div className={classes.detailDesc}>
            <div className={classes.num}>{carDetails.modelAcceleration}s</div>
            <div className={classes.numLabel}>0-100km/h</div>
          </div>
        </div>
        <div className={classes.detailsItem}>
          <div className={classes.label}>Top Speed</div>
          <div className={classes.detailDesc}>
            <div className={classes.num}>{carDetails.modelTopSpeed}</div>
            <div className={classes.numLabel}>km/h</div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default CarSelectionItem;
