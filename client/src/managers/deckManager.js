export const getUserDecksByUserId = (userId) => {
    return fetch(`/api/Deck/userDeck/userId/${userId}`).then((res) => res.json())
}

export const getDeckByDeckId = (deckId) => {
    return fetch(`/api/Deck/DeckId/${deckId}`).then((res) => res.json())
}

export const getDeckCardsByDeckId = (deckId) => {
    return fetch(`/api/DeckCard/deckId/${deckId}`).then((res) => res.json())
}

export const addCardToDeckCards = (cardId, deckId) => {
    console.log(`addCardToDeckCards => cardId:${cardId} - deckId:${deckId}`)
    return fetch(`http://localhost:3000/api/DeckCard/add/${cardId}/${deckId}`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        }
    })
}