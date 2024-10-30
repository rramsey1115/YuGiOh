import { useEffect, useState } from "react"

export const CardAttack = ({attack}) => {
    const [attackColor, setAttackColor] = useState('whiteSmoke');

    useEffect(() => {
        if(attack > 1500) {
            setAttackColor("lightSkyBlue")
        }
        if(attack > 2000) {
            setAttackColor("limeGreen")
        }
        if(attack > 3000 ) {
            setAttackColor("gold")
        }
    }, [attack])

    return(<span style={{color:attackColor, fontWeight:'bold'}}>{attack}</span>)
}