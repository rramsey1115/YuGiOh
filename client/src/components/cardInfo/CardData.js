import { Spinner } from "reactstrap"
import { AttributeColor } from "./AttributeColor"
import { CardLevel } from "./CardLevel"
import { CardAttack } from "./CardAttack"
import { CardDefense } from "./CardDefense"

export const CardData = ({ card }) => {

    return (!card.name ? <Spinner /> :
        <div id="card-info_data">
            <h1 id="card-info_title">{card.name}</h1>
            <h5>{card.desc ?? "N/A"}</h5>
            <AttributeColor attribute={card.attribute} />
            <p>Type: {card.type ?? "N/A"}</p>
            <p>Race: {card.race ?? "N/A"}</p>
            <p>Level: {card.level ? <CardLevel levelNum={card.level} /> : "N/A"}</p>
            <p>Attack: {card.atk == null ? "N/A" : <CardAttack attack={card.atk} />}</p>
            <p>Defense: {card.def === null ? "N/A" : <CardDefense def={card.def} />}</p>
        </div>
    )
}