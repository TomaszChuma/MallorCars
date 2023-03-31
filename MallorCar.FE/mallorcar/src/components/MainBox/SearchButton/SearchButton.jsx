import classes from './SearchButton.module.css'

const SearchButton = (props) => {
  return <button disabled={props.disabled} onClick={props.onClick} className={classes.searchButton}>
      Search For Available Cars
  </button>
}

export default SearchButton;