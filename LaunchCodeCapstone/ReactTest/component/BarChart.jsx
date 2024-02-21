// BarChart.js
import React from "react";
import 'chart.js/auto';
import { Bar } from "react-chartjs-2";

const BarChart = () => {
  const data = {
    labels: ["Label 1", "Label 2", "Label 3", "Label 4"],
    datasets: [
      {
        label: "Bar Chart",
        backgroundColor: "rgba(75,192,192,0.2)",
        borderColor: "rgba(75,192,192,1)",
        borderWidth: 1,
        hoverBackgroundColor: "rgba(75,192,192,0.4)",
        hoverBorderColor: "rgba(75,192,192,1)",
        data: [65, 59, 80, 81],
      },
    ],
  };

  return (
    <div>
      <h2>Bar Chart</h2>
      <Bar data={data} />
    </div>
  );
};

export default BarChart;