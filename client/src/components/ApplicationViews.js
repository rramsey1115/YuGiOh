import { Route, Routes } from "react-router-dom";
import { AuthorizedRoute } from "./auth/AuthorizedRoute";
import Login from "./auth/Login";
import Register from "./auth/Register";
import { Home } from "./home/Home";
import { MyCardsList } from "./myCards/MyCardsList";
import { MyDecksList } from "./myDecks/MyDecksList";

export default function ApplicationViews({ loggedInUser, setLoggedInUser }) {
  return (
    <Routes>
      <Route path="/">
        <Route
          index
          element={
            <AuthorizedRoute loggedInUser={loggedInUser}>
              <Home loggedInUser={loggedInUser}/>
            </AuthorizedRoute>
          }
        />

        <Route path="mycards">
          <Route path=":id"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <MyCardsList loggedInUser={loggedInUser} />
              </AuthorizedRoute>
            }
          />
        </Route>

        <Route path="decks">
          <Route path=":id"
            element={
              <AuthorizedRoute loggedInUser={loggedInUser}>
                <MyDecksList loggedInUser={loggedInUser} />
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
  );
}
