import { useEffect, useState } from "react"
import { Spinner } from "reactstrap";
import { useParams } from "react-router-dom";
import { getDeckByDeckId } from "../../managers/deckManager";
import { DeckCard } from "./DeckCard";

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
        {console.log("deck", deck)}
        <section className="header" id="deck-header">
            <h1 id="deck-header_title">Deck: {deck.name}</h1>
            <h3 id="deck-main_title">{deckId}</h3>
        </section>
        <section className="main" id="deck-main">
            <div className="main-cards-container">
                {deck.deckCards.length < 1 ? <h3>No Cards in Deck Yet!</h3> :
                    deck.deckCards.map((deckCard) => {
                        return <DeckCard card={deckCard.card} key={deckCard.id} />
                    })}
            </div>
        </section>
    </>)
}