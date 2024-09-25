import { Spinner } from "reactstrap";
import "./CardInfo.css";
import { useEffect, useState } from "react";
import { getCardById } from "../../managers/cardManager";
import { useParams } from "react-router-dom";

export const CardInfo = () => {
    const {id} = useParams()
    const [card, setCard] = useState({});

    useEffect(() => {
        getAndSetCardById(id)
    }, [id])

    const getAndSetCardById = (id) => {
        getCardById(id).then(setCard)
    }
    
    return (
        !card.name ? <Spinner /> : 
        <>
        {console.log(card)}
            <h1>Card Info</h1>
            <h3>Name: {card.name}</h3>
            <h3>Attack: {card.atk}</h3>
            <h3>Defense: {card.def}</h3>
            <h3>Attribute: {card.attribute}</h3>
            <h3>Description: {card.desc}</h3>
            <h3>Race: {card.race}</h3>
            <h3>Level: {card.level}</h3>
            <h3>Type: {card.type}</h3>
            {/* <img id="card-image" src={card.card_images[0].image_url_small} alt={`${card.name} card`} /> */}
        </>
    )
}