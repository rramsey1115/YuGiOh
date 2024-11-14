import { CardGrid } from "./CardGrid"

export const Home = () => {
    return (
        <section className="container">
            <header className="header">
                <h1>Cards</h1>
            </header>
            <section className="filters">

            </section>
            <section className="body">
                <CardGrid />
            </section>
        </section>
    )
}