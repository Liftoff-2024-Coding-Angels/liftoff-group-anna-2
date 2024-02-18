import React, { useEffect, useState } from "react";
import StarRating from "./StarRating";
import "./MovieForm.scss";
import axios from "axios";
//TO DO:
// CONNECT DATABASE

const MovieForm = () => {
  const [formData, setFormData] = useState({
    title: "",
    dateWatched: "",
    rating: "",
  });

  // const handleSubmit = (e) => {
  //   e.PreventDefault();
  //   useEffect(() => {
  //     axios.post("https://localhost:5001/").then((response) => {
  //       setFormData(response.data)
  //     } catch (error)
  //     {
  //       console.log("Error fetching data:", error);
  //     })
  //  })
  //   console.log("Form Sumbitted", formData);
  // };

  const handleSubmit = async (e) => {
    e.preventDefault();
    try {
      const response = await axios.post("https://localhost:5001/", formData);
      setFormData(response.data);
      console.log("Post created:", response.data);
    } catch (error)
    {
      console.error("Error creating post:", error);
    }
    };
  

  const handleChange = (e) => {
    // e.PreventDefault();
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  // const handleRatingChange = (NewRating) => {
  //   setFormData({ ...formData, rating: NewRating });
  // };

  return (
    <div className="movieFormBox">
      <form className="movieForm" onSubmit={handleSubmit}>

        <div className="movieForm_title">
          <label htmlFor="title">Title: </label>
            <input
              type="text"
              id="title"
              name="title"
              value={formData.title}
              onChange={handleChange}
              required
            />
       </div>

        <div className="movieForm_dateWatched">
          <label htmlFor="dateWatched">Date Watched: </label>
            <input
              type="date"
              id="dateWatched"
              name="dateWatched"
              value={formData.dateWatched}
              onChange={handleChange}
              required
            />
        </div>

        <div className="movieForm_rating">
           <div className="movieForm_ratingLabel"><label htmlFor="rating">Rating:</label></div>
           <div className="movieForm_stars"> <StarRating onChange={handleChange} /></div>
        </div>

        <div className="movieForm_buttons">
          <button className="movieForm_cancelButton">Cancel</button>
          <button className="movieForm_submitButton" type="submit">Submit</button>
        </div>

      </form>
    </div>
  );

};

export default MovieForm;