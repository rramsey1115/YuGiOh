import { useContext } from "react"
import { Context } from "../ApplicationViews"

export const MyCardsList = ({ loggedInUser }) => {

    const user = useContext(Context);

    console.log("user:", user)

    return (
        <section className="container">
            <header className="header">
                <h2>My Cards List</h2>
            </header>
            <section className="main">

            </section>
        </section>
    )
}