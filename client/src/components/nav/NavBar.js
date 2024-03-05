import { useState } from "react";
import "./NavBar.css";
import { NavLink as RRNavLink } from "react-router-dom";
import {
  Button,
  Collapse,
  Nav,
  NavLink,
  NavItem,
  Navbar,
  NavbarBrand,
  NavbarToggler,
} from "reactstrap";
import logo from "../../images/yugioh-logo.png";
import { logout } from "../../managers/authManager";

export default function NavBar({ loggedInUser, setLoggedInUser }) {
  const [open, setOpen] = useState(false);

  const toggleNavbar = () => setOpen(!open);

  return (
    <div>
      <Navbar color="dark" dark fixed="true" expand="md">
        <NavbarBrand className="mr-auto" tag={RRNavLink} to="/">
          <img id="navbar-logo" src={logo} alt="yugioh-logo"/>
        </NavbarBrand>
        {loggedInUser ? (
          <>
            <NavbarToggler onClick={toggleNavbar} />
            <Collapse isOpen={open} navbar>
              <Nav navbar>
                <NavItem onClick={() => setOpen(false)}>
                  <NavLink tag={RRNavLink} to="/">
                    Home
                  </NavLink>
                </NavItem>
                <NavItem onClick={() => setOpen(false)}>
                  <NavLink tag={RRNavLink} to={`mycards/${loggedInUser.id}`}>
                    My Cards
                  </NavLink>
                </NavItem>
                <NavItem onClick={() => setOpen(false)}>
                  <NavLink tag={RRNavLink} to={`mydecks/${loggedInUser.id}`}>
                    My Decks
                  </NavLink>
                </NavItem>
              </Nav>
              <button
                className="logout-btn"
                color="danger"
                size="sm"
                onClick={(e) => {
                  e.preventDefault();
                  setOpen(false);
                  logout().then(() => {
                    setLoggedInUser(null);
                    setOpen(false);
                  });
                }}
              >
                Logout
              </button>
            </Collapse>
          </>
        ) : (
          <Nav navbar>
            <NavItem>
              <NavLink tag={RRNavLink} to="/login">
                <button className="logout-btn">Login</button>
              </NavLink>
            </NavItem>
          </Nav>
        )}
      </Navbar>
    </div>
  );
}
