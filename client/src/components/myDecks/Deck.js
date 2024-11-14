import "./myDeck.css";
import { Spinner } from "reactstrap";

export const Deck = ({ deck }) => {

    return (!deck ? <Spinner /> :
        <div className="deck-container">
            <h2>{deck.name}</h2>
            <h5>Cards in Deck: {deck.deckCards.length}</h5>
        </div>)
}