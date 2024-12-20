import { useEffect, useState } from "react"
import { Spinner } from "reactstrap"
import { getUserDecksByUserId } from "../../managers/deckManager";

export const AddToDeckBtn = ({ card, addCardToDeck, user }) => {
    const [myDecks, setMyDecks] = useState([]);
    const [inMyDeck, setInMyDeck] = useState(false);

    useEffect(() => {
        getAndSetMyDecks(user);
    }, [user])

    useEffect(() => {
        myDecks?.map(deck => {
            deck.deckCards.map(dc => {
                if (dc.cardId === card.id) {
                    return setInMyDeck(true)
                }
                return null;
            });
            return null;
        })
    }, [card, myDecks])


    const getAndSetMyDecks = async (user) => {
        getUserDecksByUserId(user.id).then(res => setMyDecks(res))
    }

    console.log('MyDecks', myDecks)

    return !card || !myDecks ? <Spinner /> :

        myDecks.map(deck => {
            if (inMyDeck === false) {
                return <div key={deck.id} id="add-remove-buttons">
                    <button
                        id="deck-add_btn"
                        className="button"
                        onClick={(e) => addCardToDeck(card.id, deck.id)}>
                        Add To Deck: {`${deck.name}`}
                    </button>
                </div>
            } else {
                return <div key={deck.id} id="disabled-remove-button">
                    <button disabled>Already Added</button>
                </div>
            }
        })
}


