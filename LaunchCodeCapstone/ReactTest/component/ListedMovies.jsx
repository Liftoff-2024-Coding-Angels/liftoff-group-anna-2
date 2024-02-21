import Movie from "./AddMovie"
// import "./UserAddedMovie.scss"
import EditModal from "./EditMovieModal"
import DeleteModal from "./DeleteMovieModal"
import "./ListedMovies.scss"
import "./AddMovie.scss"
import axios from "axios";
import { useState, useEffect } from "react"

const MovieList = () => {
  const [movies, setMovies] = useState([]);
  const [selectedMovieForEdit, setSelectedMovieForEdit] = useState(null);
  const [selectedMovieForDelete, setSelectedMovieForDelete] = useState(null);

  useEffect(() => {
    const fetchMovies = async () => {
      try {
        const response = await axios.get("https://localhost:5001/MovieEntry/Read");
        //setMovies(response.data); // Assuming API returns an array of movie objects
        setMovies(response.data);
        console.log("API Response:", response);
        console.log(response.data);
        //console.log("Movie Data:", response.data);
      } catch (error) {
        console.error("Error fetching movies:", error);
      }
    };

    fetchMovies();
  }, []);

  const openEditModal = (movie) => {
    setSelectedMovieForEdit(movie);
  };

  const closeEditModal = (editedMovie) => {
    setSelectedMovieForEdit(null);
    // Refresh movie list after editing
    setMovies(movies.map(movie => (movie.movieEntryId === editedMovie.movieEntryId ? editedMovie : movie)));
  };

  const openDeleteModal = (movie) => {
    setSelectedMovieForDelete(movie);
  };

  const closeDeleteModal = (deletedMovie) => {
    setSelectedMovieForDelete(null);
    // Refresh movie list after deleting
    setMovies(movies.filter(movie => movie.movieEntryId !== deletedMovie.movieEntryId));
  };

  console.log("Movies:", movies);

return (
    <div className="movieList">
      <h2 className="movieList_header">List of Movies Added:</h2>
      {movies && movies.length > 0 ? (
        movies.map((movie) => (
            <div className="movieList_block" key={movie.movieEntryId}>
            <Movie
              title={movie.title}
              dateWatched={movie.date}
              rating={movie.numRating}
            />
            <div className="movieList_buttons">
            <button className="movieList_editButton" onClick={() => openEditModal(movie)}>Edit</button>
            <button className="movieList_deleteButton"  onClick={() => openDeleteModal(movie)}>Delete</button>
            </div>
          </div>
        ))
      ) : (
        <p>No movies found.</p>
      )}
        {selectedMovieForEdit && (
        <EditModal movie={selectedMovieForEdit} onClose={closeEditModal} />
      )}
      {selectedMovieForDelete && (
        <DeleteModal movie={selectedMovieForDelete} onClose={closeDeleteModal} />
      )}
    </div>
  );
};

export default MovieList;



// Try #1:

//  const MovieList = () => {
//     const [movies, setMovies] = useState({});

//     useEffect(() => {
//         const fetchMovies = async () => {
//             try {
//                 const response = await axios.get("https://localhost:5001/MovieEntry/Read");
//                 setMovies(response.data); // Assuming API returns a movie object
//                 console.log("Movie Data:", response.data);
//             } catch (error) {
//                 console.error("Error fetching movies:", error);
//             }
//         };

//         fetchMovies();
//     }, []);

//     return (
//         <div className="movieList">
//             <h2>List of Movies Added:</h2>
//             {movies && (
//                 <Movie
//                     key={movies.MovieEntryId} // Assuming 'MovieEntryId' is the unique identifier
//                     title={movies.Title}
//                     dateWatched={movies.Date} // Assuming 'Date' is the correct property
//                     rating={movies.NumRating} // Assuming 'NumRating' is the correct property
//                 />
//             )}
//         </div>
//     );
// };

//Try #2:

//   return (
//     <div className="movieList">
//       <h2>List of Movies Added:</h2>
//       {movies && movies.map((movie) => (
//         <Movie
//           key={movie.MovieEntryId}
//           title={movie.Title}
//           dateWatched={movie.Date}
//           rating={movie.NumRating}
//         />
//       ))}
//     </div>
//   );
//       }

//Try #3:

//   return (
//     <div className="movieList">
//       <h2>List of Movies Added:</h2>
//       {movies.map((movie) => (
//         <Movie
//           key={movie.MovieEntryId} // Assuming 'MovieEntryId' is the unique identifier
//           title={movie.Title}
//           dateWatched={movie.Date} // Assuming 'Date' is the correct property
//           rating={movie.NumRating} // Assuming 'NumRating' is the correct property
//         />
//       ))}
//     </div>
//   );
// };