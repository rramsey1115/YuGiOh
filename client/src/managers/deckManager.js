export const getUserDecksByUserId = (userId) => {
    return fetch(`/api/Deck/userDeck/userId/${userId}`).then((res) => res.json())
}