import React, { useState } from "react";
import axios from "axios";
import moment from "moment"

const EditModal = ({ movie, onClose }) => {
  const [editedTitle, setEditedTitle] = useState(movie.title);
  const [editedDate, setEditedDate] = useState(movie.date);
  const [editedRating, setEditedRating] = useState(movie.numRating);

  function refreshPage() {
    window.location.reload(false);
  }

  const handleEdit = async () => {
    try {
      // Send edit request to backend
      await axios.put(`https://localhost:5001/MovieEntry/Edit/${movie.movieEntryId}`, {
        id: movie.movieEntryId,
        title: editedTitle,
        date: editedDate,
        numRating: editedRating
      });
      // Close modal & refresh movie list
      refreshPage();
      onClose();
    } catch (error) {
      console.error("Error editing movie:", error);
    }
  };

  const correctDateFormat = moment(editedDate).format("MM-DD-YYYY");

  function refreshPage() {
    window.location.reload(false);
  }

  return (
    <div className="editModal">
      <h2>Edit Movie</h2>
      <div className="editModal_title">
      <label>Title:</label>
      <input
        type="text"
        value={editedTitle}
        onChange={(e) => setEditedTitle(e.target.value)}
      />
      </div>
      <div className="editModal_dateWatched">
      <label>Current Date Watched: {correctDateFormat}</label>
      <p>Changed Date? </p>
         <input
        type="date"
        value={editedDate}
        onChange={(e) => setEditedDate(e.target.value)}
      />
      </div>
      <div className="editModal_rating">
      <label>Rating:</label>
      <input
        type="number"
        value={editedRating}
        min = {0}
        max = {5}
        onChange={(e) => setEditedRating(e.target.value)}
      />
      </div>
      <div className="editModal_buttons">
      <button onClick={handleEdit}>Save</button>
      {/* <button onClick={() => {handleEdit; refreshPage();}}>Save</button> */}
      <button onClick={onClose}>Cancel</button>
      </div>
    </div>
  );
};

export default EditModal;
