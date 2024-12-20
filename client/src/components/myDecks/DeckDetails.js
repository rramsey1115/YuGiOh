import { useEffect, useState } from "react"
import { Spinner } from "reactstrap";
import { useParams } from "react-router-dom";
import { getDeckByDeckId } from "../../managers/deckManager";
import { DeckCard } from "./DeckCard";
import "./myDeck.css";

export const DeckDetails = () => {
    const { deckId } = useParams();
    const [deck, setDeck] = useState({});

    useEffect(() => {
        if (deckId) {
            getAndSetDeckByDeckId();
        }
    }, [deckId])

    const getAndSetDeckByDeckId = () => {
        getDeckByDeckId(deckId).then(res => setDeck(res[0]))
    }

    return (!deck.deckCards ? <Spinner /> : <>
        {/* {console.log("deck", deck)} */}
        <section className="container" id="deck-main">
            <section className="header" id="deck-header">
                <h1 id="deck-header_title">Deck: {deck.name}</h1>
            </section>
            <div id="deck-cards-container">
            {deck.deckCards.length < 1 ? <h3>No Cards in Deck Yet!</h3> :
                deck.deckCards.map((deckCard) => {
                    return <DeckCard card={deckCard.card} key={deckCard.id} />
                })}
            </div>
        </section>
    </>)
}