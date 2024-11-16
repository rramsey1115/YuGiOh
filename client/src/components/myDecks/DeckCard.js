import { Spinner } from "reactstrap"

export const DeckCard = ({ card }) => {
    console.log("deckCard:", card)

    return (!card ? <Spinner /> :
        <div className="deck-card">
            <header>
                <h5>{card.name}</h5>
                <p>{card.race}</p>
                <p>{card.type}</p>
            </header>
        </div>)
}