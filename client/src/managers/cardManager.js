export const getAllCards = () => {
    return fetch("api/Card").then(res => res.json());
}

export const getCardById = (cardId) => {
    return fetch(`/api/Card/${cardId}`).then(res => res.json())
}