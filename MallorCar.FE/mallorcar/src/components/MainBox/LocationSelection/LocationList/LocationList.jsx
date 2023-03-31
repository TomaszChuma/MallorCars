import axios from 'axios';
import { useEffect, useState } from 'react';
import classes from './LocationList.module.css'

const LocationList = (props) => {
  const [locations, setLocations] = useState(null);

  const getLocationsFromAPI = async () => {
    try {
      const response = await axios.get(
        `https://localhost:7214/api/locations`
      );
      setLocations(response.data);
    } catch (err) {
      console.log(err);
    }
  }

  useEffect(() => {
    getLocationsFromAPI();
  }, []);

  const listContent = locations ? locations.map(location => (
        <div onClick={() => props.onChoose(location)} key={location.locationId} className={classes.dropdownItem}>{location.locationName}</div>
  )) : null

  return (
    <div className={classes.dropdownContent} style={props.style}>
        {listContent}
    </div>
  )
}

export default LocationList;