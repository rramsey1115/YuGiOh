import { CardGrid } from "./CardList"

export const Home = ({ nloggedInUser }) => {
    return (
        <section className="container">
            <header className="header">
                <h2>Yu-Gi-Oh Home Header</h2>
            </header>
            <section className="filters">

            </section>
            <section className="body">
                <CardGrid />
            </section>
        </section>
    )
}