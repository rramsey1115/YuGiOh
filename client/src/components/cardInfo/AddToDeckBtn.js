import { useEffect, useState } from "react"
import { Spinner } from "reactstrap"
import { getUserDecksByUserId } from "../../managers/deckManager";

export const AddToDeckBtn = ({ card, addCardToDeck, user }) => {

    const [myDecks, setMyDecks] = useState([]);

    useEffect(() => {
        getAndSetMyDecks(user)
    }, [user])

    const getAndSetMyDecks = (user) => {
        getUserDecksByUserId(user.id).then(res => setMyDecks(res))
    }

    return !card || !myDecks ? <Spinner /> :
        myDecks.map((deck) => {
            return (
                <div key={deck.id} id="add-remove-buttons">
                    <button id="deck-add_btn" className="button" onClick={(e) => addCardToDeck(card.id, deck.id)}>Add To Deck: {`${deck.name}`}</button>
                </div>)
        })

}