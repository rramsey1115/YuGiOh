import { Spinner } from "reactstrap";
import "./CardInfo.css";
import { useContext, useEffect, useState } from "react";
import { getCardById, getUserCardsByUserId } from "../../managers/cardManager";
import { useParams } from "react-router-dom";
import { CardData } from "./CardData";
import { CardInfoButtons } from "./CardInfoButtons";
import { Context } from "../ApplicationViews";

export const CardInfo = () => {
    const { id } = useParams()
    const [card, setCard] = useState({});
    const [isMyCard, setIsMyCard] = useState(false);
    const [myCards, setMyCards] = useState([]);
    const [loading, setLoading] = useState(true); // New loading state
    const user = useContext(Context);

    useEffect(() => {
        findOutIfIsMyCard();
    }, [myCards, card]);

    useEffect(() => {
        getAndSetCardById(id)
    }, [id])

    useEffect(() => {
        if (user) {
            getAndSetMyCards(user.id);
        }
    }, [user]);

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

    const getAndSetCardById = (id) => {
        getCardById(id).then(setCard)
    }

    return (!card.name || loading ? <Spinner /> :
        <>
            <section id="card-info">
                <CardData card={card} />
                <div id="card-info_img-container">
                    <img id="card-image" src={card.card_images[0].image_url_small} alt={`${card.name} card`} />
                    {card ? <CardInfoButtons card={card} user={user} isMyCard={isMyCard} getAndSetMyCards={getAndSetMyCards}/> : <Spinner />}
                </div>
            </section >
        </>
    )
}