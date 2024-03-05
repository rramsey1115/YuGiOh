import { CardGrid } from "./CardList"

export const Home = ({ loggedInUser }) => {
    return (
        <section className="container">
            <header className="header">
                <h2>Cards</h2>
            </header>
            <section className="filters">

            </section>
            <section className="body">
                <CardGrid />
            </section>
        </section>
    )
}