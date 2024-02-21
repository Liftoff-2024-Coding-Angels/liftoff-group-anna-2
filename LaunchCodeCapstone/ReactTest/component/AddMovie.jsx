import "./AddMovie.scss"
import moment from "moment"


const Movie = ({ id, title, dateWatched, rating }) => {

    const formattedDate = moment(dateWatched).format("MM-DD-YYYY");

    return (
      <div className="movieItem" id = {id}>
        <p className="moveItem_title">Title: {title}</p>
        <p className="movieItem_dateWatched">Date Watched: {formattedDate}</p>
        <p className="moveItem_rating">Rating: {rating}</p>
      </div>
    );
  };
  

export default Movie;