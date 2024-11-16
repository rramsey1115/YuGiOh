import { useNavigate } from "react-router-dom";
import "./myDeck.css";
import { Spinner } from "reactstrap";

export const Deck = ({ deck }) => {
    const navigate = useNavigate();

    return (!deck ? <Spinner /> :
        <div className="deck-container" onClick={() => { navigate(`/myDecks/details/${deck.id}`) }}>
            <h2>{deck.name}</h2>
            <h5>Cards in Deck: {deck.deckCards.length}</h5>
        </div>)
}