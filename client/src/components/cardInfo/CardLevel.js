import { useEffect, useState } from "react"

export const CardLevel = ({ levelNum }) => {
    const [levelColor, setLevelColor] = useState("white")

    useEffect(() => {
        if (levelNum > 4 && levelNum <= 6) {
            setLevelColor("lightSkyBlue")
        }
        if (levelNum > 6) {
            setLevelColor("limeGreen")
        }
        if(levelNum > 8) {
            setLevelColor("gold")
        }
    }, [levelNum])

    return (<span style={{ color: levelColor, fontWeight: 'bold' }}>{levelNum}</span>)
}