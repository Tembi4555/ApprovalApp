import { ways } from "../data"
import LiElement from "./LiElement"

export default function OutGoingSection() {
    return (
        <section>
            <h3>
                Исходящие
            </h3>
                  
            <ul>
                {ways.map(way => <LiElement key={way.title} {...way}/>)}
            </ul>
        </section>
    )
}