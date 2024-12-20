/* eslint-disable react-hooks/exhaustive-deps */

import { Spinner } from "reactstrap";
import { addUserCard, removeUserCard } from "../../managers/cardManager";
import { AddToDeckBtn } from "./AddToDeckBtn";
import { addCardToDeckCards } from "../../managers/deckManager";

export const CardInfoButtons = ({ card, user, isMyCard, getAndSetMyCards }) => {

    const addToMyCards = async (userId, cardId) => {
        await addUserCard(cardId, userId);
        await getAndSetMyCards(user.id);
        // console.log(`addToMyCards called - UserId=${userId}, CardId=${cardId}`);
    };

    const removeFromMyCards = async (userId, cardId) => {
        await removeUserCard(cardId, userId);
        await getAndSetMyCards(user.id);
        // console.log(`RemoveFromMyCards Called - UserId=${userId}, CardId=${cardId}`);
    };

    const addCardToDeck = async (deckId, cardId) => {
        await addCardToDeckCards(deckId, cardId);
        await getAndSetMyCards(user.id);
    }

    return !user ? <Spinner /> :
        <div id="card-info_buttons">
            <div>
                {isMyCard ? (
                    <button
                        className="card-info_btn button"
                        id="info-remove_btn"
                        onClick={() => { removeFromMyCards(user.id, card.id) }}>
                        Remove from My Cards
                    </button>
                ) : (
                    <button
                        className="card-info_btn button"
                        id="info-add_btn"
                        onClick={() => { addToMyCards(user.id, card.id) }}>
                        Add to My Cards
                    </button>
                )}
            </div>
            {isMyCard ?
               <AddToDeckBtn card={card} addCardToDeck={addCardToDeck} user={user}/>
                : ""
            }
        </div>
}
