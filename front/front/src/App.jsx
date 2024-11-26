import {Route, Routes, RouterProvider, createBrowserRouter, createRoutesFromElements} from "react-router-dom"  
import { useState, lazy, Suspense } from 'react'
import './App.css'
import Layout from "./components/Layout/Layout"

const FlatsRentPage = lazy(() => import("./pages/FlatsRentPage/FlatsRentPage"))
const HouseRentPage = lazy(() => import("./pages/HouseRentPage/HouseRentPage"))
const HotelRentPage  = lazy(() => import("./pages/HotelRentPage/HotelRentPage"))
const MainPage = lazy(() => import("./pages/MainPage/MainPage"))
const NotFoundPage = lazy(() => import("./pages/NotFoundPage/NotFoundPage" ))
const SingleFlatPage = lazy(() => import("./pages/FlatsRentPage/SingleFlatPage/SingleFlatPage"))

const router = createBrowserRouter(createRoutesFromElements(
  <Route path="/" element = {<Layout />}>
    <Route index element = {<MainPage />} />
    <Route path = "flats" element = {<FlatsRentPage />} />
    <Route path = "flat/:id" element = {<SingleFlatPage />} />
    <Route path = "houses" element = { <HouseRentPage /> } />
    <Route path = "hotels" element = { <HotelRentPage /> } />
    <Route path="*" element = {<NotFoundPage />}/>
 </Route>
))

function App() {
  return (
    <RouterProvider router={router}/>
  )
}

export default App
