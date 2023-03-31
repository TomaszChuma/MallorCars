import { useState } from 'react';
import classes from './AdminPage.module.css'
import { useEffect } from 'react';
import axios from 'axios';
import ModelItem from './ModelItem/ModelItem';

const BookingPage = () => {
  const [models, setModels] = useState();

  const fetchModels = async () => {
    try {
      const response = await axios.get('https://localhost:7214/api/models');
      setModels(response.data);
    } catch (err) {
      console.log(err);
    }
  }

  useEffect(() => {
    fetchModels();
  }, []);

  const modelsList = models ? models.map(model => (
    <ModelItem model={model}/>
  )) : null

  return(
    <div className={classes.modelsList}>
      {modelsList}
    </div>
  )
}

export default BookingPage;