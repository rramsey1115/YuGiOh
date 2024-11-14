import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { Home } from "./home/Home";
import { MyCardsList } from "./myCards/MyCardsList";
import { MyDecksList } from "./myDecks/MyDecksList";
import { CardInfo } from "./cardInfo/CardInfo";
import React from "react";

export const Context = React.createContext();

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {

  return (
    <Context.Provider value={loggedInUser}>
      <Routes>
        <Route path="/">
          <Route
            index
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <Home />
              </AuthorizedRoute>
            }
          />

          <Route path="cardInfo">
            <Route path=":id"
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <CardInfo />
                </AuthorizedRoute>
              } />
          </Route>

          <Route path="myCards">
            <Route path=":id"
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <MyCardsList />
                </AuthorizedRoute>
              }
            />
          </Route>

          <Route path="myDecks">
            <Route path=":id"
              element={
                <AuthorizedRoute loggedInUser={loggedInUser}>
                  <MyDecksList />
                </AuthorizedRoute>
              }
            />
          </Route>

          <Route
            path="login"
            element={<Login setLoggedInUser={setLoggedInUser} />}
          />
          <Route
            path="register"
            element={<Register setLoggedInUser={setLoggedInUser} />}
          />
        </Route>

        <Route path="*" element={<p>Whoops, nothing here...</p>} />
      </Routes>
    </Context.Provider>
  );
}
