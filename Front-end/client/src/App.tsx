import { useEffect, useState } from 'react'
import { BrowserRouter, Outlet, Route, Routes, useNavigate } from 'react-router-dom'
import React from 'react'
import Navbar from './componentes/NavBar'

function App() {
  const navigate = useNavigate();

  useEffect(()=> {
    const token = localStorage.getItem("token")
    if(!token){
      navigate("/auth/login")
    }
  })

  return (
    <div className="App">
      <React.Fragment>
        <Navbar />
        <Outlet />
      </React.Fragment>
    </div>
  )
}

export default App
