import "./AddMovie.scss"


const Movie = (props) =>
{
    return (
    <div className="movieItem">
        <p className="moveItem_title">Title: {props.title}</p>
        <p className="movieItem_dateWatched">Date Watched: {props.dateWatched}</p>
        <p className="moveItem_rating">Rating: {props.rating}</p>
    </div>
    )
}

export default Movie;