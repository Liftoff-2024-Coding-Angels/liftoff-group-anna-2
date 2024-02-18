import "./AddMovie"
import "./UserAddedMovie.scss"
import "./ListedMovies.scss"
import { useState } from "react"

const MovieList = (movies) => {
    <div className="movieList">
        <h2>List of Movies Added:</h2>
        {movies.map((movie, index) => (
         <MovieItem key={index} movie={movie} />
      ))}
    </div>
}

export default MovieList;