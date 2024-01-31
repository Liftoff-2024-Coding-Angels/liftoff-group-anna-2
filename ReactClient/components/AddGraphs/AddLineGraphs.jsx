import React from "react";
import { Line } from "react-chartjs-2";

const MONTHS = [
  "January",
  "February",
  "March",
  "April",
  "May",
  "June",
  "July",
  "August",
  "September",
  "October",
  "November",
  "December",
];

const LineGraphForMoviesViewedEachMonth = () => {
  const lineGraph = {
    labels: MONTHS,
    datasets: [
      {
        label: "# of Movies Viewed Each Month",
        fill: false,
        lineTension: 0.1,
        backgroundColor: "rgba(75,192,192,0.2)",
        borderColor: "rgba(75,192,192,1)",
        borderCapStyle: "butt",
        borderDash: [],
        borderDashOffset: 0.0,
        borderWidth: 1,
        pointBorderColor: "rgba(75,192,192,1)",
        pointBackgroundColor: "#fff",
        pointBorderWidth: 1,
        pointHoverRadius: 5,
        borderJoinStyle: "miter",
        hoverBackgroundColor: "rgba(75,192,192,0.4)",
        hoverBorderColor: "rgba(75,192,192,1)",
        pointRadius: 1,
        pointHitRadius: 10,
        data: [65, 59, 80, 32, 23, 65, 12, 44, 21, 32, 29, 11], // INSERT REAL DATABASE DATA HERE
      },
    ],
  };
};

const option = {
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
    <h2>Graph #1:</h2>
    <Line data={lineGraph} option={option} />
  </div>
);

export default LineGraphForMoviesViewedEachMonth;
