import { useEffect, useRef, useState } from "react";
import LocationList from "./LocationList/LocationList";
import classes from "./LocationSelection.module.css";
import LocationSelectionButton from "./LocationSelectionButton/LocationSelectionButton";

const LocationSelection = (props) => {
  const [isChecked, setIsChecked] = useState(true);
  const [activeButton, setActiveButton] = useState(null);
  const [pickUpLocation, setPickUpLocation] = useState(null);
  const [returnLocation, setReturnLocation] = useState(null);

  const hideModal = () => {
    setActiveButton(null);
  };

  const firstModalRef = useRef(null);
  const secondModalRef = useRef(null);

  useEffect(() => {
    const handleClickOutside = (event) => {
      if (activeButton === 3) {
        if (
          secondModalRef.current &&
          !secondModalRef.current.contains(event.target)
        ) {
          hideModal && hideModal();
        }
      } else if (
        firstModalRef.current &&
        !firstModalRef.current.contains(event.target)
      ) {
        hideModal && hideModal();
      }
    };
    document.addEventListener("click", handleClickOutside, true);
    return () => {
      document.removeEventListener("click", handleClickOutside, true);
    };
  }, [hideModal]);

  useEffect(() => {
    props.onChooseLocation(pickUpLocation, returnLocation)
  }, [pickUpLocation, returnLocation]);

  return (
    <div className={classes.locationSelection}>
      <div
        style={{
          display: "flex",
          justifyContent: "space-between",
          width: "540px",
        }}
      >
        <div className={classes.label}>Pick up & Return location</div>
        <div style={{ display: "flex", alignItems: "center" }}>
          <input
            type="checkbox"
            checked={isChecked}
            onClick={() => {
              setIsChecked(!isChecked);
              setPickUpLocation(null);
              setReturnLocation(null);
            }}
          ></input>
          <div style={{ fontSize: "12px", marginRight: "8px" }}>
            Same return location
          </div>
        </div>
      </div>
      {isChecked ? (
        <div ref={firstModalRef}>
          <LocationSelectionButton
            onClick={() => setActiveButton(1)}
            label={pickUpLocation === null ? "Pick up & Return location" : pickUpLocation.locationName}
            className={classes.oneLocation}
            labelStyle={classes[`labelButton${pickUpLocation !== null ? "-active" : ""}`]}
          />
          {activeButton === 1 ? (
            <LocationList
              onChoose={(location) => {
                setPickUpLocation(location);
                setReturnLocation(location);
                setActiveButton(null);
              }}
              style={{ width: "540px" }}
            />
          ) : null}
        </div>
      ) : (
        <div
          style={{
            display: "flex",
            justifyContent: "space-between",
            width: "100%",
          }}
        >
          <div ref={firstModalRef} styl>
            <LocationSelectionButton
              onClick={() => setActiveButton(2)}
              label={pickUpLocation === null ? "Pick up location" : pickUpLocation.locationName}
              className={classes.twoLocations}
              labelStyle={classes[`labelButton${pickUpLocation !== null ? "-active" : ""}`]}
            />
            {activeButton === 2 ? (
              <LocationList onChoose={(location) => {
                setPickUpLocation(location);
                setActiveButton(null);
              }} style={{ width: "254px" }} />
            ) : null}
          </div>
          <div ref={secondModalRef}>
            <LocationSelectionButton
              onClick={() => setActiveButton(3)}
              label={returnLocation === null ? "Return location" : returnLocation.locationName}
              className={classes.twoLocations}
              labelStyle={classes[`labelButton${returnLocation !== null ? "-active" : ""}`]}
            />
            {activeButton === 3 ? (
              <LocationList onChoose={(location) => {
                setReturnLocation(location);
                setActiveButton(null);
              }} style={{ width: "254px" }} />
            ) : null}
          </div>
        </div>
      )}
    </div>
  );
};

export default LocationSelection;
