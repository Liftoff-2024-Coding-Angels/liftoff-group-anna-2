import React, { useState } from "react";
import AddStarRating from "../AddStarRating/AddStarRating";

//TO DO:
// CONNECT DATABASE

const MovieForm = () => {
  const [formData, setFromData] = useState({
    tite: "",
    dateWatched: "",
    rating: "",
  });

  const handleSubmit = (e) => {
    e.PreventDefault();
    // NEED CODE TO SEND FORM DATA TO THE SERVER
    console.log("Form Sumbitted", formData);
  };

  const handleChange = (e) => {
    // e.PreventDefault();
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleRatingChange = (NewRating) => {
    setFromData({ ...formData, rating: NewRating });
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label htmlFor="title">Title:</label>
        <input
          type="text"
          id="title"
          name="title"
          value={formData.title}
          onChange={handleChange}
          required
        />
      </div>
      <div>
        <label htmlFor="dateWatched">Date Watched:</label>
        <input
          type="date"
          id="dateWatched"
          name="dateWatched"
          value={formData.dateWatched}
          onChange={handleChange}
          required
        />
      </div>
      <div>
        <label htmlFor="rating">Rating:</label>
        <AddStarRating onRatingChange={handleRatingChange} />
      </div>
      <button type="submit">Submit</button>
    </form>
  );

  //still need to figure out a way to include AddStarRating to the form... not sure if this works ^^
};

export default MovieForm;
