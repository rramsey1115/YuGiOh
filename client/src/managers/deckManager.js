export const getUserDecksByUserId = (userId) => {
    return fetch(`/api/Deck/userDeck/userId/${userId}`).then((res) => res.json())
}

export const getDeckByDeckId = (deckId) => {
    return fetch(`/api/Deck/DeckId/${deckId}`).then((res) => res.json())
}

export const getDeckCardsByDeckId = (deckId) => {
    return fetch(`/api/DeckCard/deckId/${deckId}`).then((res) => res.json())
}