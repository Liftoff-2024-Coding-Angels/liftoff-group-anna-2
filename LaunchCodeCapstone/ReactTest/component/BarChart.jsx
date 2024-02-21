// BarChart.js
import React, {useState, useEffect} from "react";
import 'chart.js/auto';
import axios from "axios";
import { Bar } from "react-chartjs-2";

const BarChart = () => {

  const [movieData, setMovieData] = useState([]);
  const [ratingCounts, setRatingCounts] = useState(Array(5).fill(0));

  const fetchMovies = async () => {
    try {
      const response = await axios.get("https://localhost:5001/MovieEntry/Read");
      //setMovies(response.data); // Assuming API returns an array of movie objects
      setMovieData(response.data);
      fetchRatingTotalCount(response.data);
      console.log("API Response:", response);
      console.log(response.data);
      //console.log("Movie Data:", response.data);
    } catch (error) {
      console.error("Error fetching movies:", error);
    }
  };

  
  useEffect(() => {
    fetchMovies();
  }, []);

  const fetchRatingTotalCount = (movies) =>
  {
    const count = Array(5).fill(0);
    movies.forEach(movie => {
      const rating = movie.numRating;
      if (rating >= 1 && rating <= 5) {
        count[rating - 1]++;
      }
    });
    setRatingCounts(count);
  }

  const data = {
    labels: ["1 Star", "2 Stars", "3 Stars", "4 Stars", "5 Stars"],
    datasets: [
      {
        label: "Number of Movies",
        backgroundColor: "#584B53", // "#D6E3F8",
        borderColor: "#FEF5EF",
        borderWidth: 1,
        hoverBackgroundColor: "#ccc" ,
        hoverBorderColor: "#9D5C63",
        data: ratingCounts
      },
    ],
  };

  const option = {
    scales: {
      xAxes: [
        {
          scaleLabel: {
            display: true,
            labelString: "Rating (in Stars)",
          },
        },
      ],
      yAxes: [
        {
          scaleLabel: {
            display: true,
            labelString: "Number of Movies",
          },
        },
      ],
    },
  };

  return (
    <div>
      <h2>Movies per Rating:</h2>
      <Bar data={data} option={option}/>
    </div>
  );
};

export default BarChart;