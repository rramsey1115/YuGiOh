export const getAllCards = () => {
    return fetch("api/Card").then(res => res.json());
}

export const getCardById = (cardId) => {
    return fetch(`/api/Card/${cardId}`).then(res => res.json())
}

export const getUserCardsByUserId = (userId) => {
    return fetch(`/api/Card/userCards/${userId}`).then(res => res.json())
}

export const addUserCard = (cardId, userId) => {
    return fetch(`/api/Card/userCards/add/${cardId}/${userId}`, {
        method: "POST",
        headers: { "Content-Type": "application/json" }
    }).then(res => res.ok ? res.json().catch(() => ({})) : Promise.reject("failed to add user card"))
        .catch(error => console.error("Error in addUserCard:", error))
}

export const removeUserCard = (cardId, userId) => {
    return fetch(`/api/Card/userCards/remove/${cardId}/${userId}`, {
        method: "DELETE",
        headers: { "Content-Type": "application/json" }
    })
        .then(res => res.ok ? res.json().catch(() => ({})) : Promise.reject("Failed to remove user card"))
        .catch(err => console.error("Error in removeUserCard:", err));
}