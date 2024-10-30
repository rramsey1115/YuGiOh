import { useContext, useEffect, useState } from "react";
import { Button, Spinner } from "reactstrap";
import { addUserCard, getUserCardsByUserId, removeUserCard } from "../../managers/cardManager";
import { Context } from "../ApplicationViews";

export const CardInfoButtons = ({ card }) => {
    const user = useContext(Context);
    const [myCards, setMyCards] = useState([]);
    const [isMyCard, setIsMyCard] = useState(false);
    const [loading, setLoading] = useState(true); // New loading state

    useEffect(() => {
        if (user) {
            getAndSetMyCards(user.id);
        }
    }, [user]);

    useEffect(() => {
        findOutIfIsMyCard();
    }, [myCards, card]);

    const getAndSetMyCards = async (id) => {
        setLoading(true); // Start loading
        const res = await getUserCardsByUserId(id);
        setMyCards(res);
        setLoading(false); // Stop loading
    };

    const findOutIfIsMyCard = () => {
        const bool = myCards.some(myCard => myCard.card.id === card.id);
        setIsMyCard(bool);
    };

    const addToMyCards = async (userId, cardId) => {
        await addUserCard(cardId, userId);
        await getAndSetMyCards(user.id);
        console.log(`addToMyCards called - UserId=${userId}, CardId=${cardId}`);
    };

    const removeFromMyCards = async (userId, cardId) => {
        await removeUserCard(cardId, userId);
        await getAndSetMyCards(user.id);
        console.log(`RemoveFromMyCards Called - UserId=${userId}, CardId=${cardId}`);
    };

    if (loading) {
        return <Spinner />; 
    }

    return (
        <div id="card-info_buttons">
            {isMyCard ? (
                <Button
                    className="card-info_btn btn-secondary"
                    id="info-remove_btn"
                    onClick={() => { removeFromMyCards(user.id, card.id) }}>
                    Remove from My Cards
                </Button>
            ) : (
                <Button
                    className="card-info_btn btn"
                    id="info-add_btn"
                    onClick={() => { addToMyCards(user.id, card.id) }}>
                    Add to My Cards
                </Button>
            )}
            <Button className="card-info_btn btn-primary" id="info-fav__btn">Favorite</Button>
        </div>
    );
}
