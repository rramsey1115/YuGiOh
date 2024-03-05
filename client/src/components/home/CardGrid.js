import * as React from 'react';
import { useState, useEffect } from 'react';
import { getAllCards } from '../../managers/cardManager';

export const CardGrid = () => {
    const [cards, setCards] = useState([]);

    useEffect(() => { getAndSetAllCards() }, [])

    const getAndSetAllCards = () => {
        getAllCards().then(setCards);
    }

    console.log('cards', cards);
    
    return (
        
        <div style={{ height: 800, width: '90%' }}>
            <table>

            </table>
        </div>
    );

}