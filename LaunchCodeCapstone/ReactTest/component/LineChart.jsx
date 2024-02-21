import React, { useState, useEffect } from "react";
import axios from "axios";
import { Line } from 'react-chartjs-2';

const LineChart = () => {
  const MONTHS = [
    "January", "February", "March", "April", "May", "June",
    "July", "August", "September", "October", "November", "December"
  ];

  const [movieData, setMovieData] = useState([]);

  
    const fetchMovies = async () => {
      try {
        const response = await axios.get("https://localhost:5001/MovieEntry/Read");
        setMovieData(response.data);
      } catch (error) {
        console.error("Error fetching movies:", error);
      }
    };

    useEffect(() => {
    fetchMovies();
  }, []);

  //Grab # of movies watched each month
  const getMoviesPerMonth = () => {
    //sets an array with the length of 12, each index initialized to 0 via the fill() method
    const moviesPerMonth = Array(12).fill(0); 
    //foreach loop through each movie object in movieData[]
    movieData.forEach(movie => {
      //use date object to parse date-string. GetMonth() returns the index value for the month (0 = January, 1 = February, etc)
      const month = new Date(movie.date).getMonth();
      //grab the array, use the month as index, increment each index value by 1 per each occurance
      moviesPerMonth[month]++; 
    });
    return moviesPerMonth;
  };

  const lineGraph = {
    labels: MONTHS,
    datasets: [
      {
        label: "# of Movies Viewed Each Month",
        fill: false,
        lineTension: 0.1,
        backgroundColor:"#FEF5EF", //"rgba(75,192,192,0.2)",
        borderColor: "#ccc",
        borderCapStyle: "butt",
        borderDash: [],
        borderDashOffset: 0.0,
        borderWidth: 1,
        pointBorderColor: "#9D5C63",
        pointBackgroundColor: "#fff",
        pointBorderWidth: 4,
        pointHoverRadius: 5,
        borderJoinStyle: "miter",
        hoverBackgroundColor: "#9D5C63",
        hoverBorderColor: "#9D5C63",
        pointRadius: 1,
        pointHitRadius: 10,
        data: getMoviesPerMonth(), //call the function to grab the # of movies watched each months data
      },
    ],
  };

  const options = {
    scales: {
      xAxes: [
        {
          scaleLabel: {
            display: true,
            labelString: "Month",
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
      <h2>Line Graph</h2>
      <Line data={lineGraph} options={options} />
    </div>
  );
};

export default LineChart;
