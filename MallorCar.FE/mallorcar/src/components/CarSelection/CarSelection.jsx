import classes from './CarSelection.module.css'
import CarSelectionItem from './CarSelectionItem/CarSelectionItem';

const CarSelection = (props) => {

  const cars = props.availableCars.map(car => (
    <CarSelectionItem onCarSelect={props.onCarSelect} carDetails={car} selectedCar={props.selectedCar}/>
  ))
  return <div className={classes.carList}>
    {cars}
  </div>
}

export default CarSelection;