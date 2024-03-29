import { useState } from "react";
import { FaStar } from "react-icons/fa";
import viteLogo from "/vite.svg";
//import "./App.css";
import "./StarRating.scss";

// function StarRating({ onChange }) {
//   const [rating, setRating] = useState(null);
//   const [hover, setHover] = useState(null);

//   const handleStarClick = (value) => {
//     setRating(value);
//     onChange(value); // Notify parent component of the selected rating
//   };

//   return (
//     <div className="StarRating">
//       {[...Array(5)].map((_, index) => {
//         const currentValue = index + 1;
//         return (
//           <label key={index}>
//             <input
//               type="radio"
//               name="rating"
//               value={currentValue}
//               onClick={() => handleStarClick(currentValue)}
//             />
//             <FaStar
//               className="star"
//               size={50}
//               color={currentValue <= (hover || rating) ? "#ffc107" : "#e4e5e9"}
//               onMouseEnter={() => setHover(currentValue)}
//               onMouseLeave={() => setHover(null)}
//             />
//           </label>
//         );
//       })}
//     </div>
//   );
// }

// export default StarRating;


function StarRating() {
  const [rating, setRating ] = useState(null);
  const [hover, setHover] = useState(null);


  return (
    <div className="AddStarRating">
      {[...Array(5)].map((star, index) => {
        const currentRating = index + 1;
        return (
          <label>
            <input
              type="radio"
              name="rating"
              value={currentRating}
              // min="1"
              // max="5"
              onClick={() => setRating(currentRating)}
            />
            <FaStar
              className="star"
              size={50}
              color={currentRating <= (hover || rating) ? "#ffc107" : "#e4e5e9"}
              onMouseEnter={() => setHover(currentRating)}
              onMouseLeave={() => setHover(null)}
            />
          </label>
        );
      })}
    </div>
  );
}

export default StarRating;