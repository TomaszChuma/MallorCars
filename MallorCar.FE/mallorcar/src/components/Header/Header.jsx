import { Link } from "react-router-dom";
import classes from "./Header.module.css";

const Header = () => {
  return (
    <div className={classes.header}>
      <div className={classes.headerContent}>
        <div>
          <Link to="/">
            <div className={classes.title}>MallorCar</div>
          </Link>
          <div className={classes.label}>Luxury Tesla Rental Service</div>
        </div>
        <div className={classes.test}>
          <Link to="/admin">
            <div className={classes.currency}>Admin</div>
          </Link>
          <Link to="/booking">
            <div className={classes.sign}>Manage booking</div>
          </Link>
        </div>
      </div>
    </div>
  );
};

export default Header;
