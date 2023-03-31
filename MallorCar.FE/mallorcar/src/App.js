import logo from "./logo.svg";
import "./App.css";
import Header from "./components/Header/Header.jsx";
import "./fonts/TESLA.ttf";
import MainBox from "./components/MainBox/MainBox";
import { useState } from "react";
import axios from "axios";
import { useEffect } from "react";
import CarSelection from "./components/CarSelection/CarSelection";
import Form from "./components/Form/Form";
import MainPage from "./components/MainPage/MainPage";
import { Routes, Route } from "react-router-dom";
import AdminPage from "./components/AdminPag/AdminPage"
import BookingPage from "./components/BookingPage/BookingPage";

function App() {
  return (
    <div className="App">
      <div className="background"></div>
      <Header />
      <Routes>
        <Route path="/" element={<MainPage />} />
        <Route path="/admin" element={<AdminPage/>}/>
        <Route path="/booking" element={<BookingPage/>} />
      </Routes>
    </div>
  );
}

export default App;
