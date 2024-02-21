import React from "react";
import 'chart.js/auto';
import { Doughnut } from "react-chartjs-2";

const DoughnutChart = () => {
  const data = {
    labels: ["Label 1", "Label 2", "Label 3"],
    datasets: [
      {
        data: [30, 50, 20],
        backgroundColor: ["#FF6384", "#36A2EB", "#FFCE56"],
        hoverBackgroundColor: ["#FF6384", "#36A2EB", "#FFCE56"],
      },
    ],
  };

  // Define cutout as a percentage of doughnut hole & add a circular animation to the graph
  const options = {
    cutout: "50%",
    animation: {
      animateRotate: true,
    },
  };

  return (
    <div>
      <h2>Doughnut Chart</h2>
      <Doughnut data={data} options = {options} />
    </div>
  );
};

export {DoughnutChart};