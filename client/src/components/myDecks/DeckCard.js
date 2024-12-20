import { Spinner } from "reactstrap"
import "./myDeck.css"

export const DeckCard = ({ card }) => {
    // console.log("card:", card)

    return (!card ? <Spinner /> :
        <div className="deck-card">
            <img src={card.card_images[0].imageUrl} id="deck-card_img" alt="Card Artwork" />
            <button className="button" id="remove-from-deck-btn">Remove</button>
        </div>
    )
}