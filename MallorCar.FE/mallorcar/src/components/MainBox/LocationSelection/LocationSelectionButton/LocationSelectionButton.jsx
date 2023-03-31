import classes from "./LocationSelectionButton.module.css";
import image from "../../../../assets/marker.png";

const LocationSelectionButton = (props) => {
  return (
    <div onClick={props.onClick} style={{position:'relative'}}>
      <div className={props.className}>
        <div className={classes.dropdownButton}>
          <img src={image} className={classes.naviMarker} />
          <div className={props.labelStyle}>{props.label}</div>
        </div>
      </div>
    </div>
  );
};

export default LocationSelectionButton;
