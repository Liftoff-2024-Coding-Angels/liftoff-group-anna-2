import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import StarRating from '../component/StarRating'
import BarChart from '../component/BarChart'
import { DoughnutChart } from '../component/DoughnutChart'
import LineChart from '../component/LineChart'
import MovieForm from '../component/MovieForm'

function App() {
  

  return (
    <>
      {/* <StarRating />
      <BarChart />
      <DoughnutChart />
      <LineChart /> */}
      <MovieForm />
    </>
  )
}

export default App
