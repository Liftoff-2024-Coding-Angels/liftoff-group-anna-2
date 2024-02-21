import React, { useEffect, useState } from "react";
import StarRating from "./StarRating";
import "./MovieForm.scss";
import { FaStar } from "react-icons/fa";
import axios from "axios";
import { format } from "date-fns";

//TO DO:
// have Date & Rating be sent to database

// const MovieForm = () => {
//   const [formData, setFormData] = useState({
//     title: "",
//     dateWatched: new Date(),
//     rating: 0,
//   });

//   // function handleSubmit (e) {
//   //   e.preventDefault();
//   //   useEffect(() => {
//   //     axios.post("https://localhost:5001/Create").then((response) => {
//   //       setFormData(response.data)
//   //  })
//   //   console.log("Form Sumbitted", formData);
//   // })};

//   const handleSubmit = async (e) => {
//     e.preventDefault();
//     try {
//       const response = await axios.post("https://localhost:5001/Create", formData);
//       setFormData(response.data);
//       console.log("Post created:", response.data);
//     } catch (error)
//     {
//       console.error("Error creating post:", error);
//     }
//     };
  

//   const handleChange = (e) => {
//     const { name, value } = e.target;
//     setFormData({ ...formData, [name]: value });
//   };

//   const handleRatingChange = (NewRating) => {
//     setFormData({ ...formData, rating: NewRating });
//   };

//   return (
//     <div className="movieFormBox">
//       <form className="movieForm" onSubmit={handleSubmit}>

//         <div className="movieForm_title">
//           <label htmlFor="title">Title: </label>
//             <input
//               type="text"
//               id="title"
//               name="title"
//               value={formData.title}
//               onChange={handleChange}
//               required
//             />
//        </div>

//         <div className="movieForm_dateWatched">
//           <label htmlFor="dateWatched">Date Watched: </label>
//             <input
//               type="date"
//               id="dateWatched"
//               name="dateWatched"
//               value={format(formData.dateWatched, "yyyy-MM-dd")}
//               onChange={handleChange}
//               required
//             />
//         </div>

//         <div className="movieForm_rating">
//            <div className="movieForm_ratingLabel"><label htmlFor="rating">Rating:</label></div>
//            <div className="movieForm_stars"> <StarRating value={formData.rating} onChange={handleRatingChange} /></div>
//         </div>

//         <div className="movieForm_buttons">
//           <button className="movieForm_cancelButton">Cancel</button>
//           <button className="movieForm_submitButton" type="submit">Submit</button>
//         </div>

//       </form>
//     </div>
//   );

// };

// export default MovieForm;


const MovieForm = () => {
  const [formData, setFormData] = useState({
    Title: "",
    Date: new Date(),
    NumRating: null,
  });

  const handleSubmit = async (e) => {
        e.preventDefault();
        try {
          const response = await axios.post("https://localhost:5001/Create", formData);
          setFormData(response.data);
          console.log("Post created:", response.data);
        } catch (error)
        {
          console.error("Error creating post:", error);
        }
        };

  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const handleStarClick = (ratingValue) => {
    setFormData({ ...formData, NumRating: ratingValue });
  };

  return (
    <div className="movieFormBox">
      <form className="movieForm" onSubmit={handleSubmit}>
        <div className="movieForm_title">
          <label htmlFor="title">Title: </label>
          <input
            type="text"
            id="Title"
            name="Title"
            value={formData.Title}
            onChange={handleChange}
            required
          />
        </div>

        <div className="movieForm_dateWatched">
          <label htmlFor="dateWatched">Date Watched: </label>
          <input
            type="date"
            id="Date"
            name="Date"
            value={formData.Date}
            onChange={handleChange}
            required
          />
        </div>

        <div className="movieForm_rating">
          <div className="movieForm_ratingLabel">
            <label htmlFor="rating">Rating:</label>
          </div>
          <div className="movieForm_stars">
            {[...Array(5)].map((_, index) => {
              const ratingValue = index + 1;
              return (
                <label key={index}>
                  <input
                    type="radio"
                    name="rating"
                    value={ratingValue}
                    onClick={() => handleStarClick(ratingValue)}
                  />
                  <FaStar
                    className="star"
                    size={50}
                    color={ratingValue <= (formData.NumRating || 0) ? "#ffc107" : "#e4e5e9"}
                  />
                </label>
              );
            })}
          </div>
        </div>

        <div className="movieForm_buttons">
          <button className="movieForm_cancelButton">Cancel</button>
          <button className="movieForm_submitButton" type="submit">
            Submit
          </button>
        </div>
      </form>
    </div>
  );
};

export default MovieForm;

