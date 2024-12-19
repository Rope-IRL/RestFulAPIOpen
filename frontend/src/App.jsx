import {
  Route,
  Routes,
  RouterProvider,
  createBrowserRouter,
  createRoutesFromElements,
} from "react-router-dom";
import { useState, lazy, Suspense } from "react";
import { Provider } from "react-redux";
import { store } from "./store";
import "./App.css";
import Layout from "./components/Layout/Layout";

const FlatsRentPage = lazy(() => import("./pages/FlatsRentPage/FlatsRentPage"));
const HouseRentPage = lazy(() => import("./pages/HouseRentPage/HouseRentPage"));
const SingleHousePage = lazy(
  () => import("./pages/HouseRentPage/SingleHousePage/SingleHousePage"),
);
const HotelRentPage = lazy(() => import("./pages/HotelRentPage/HotelRentPage"));
const SingleRoomPage = lazy(() => import("./pages/HotelRentPage/SingleHotelPage/SingleRoomPage"))
const MainPage = lazy(() => import("./pages/MainPage/MainPage"));
const NotFoundPage = lazy(() => import("./pages/NotFoundPage/NotFoundPage"));
const SingleFlatPage = lazy(
  () => import("./pages/FlatsRentPage/SingleFlatPage/SingleFlatPage"),
);
const LandlordLogin = lazy(
  () => import("./pages/AuthLandlord/LandllordLogin/LandlordLogin"),
);
const LandlordRegister = lazy(() => import("./pages/AuthLandlord/RegisterLandlord/RegisterLandlord"))
const LandlordProfile = lazy(
  () => import("./pages/ProfileLandlord/ProfileLandlord"),
);

const LesseeLogin = lazy(
  () => import("./pages/AuthLessee/LesseeLogin/LesseeLogin")
)
const LesseeRegister = lazy(() => import("./pages/AuthLessee/RegisterLessee/RegisterLessee"))
const LesseeProfile = lazy(() => import("./pages/ProfileLessee/ProfileLessee"))

const router = createBrowserRouter(
  createRoutesFromElements(
    <Route path="/" element={<Layout />}>
      <Route index element={<MainPage />} />
      <Route path="flats" element={<FlatsRentPage />} />
      <Route path="flat/:id" element={<SingleFlatPage />} />
      <Route path="houses" element={<HouseRentPage />} />
      <Route path="house/:id" element={<SingleHousePage />} />
      <Route path="hotels" element={<HotelRentPage />} />
      <Route path="room/:id" element={<SingleRoomPage />} />
      <Route path="login/landlord" element={<LandlordLogin />} />
      <Route path="register/landlord" element = {<LandlordRegister />} />
      <Route path="profile/landlord" element={<LandlordProfile />} />
      <Route path="login/lessee" element={<LesseeLogin />} />
      <Route path="register/lessee" element = {<LesseeRegister />} />
      <Route path="profile/lessee" element={<LesseeProfile />} />
      <Route path="*" element={<NotFoundPage />} />
    </Route>,
  ),
);

function App() {
  return (
    <Provider store={store}>
      <RouterProvider router={router} />
    </Provider>
  );
}

export default App;
