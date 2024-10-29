import { useEffect, useState } from "react"

export const AttributeColor = ({attribute}) => {
    console.log("attribute", attribute);

    const [bgColor, setBgColor] = useState("transparent");
    const [textColor, setTextColor] = useState("black");

    const colors = [
        {type: "normal", color:'beige', textColor:'black'},
        {type: "fire", color:'crimson', textColor:'white'},
        {type: "water", color:'cornflowerBlue', textColor:'black'},
        {type: "electric", color:'gold', textColor:'black'},
        {type: "grass", color:'forestGreen', textColor:'white'},
        {type: "ice", color:'deepSkyBlue', textColor:'black'},
        {type: "fighting", color:'orangeRed', textColor:'white'},
        {type: "poison", color:'olive', textColor:'white'},
        {type: "ground", color:'saddleBrown', textColor:'white'},
        {type: "flying", color:'skyBlue', textColor:'black'},
        {type: "psychic", color:'plum', textColor:'white'},
        {type: "bug", color:'seaGreen', textColor:'black'},
        {type: "rock", color:'slateGrey', textColor:'black'},
        {type: "ghost", color:'seaShell', textColor:'black'},
        {type: "dragon", color:'red', textColor:'white'},
        {type: "dark", color:'black', textColor:'white'},
        {type: "steel", color:'dimGrey', textColor:'black'},
        {type: "fairy", color:'fuchsia', textColor:'black'},
        {type: "light", color:'antiqueWhite', textColor:'black'},
        {type: "earth", color:'brown', textColor:'white'}
    ]

    useEffect(() => {
        if(attribute) {
            const foundType = colors.find((c) => c.type.toLowerCase() === attribute.toLowerCase())
            console.log(foundType);
            setBgColor(foundType.color)
            setTextColor(foundType.textColor)
        }
    }, [attribute])


    return (attribute === null ? <div></div> :
        <div id="attr-div" style={{backgroundColor: bgColor, color: textColor}}>{attribute}</div>
    )
}