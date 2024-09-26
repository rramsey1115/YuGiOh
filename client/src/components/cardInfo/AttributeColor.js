import { useEffect, useState } from "react"

export const AttributeColor = ({attribute}) => {
    const [color, setColor] = useState("transparent")

    const colors = [
        {type: "normal", color:'beige'},
        {type: "fire", color:'crimson'},
        {type: "water", color:'cornflowerBlue'},
        {type: "electric", color:'gold'},
        {type: "grass", color:'forestGreen'},
        {type: "ice", color:'deepSkyBlue'},
        {type: "fighting", color:'orangeRed'},
        {type: "poison", color:'olive'},
        {type: "ground", color:'saddleBrown'},
        {type: "flying", color:'skyBlue'},
        {type: "psychic", color:'plum'},
        {type: "bug", color:'seaGreen'},
        {type: "rock", color:'slateGrey'},
        {type: "ghost", color:'seaShell'},
        {type: "dragon", color:'red'},
        {type: "dark", color:'black'},
        {type: "steel", color:'dimGrey'},
        {type: "fairy", color:'fuchsia'}
    ]

    useEffect(() => {
        const foundColor = colors.find((c) => c.type.toLowerCase() == attribute.toLowerCase())
        console.log(foundColor)
        setColor(foundColor.color)
    }, [color, attribute])


    console.log("attr", attribute)
    return (attribute === null ? <div></div> :
        <div id="attr-div" style={{backgroundColor: color}}>{attribute}</div>
    )
}