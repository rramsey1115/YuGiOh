import { useContext, useEffect, useState } from "react"
import { Deck } from "./Deck"
import { Context } from "../ApplicationViews";
import { Spinner } from "reactstrap";
import { getUserDecksByUserId } from "../../managers/deckManager";

export const MyDecksList = () => {
    const user = useContext(Context);

    const [myDecks, setMyDecks] = useState([]);

    useEffect(() => {if (user.id) getAndSetUserDecks()}, [])

    const getAndSetUserDecks = () => {
        getUserDecksByUserId(user.id).then(setMyDecks)
    }

    return (myDecks.length === 0 || !myDecks ? <Spinner /> :
        <section className="container">
            <header className="header">
                <h1>My Decks</h1>
            </header>
            <section className="main">
                {myDecks.map((deck) => <Deck deck={deck} key={deck.id}/>)}
            </section>
        </section>
    )
}