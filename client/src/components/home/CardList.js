import * as React from 'react';
import { useState, useEffect } from 'react';
import { getAllCards } from '../../managers/cardManager';
import "./CardList.css";
import monster from "../../images/monster-card-template.png";
import extra from "../../images/extra-deck-template.png";
import spell from "../../images/spell-card-template.png";
import trap from "../../images/trap-card-template.png";
import back from "../../images/back-card-template.jpg";
import { useNavigate } from 'react-router-dom';
import { Spinner } from 'reactstrap';

export const CardGrid = () => {
    const [cards, setCards] = useState([]);

    useEffect(() => { getAndSetAllCards() }, [])

    const getAndSetAllCards = () => { getAllCards().then(setCards) };

    const navigate = useNavigate();

    const handleCardClick = (e) => {
        navigate(`card/${e.currentTarget.dataset.cardId}`);
    }

    return (
        !cards ? <Spinner />
        :
        <table id="card-list-table" className='card-list-table'>
            <thead>
                <tr>
                    <td></td>
                    <td><h4>Name</h4></td>
                    <td><h4>Type</h4></td>
                    <td><h4>Race</h4></td>
                </tr>
            </thead>
            <tbody>  
                {cards.map(card => {
                    return (
                        <tr 
                            className="card-table-tr"
                            key={card.id} 
                            data-card-id={card.id} 
                            onClick={(e) => {
                                handleCardClick(e)
                            }}
                        >
                            {card.type == "Normal Monster" || card.type == "Flip Effect Monster" || card.type == "Effect Monster"  
                            ? <td><img className="card-icon" alt="card icon" src={monster}/></td> 
                            : card.type == "Spell Card" ? <td><img className="card-icon" alt="card icon" src={spell}/></td>
                            : card.type == "Fusion Monster" ? <td><img className="card-icon" alt="card icon" src={extra}/></td>
                            : card.type == "Trap Card" ? <td><img className="card-icon" alt="card icon" src={trap}/></td>
                            : <td><img className="card-icon" alt="card icon" src={back}/></td> }
                            <td 
                               
                            >{card.name}</td>
                            <td>{card.type}</td>
                            <td>{card.race}</td>
                        </tr>
                    )
                })}
            </tbody>
        </table>
    );
}