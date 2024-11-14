import { CardGrid } from "./CardGrid"

export const Home = () => {
    return (
        <section className="container">
            <header className="header">
                <h1>Cards</h1>
            </header>
            <section className="filters">
                <h5 className="filter-item">Filter By:</h5>
                <h5 className="filter-item">Level</h5>
                <h5 className="filter-item">Type</h5>
                <h5 className="filter-item">Attribute</h5>
            </section>
            <section className="body">
                <CardGrid />
            </section>
        </section>
    )
}