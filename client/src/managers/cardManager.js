export const getAllCards = () => {
    return fetch("api/card").then(res => res.json());
}