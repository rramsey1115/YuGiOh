import { useContext } from "react"
import { Context } from "../ApplicationViews"
import * as React from 'react';
import { useState, useEffect } from 'react';
import { getUserCardsByUserId } from '../../managers/cardManager';
import "../home/CardList.css";
import monster from "../../images/monster-card-template.png";
import extra from "../../images/extra-deck-template.png";
import spell from "../../images/spell-card-template.png";
import trap from "../../images/trap-card-template.png";
import back from "../../images/back-card-template.jpg";
import { useNavigate } from 'react-router-dom';
import { Spinner } from 'reactstrap';
import { CardLevelStars } from "../home/CardLevelStars";

export const MyCardsList = () => {

    const user = useContext(Context);

    const [myCards, setMyCards] = useState([]);

    useEffect(() => { getAndSetMyCards() }, [])

    const getAndSetMyCards = () => { getUserCardsByUserId(user.id).then(setMyCards) };

    const navigate = useNavigate();

    const handleCardClick = (e) => {
        console.log("event", e.currentTarget)
        navigate(`/cardInfo/${e.currentTarget.dataset.cardId}`);
    }

    const convertAtt = (str) => {
        if (!str) { return "" }
        return str.charAt(0).toUpperCase() + str.slice(1).toLowerCase();
    }

    return (!myCards ? <Spinner />
        : <section className="container">
            <header className="header">
                <h1>My Cards</h1>
            </header>
            <section className="filters">
                <h5 className="filter-item">Filter By:</h5>
                <h5 className="filter-item">Level</h5>
                <h5 className="filter-item">Type</h5>
                <h5 className="filter-item">Attribute</h5>
            </section>
            <section className="body">
                <table id="card-list-table" className='card-list-table'>
                    <thead>
                        <tr>
                            <td></td>
                            <td><h4>Name</h4></td>
                            <td><h4>Type</h4></td>
                            <td><h4>Attribute</h4></td>
                            <td><h4>Level</h4></td>
                        </tr>
                    </thead>
                    <tbody>
                        {myCards?.map(mc => {
                            return (
                                <tr
                                    className="card-table-tr"
                                    key={mc.card.id}
                                    data-card-id={mc.cardId}
                                    onClick={(e) => {
                                        handleCardClick(e)
                                    }}
                                >
                                    {mc.card.type === "Normal Monster" || mc.card.type === "Flip Effect Monster" || mc.card.type === "Effect Monster"
                                        ? <td><img className="card-icon" alt="card icon" src={monster} /></td>
                                        : mc.card.type === "Spell Card" ? <td><img className="card-icon" alt="card icon" src={spell} /></td>
                                            : mc.card.type === "Fusion Monster" ? <td><img className="card-icon" alt="card icon" src={extra} /></td>
                                                : mc.card.type === "Trap Card" ? <td><img className="card-icon" alt="card icon" src={trap} /></td>
                                                    : <td><img className="card-icon" alt="card icon" src={back} /></td>}
                                    <td

                                    >{mc.card.name}</td>
                                    <td>{mc.card.type}</td>
                                    <td>{convertAtt(mc.card.attribute)}</td>
                                    <td><CardLevelStars levelNum={mc.card.level} /></td>
                                </tr>
                            )
                        })}
                    </tbody>
                </table>
            </section>
        </section>);
}

