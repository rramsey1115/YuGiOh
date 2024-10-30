import { useEffect, useState } from "react"

export const CardDefense = ({ def }) => {
    const [defColor, setDefColor] = useState('whiteSmoke');

    useEffect(() => {
        if (def > 1500) {
            setDefColor("lightSkyBlue")
        }
        if (def > 2000) {
            setDefColor("limeGreen")
        }
        if (def > 3000) {
            setDefColor("gold")
        }
    }, [def])

    return (<span style={{ color: defColor, fontWeight: 'bold' }}>{def}</span>)
}