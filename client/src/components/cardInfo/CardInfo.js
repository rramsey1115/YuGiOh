import { Spinner } from "reactstrap";
import "./CardInfo.css";
import { useEffect, useState } from "react";
import { getCardById } from "../../managers/cardManager";
import { useParams } from "react-router-dom";
import { CardData } from "./CardData";

export const CardInfo = () => {
    const { id } = useParams()
    const [card, setCard] = useState({});

    useEffect(() => {
        getAndSetCardById(id)
    }, [id])

    const getAndSetCardById = (id) => {
        getCardById(id).then(setCard)
    }

    return (!card.name ? <Spinner /> :
        <>
            <section id="card-info">
                <CardData card={card} />
                <div id="card-info_img-container">
                    <img id="card-image" src={card.card_images[0].image_url_small} alt={`${card.name} card`} />
                </div>
            </section >
        </>
    )
}