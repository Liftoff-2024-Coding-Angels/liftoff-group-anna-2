import React, {useState} from "react";
import axios from "axios";

// const DeleteModal = ({ movie, onClose }) => {

//     const [deleteMovie, setDeleteMovie] = useState()


// //    useEffect(() =>   
// //    const handleDelete = async () => {
// //     try {
// //       // Send delete request to backend
// //       await axios.delete(`https://localhost:5001/MovieEntry/Delete/${movie.movieEntryId}`)
// //       .then(response => {
// //         console.log(`Deleted post with ID ${postIdToDelete}`)});
// //       //await axios.delete(`https://localhost:5001/MovieEntry/Delete/`);
// //       //await axios.post(`https://localhost:5001/MovieEntry/Delete/`);
// //       // Close modal and refresh movie list
// //       onClose(movie);
// //     } catch (error) {
// //       console.error("Error deleting movie:", error);
// //     }
// //   };
// // ) 

//   // DELETE request using axios with async/await
//   //useEffect(() => {
//   const handleDelete = async () => {
//     try {
//       // Send delete request to backend
//       await axios.delete(`https://localhost:5001/MovieEntry/Delete/${movie.movieEntryId}`)
//       setDeleteMovie('Delete successful');
//       onClose(movie);
// } catch (error) {
//   console.error("Error deleting movie:", error);
// }}
// //}, []);;


//   return (
//     <div className="deleteModal" id = {movie.movieEntryId}>
//       <h2>Delete Movie</h2>
//       <p>Are you sure you want to delete the movie "{movie.title}"?</p>
//       <button onClick={handleDelete}>Delete</button>
//       <button onClick={onClose}>Cancel</button>
//     </div>
//   );
// };

// export default DeleteModal;


const DeleteModal = ({ movie, onClose }) => {
  const handleDelete = async () => {
    try {
      // Send delete request to backend
      await axios.delete(`https://localhost:5001/MovieEntry/Delete/${movie.movieEntryId}`);
      onClose(movie);
    } catch (error) {
      console.error("Error deleting movie:", error);
    }
  };

  return (
    <div className="deleteModal" id={movie.movieEntryId}>
      <h2>Delete Movie</h2>
      <p>Are you sure you want to delete the movie "{movie.title}"?</p>
      <button onClick={handleDelete(movie.movieEntryId)}>Delete</button>
      <button onClick={onClose}>Cancel</button>
    </div>
  );
};

export default DeleteModal;


//axios.post(`sms/${id}`, {params: {id: `${id}`}, _method: 'delete'})