import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import StarRating from '../component/StarRating'
import BarChart from '../component/BarChart'
import { DoughnutChart } from '../component/DoughnutChart'
import LineChart from '../component/LineChart'
import MovieForm from '../component/MovieForm'
import MovieList from "../component/ListedMovies"

function App() {
  

  return (
    <div className="container">
    <div className="header">
      <h1>Frame Rate</h1>
    </div>
    <div className="content">
      <div className="movieform-container">
        <MovieForm />
      </div>
      <div className="movielist-container">
        <MovieList />
      </div>
      <div className="graph-container">
        <LineChart />
        <BarChart />
      </div>
    </div>
  </div>
  )
}

export default App
