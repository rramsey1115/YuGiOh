import { useEffect, useState } from "react"
import { Spinner } from "reactstrap"
import { AttributeColor } from "./AttributeColor"

export const CardData = ({ card }) => {
 

    return (!card.name ? <Spinner /> :
        <div id="card-info_data">
            <h5>{card.desc ?? "unknown"}</h5>
            <AttributeColor attribute={card.attribute} />
            <p>Attack: {card.atk ?? "unknown"}</p>
            <p>Defense: {card.def ?? "unknown"}</p>
            <p>Race: {card.race ?? "unknown"}</p>
            <p>Level: {card.level ?? "unknown"}</p>
            <p>Type: {card.type ?? "unknown"}</p>
        </div>
    )
}